using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class contactstaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookProfile",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramProfile",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinProfile",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialities",
                table: "ContactStaffs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "FacebookProfile",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "InstagramProfile",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "LinkedinProfile",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "Specialities",
                table: "ContactStaffs");
        }
    }
}
