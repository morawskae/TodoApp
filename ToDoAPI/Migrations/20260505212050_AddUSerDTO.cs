using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUSerDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ToDoItems",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "isFinished",
                table: "ToDoItems",
                newName: "IsFinished");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ToDoItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ToDoItems",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ToDoItems",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "ToDoItems",
                newName: "isFinished");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ToDoItems",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDoItems",
                newName: "id");
        }
    }
}
