using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xmoor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoleApplicationsUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "RoleOpennings",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RoleOpennings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "RoleOpennings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "RoleOpennings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "RoleOpennings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "RoleOpennings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "RoleOpennings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoleOpennings_PublisherId",
                table: "RoleOpennings",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_PublisherId",
                table: "RoleOpennings",
                column: "PublisherId",
                principalTable: "StaffPersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_PublisherId",
                table: "RoleOpennings");

            migrationBuilder.DropIndex(
                name: "IX_RoleOpennings_PublisherId",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "RoleOpennings");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "RoleOpennings");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RoleOpennings",
                newName: "description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "RoleOpennings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "description",
                table: "RoleOpennings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "RoleOpennings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
