using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class soiurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoiUrl",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoiUrl",
                table: "Properties");
        }
    }
}
