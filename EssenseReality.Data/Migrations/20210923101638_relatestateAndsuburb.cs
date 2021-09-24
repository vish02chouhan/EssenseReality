using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class relatestateAndsuburb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_Suburb_SuburbId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_SuburbId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "SuburbId",
                table: "State");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Suburb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_StateId",
                table: "Suburb",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb");

            migrationBuilder.DropIndex(
                name: "IX_Suburb_StateId",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Suburb");

            migrationBuilder.AddColumn<Guid>(
                name: "SuburbId",
                table: "State",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_SuburbId",
                table: "State",
                column: "SuburbId");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Suburb_SuburbId",
                table: "State",
                column: "SuburbId",
                principalTable: "Suburb",
                principalColumn: "SuburbId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
