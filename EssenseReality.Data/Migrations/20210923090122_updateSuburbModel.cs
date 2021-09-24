using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class updateSuburbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Suburb_SuburbId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_SuburbId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SuburbId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuburbId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifieldBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suburb_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SuburbId",
                table: "Addresses",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_StateId",
                table: "Suburb",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Suburb_SuburbId",
                table: "Addresses",
                column: "SuburbId",
                principalTable: "Suburb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
