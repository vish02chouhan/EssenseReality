using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class stateandSuburbNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_State_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Suburb_SuburbId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suburb",
                table: "Suburb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "Suburb",
                newName: "Suburbs");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameIndex(
                name: "IX_Suburb_StateId",
                table: "Suburbs",
                newName: "IX_Suburbs_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suburbs",
                table: "Suburbs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Suburbs_SuburbId",
                table: "Addresses",
                column: "SuburbId",
                principalTable: "Suburbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suburbs_States_StateId",
                table: "Suburbs",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Suburbs_SuburbId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Suburbs_States_StateId",
                table: "Suburbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suburbs",
                table: "Suburbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "Suburbs",
                newName: "Suburb");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameIndex(
                name: "IX_Suburbs_StateId",
                table: "Suburb",
                newName: "IX_Suburb_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suburb",
                table: "Suburb",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_State_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Suburb_SuburbId",
                table: "Addresses",
                column: "SuburbId",
                principalTable: "Suburb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suburb_State_StateId",
                table: "Suburb",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
