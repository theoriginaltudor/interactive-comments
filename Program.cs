using comments;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    Console.Error.WriteLine(exception);

    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = "application/json";

    var problem = new
    {
        title = "An unexpected error occurred.",
        detail = exception?.Message,
    };

    await context.Response.WriteAsJsonAsync(problem);
}));
app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/comments", async (AppDbContext db) =>
{
    var comments = await db.Comments
                        .Where(c => c.ParentCommentId == null)
                        .Include(c => c.Replies)
                        .ThenInclude(r => r.User).ThenInclude(u => u.Assets)
                        .Include(c => c.User)
                        .ThenInclude(u => u.Assets)
                        .AsNoTracking()
                        .ToListAsync();
    return Results.Ok(comments);
});

app.MapGet("/users", async (AppDbContext db) =>
{
    var users = await db.Users.Include(u => u.Assets).AsNoTracking().ToListAsync();
    return Results.Ok(users);
});

app.MapPost("/comment", async (AppDbContext db, [FromBody] Comment inputComment) =>
{
    var entry = await db.Comments.AddAsync(inputComment);
    await db.SaveChangesAsync();

    return Results.Ok(entry.Entity);
});

app.MapDelete("/comment/{id}", async (AppDbContext db, int id) =>
{
    var comment = await db.Comments.FindAsync(id);
    if (comment == null)
        return Results.NotFound(new { Message = $"Comment {id} not found." });

    db.Comments.Remove(comment);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPut("/commnet/{id}", async (AppDbContext db, int id, [FromBody] Comment inputComment) =>
{
    var comment = await db.Comments.FindAsync(id);
    if (comment == null)
        return Results.NotFound(new { Message = $"Comment {id} not found." });

    comment.Content = inputComment.Content;
    comment.Score = inputComment.Score;

    await db.SaveChangesAsync();
    return Results.Ok(comment);
});

app.Run();
