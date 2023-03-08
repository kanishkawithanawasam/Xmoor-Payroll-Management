using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xmoor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoleOpeningsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "RoleOpennings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "RoleOpennings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RoleOpennings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "RoleOpennings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "RoleOpennings");
        }
    }
}
