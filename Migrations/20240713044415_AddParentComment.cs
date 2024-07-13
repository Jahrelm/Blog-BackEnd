using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddParentComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ecf7d65-8d17-4e16-bca4-34f132b665d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "847d9b5f-bd43-4c11-90ed-a60e20c4fb2d");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f203122-5b0b-46f1-be42-4bdb6d8616ea", null, "User", "USER" },
                    { "e89caec9-c17c-43ec-b152-51d96da5210f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f203122-5b0b-46f1-be42-4bdb6d8616ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89caec9-c17c-43ec-b152-51d96da5210f");

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ecf7d65-8d17-4e16-bca4-34f132b665d5", null, "User", "USER" },
                    { "847d9b5f-bd43-4c11-90ed-a60e20c4fb2d", null, "Admin", "ADMIN" }
                });
        }
    }
}
