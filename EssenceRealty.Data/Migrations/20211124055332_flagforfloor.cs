using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class flagforfloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FloorPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FloorPlans");
        }
    }
}
