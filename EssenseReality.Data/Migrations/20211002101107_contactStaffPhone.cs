using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class contactStaffPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactStaffs_PhoneNumbers_PhoneNumberId",
                table: "ContactStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs");

            migrationBuilder.DropIndex(
                name: "IX_ContactStaffs_PhoneNumberId",
                table: "ContactStaffs");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberId",
                table: "ContactStaffs",
                newName: "CrmContactStaffId");

            migrationBuilder.AddColumn<int>(
                name: "CrmPhotoId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactStaffId",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "ContactStaffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AdminAccess",
                table: "ContactStaffs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "OriginalPhotoURL",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumb_360PhotoURL",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactStaffId",
                table: "PhoneNumbers",
                column: "ContactStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_ContactStaffs_ContactStaffId",
                table: "PhoneNumbers",
                column: "ContactStaffId",
                principalTable: "ContactStaffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_ContactStaffs_ContactStaffId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_ContactStaffId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "CrmPhotoId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ContactStaffId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "OriginalPhotoURL",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "Thumb_360PhotoURL",
                table: "ContactStaffs");

            migrationBuilder.RenameColumn(
                name: "CrmContactStaffId",
                table: "ContactStaffs",
                newName: "PhoneNumberId");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLogin",
                table: "ContactStaffs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AdminAccess",
                table: "ContactStaffs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactStaffs_PhoneNumberId",
                table: "ContactStaffs",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactStaffs_PhoneNumbers_PhoneNumberId",
                table: "ContactStaffs",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactStaffs_Photos_PhotoId",
                table: "ContactStaffs",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
