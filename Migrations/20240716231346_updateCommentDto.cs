using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog_Management.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f203122-5b0b-46f1-be42-4bdb6d8616ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89caec9-c17c-43ec-b152-51d96da5210f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "127233fe-563b-4e53-85ad-7c2007fe35f2", null, "User", "USER" },
                    { "5536f3d7-3dac-42f5-adc6-d89c8a63a8dc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "127233fe-563b-4e53-85ad-7c2007fe35f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5536f3d7-3dac-42f5-adc6-d89c8a63a8dc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f203122-5b0b-46f1-be42-4bdb6d8616ea", null, "User", "USER" },
                    { "e89caec9-c17c-43ec-b152-51d96da5210f", null, "Admin", "ADMIN" }
                });
        }
    }
}
