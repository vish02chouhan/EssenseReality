using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class contactstaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ContactStaffId",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberId",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhoneNumberId",
                table: "ContactStaffs");

            migrationBuilder.AddColumn<int>(
                name: "ContactStaffId",
                table: "PhoneNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "ContactStaffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
