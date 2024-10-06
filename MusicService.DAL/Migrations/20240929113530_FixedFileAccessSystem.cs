using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedFileAccessSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3d80c251-daf8-4ce2-8571-bf9a9f3e0747" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d80c251-daf8-4ce2-8571-bf9a9f3e0747");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Melodies",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "AudioFileName",
                table: "Melodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Melodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6a7025e3-0934-4edf-874e-4d38c9fa1bc8", 0, "2c480bc8-8fd6-4356-ad82-86425883acdc", "admin123@i.ua", true, false, null, "ADMIN123@I.UA", "ADMIN123@I.UA", "AQAAAAIAAYagAAAAEF3y164aKSfeb3tXGeI3G5uNEDbzW4vMMEEFPx9Mw+JuS1DC5K6AIjxNj9UrSeqO9w==", "1234567890", true, "57a11589-b0f6-420c-8a71-2f89ca9d4416", false, "admin123@i.ua" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "6a7025e3-0934-4edf-874e-4d38c9fa1bc8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6a7025e3-0934-4edf-874e-4d38c9fa1bc8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a7025e3-0934-4edf-874e-4d38c9fa1bc8");

            migrationBuilder.DropColumn(
                name: "AudioFileName",
                table: "Melodies");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Melodies");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Melodies",
                newName: "duration");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d80c251-daf8-4ce2-8571-bf9a9f3e0747", 0, "defa870a-4fa7-4e6e-9328-fb1ea1678db1", "admin123@i.ua", true, false, null, "ADMIN123@I.UA", "ADMIN123@I.UA", "AQAAAAIAAYagAAAAEHQT48JhumnlNjJEUYTphya2jUf11tsO7mdxmksLRRSphotcGJ+Rn3kse16S+NI7iw==", "1234567890", true, "2ed0e11c-4f0c-4be7-b3d6-4868a9a2d30e", false, "admin123@i.ua" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "3d80c251-daf8-4ce2-8571-bf9a9f3e0747" });
        }
    }
}
