using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class PropertyTransactiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyTranasctionType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyTranasctionType",
                table: "Properties");
        }
    }
}
