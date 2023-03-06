using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xmoor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_PublisherId",
                table: "RoleOpennings");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "RoleOpennings",
                newName: "EditorId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleOpennings_PublisherId",
                table: "RoleOpennings",
                newName: "IX_RoleOpennings_EditorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "RoleOpennings",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_EditorId",
                table: "RoleOpennings",
                column: "EditorId",
                principalTable: "StaffPersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_EditorId",
                table: "RoleOpennings");

            migrationBuilder.RenameColumn(
                name: "EditorId",
                table: "RoleOpennings",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleOpennings_EditorId",
                table: "RoleOpennings",
                newName: "IX_RoleOpennings_PublisherId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpeningDate",
                table: "RoleOpennings",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleOpennings_StaffPersonalDetails_PublisherId",
                table: "RoleOpennings",
                column: "PublisherId",
                principalTable: "StaffPersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
