using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace comments.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name" },
                values: new object[,]
                {
                    { -4, "ramsesmiron" },
                    { -3, "maxblagun" },
                    { -2, "amyrobson" },
                    { -1, "juliosomo" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "Path", "UserId" },
                values: new object[,]
                {
                    { -8, "./images/avatar/image-ramsesmiron.webp", -4 },
                    { -7, "./images/avatar/image-maxblagun.webp", -3 },
                    { -6, "./images/avatar/image-amyrobson.webp", -2 },
                    { -5, "./images/avatar/image-juliosomo.webp", -1 },
                    { -4, "./images/avatar/image-ramsesmiron.png", -4 },
                    { -3, "./images/avatar/image-maxblagun.png", -3 },
                    { -2, "./images/avatar/image-amyrobson.png", -2 },
                    { -1, "./images/avatar/image-juliosomo.png", -1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "ParentCommentId", "Score", "UserId" },
                values: new object[,]
                {
                    { -2, "Woah, your project looks awesome! How long have you been coding for? I'm still new, but think I want to dive into React as well soon. Perhaps you can give me an insight on where I can learn React? Thanks!", new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, -3 },
                    { -1, "Impressive! Though it seems the drag feature could be improved. But overall it looks incredible. You've nailed the design and the responsiveness at various breakpoints works really well.", new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12, -2 },
                    { -4, "I couldn't agree more with this. Everything moves so fast and it always seems like everyone knows the newest library/framework. But the fundamentals are what stay constant.", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 2, -1 },
                    { -3, "If you're still new, I'd recommend focusing on the fundamentals of HTML, CSS, and JS before considering React. It's very tempting to jump ahead but lay a solid foundation first.", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 4, -4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -3);
        }
    }
}
