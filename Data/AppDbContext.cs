using Microsoft.EntityFrameworkCore;

namespace comments;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public required DbSet<Comment> Comments { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<Asset> Assets { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source=./app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData([
            new User {
                UserId = -1,
                Name = "juliosomo"
            },
            new User {
                UserId = -2,
                Name = "amyrobson"
            },
            new User {
                UserId = -3,
                Name = "maxblagun"
            },
            new User {
                UserId = -4,
                Name = "ramsesmiron"
            },
        ]);

        modelBuilder.Entity<Asset>().HasData([
            new Asset {
                AssetId = -1,
                UserId = -1,
                Path = "./images/avatar/image-juliosomo.png"
            },
            new Asset {
                AssetId = -2,
                UserId = -2,
                Path = "./images/avatar/image-amyrobson.png"
            },
            new Asset {
                AssetId = -3,
                UserId = -3,
                Path = "./images/avatar/image-maxblagun.png"
            },
            new Asset {
                AssetId = -4,
                UserId = -4,
                Path = "./images/avatar/image-ramsesmiron.png"
            },
            new Asset {
                AssetId = -5,
                UserId = -1,
                Path = "./images/avatar/image-juliosomo.webp"
            },
            new Asset {
                AssetId = -6,
                UserId = -2,
                Path = "./images/avatar/image-amyrobson.webp"
            },
            new Asset {
                AssetId = -7,
                UserId = -3,
                Path = "./images/avatar/image-maxblagun.webp"
            },
            new Asset {
                AssetId = -8,
                UserId = -4,
                Path = "./images/avatar/image-ramsesmiron.webp"
            },
        ]);

        modelBuilder.Entity<Comment>().HasData([
            new Comment {
                CommentId = -1,
                Content = "Impressive! Though it seems the drag feature could be improved. But overall it looks incredible. You've nailed the design and the responsiveness at various breakpoints works really well.",
                Score = 12,
                UserId = -2,
                CreatedAt = new DateTime(2025, 10, 22).AddMonths(-1)
            },
            new Comment {
                CommentId = -2,
                Content = "Woah, your project looks awesome! How long have you been coding for? I'm still new, but think I want to dive into React as well soon. Perhaps you can give me an insight on where I can learn React? Thanks!",
                Score = 5,
                UserId = -3,
                CreatedAt = new DateTime(2025, 10, 22).AddDays(-14)
            },
            new Comment {
                CommentId = -3,
                Content = "If you're still new, I'd recommend focusing on the fundamentals of HTML, CSS, and JS before considering React. It's very tempting to jump ahead but lay a solid foundation first.",
                Score = 4,
                UserId = -4,
                CreatedAt = new DateTime(2025, 10, 22).AddDays(-7),
                ParentCommentId = -2
            },
            new Comment {
                CommentId = -4,
                Content = "I couldn't agree more with this. Everything moves so fast and it always seems like everyone knows the newest library/framework. But the fundamentals are what stay constant.",
                Score = 2,
                UserId = -1,
                CreatedAt = new DateTime(2025, 10, 22).AddDays(-2),
                ParentCommentId = -2
            },
        ]);
    }
}
