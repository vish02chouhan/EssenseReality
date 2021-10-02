using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class contactStaffPoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs");

            migrationBuilder.DropIndex(
                name: "IX_ContactStaffs_PhotoId",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "ContactStaffs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inserted",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "ContactStaffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactStaffs_PhotoId",
                table: "ContactStaffs",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
