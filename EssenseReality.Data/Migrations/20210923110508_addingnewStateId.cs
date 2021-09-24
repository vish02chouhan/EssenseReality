using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class addingnewStateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Suburb",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifieldBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_StateId",
                table: "Suburb",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_State_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_State_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Suburb_StateId",
                table: "Suburb");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Addresses");
        }
    }
}
