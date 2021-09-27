using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class rerelatelogtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmEssenceTransactions_CrmEssenceLogs_CrmEssenceLogId",
                table: "CrmEssenceTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "CrmEssenceLogId",
                table: "CrmEssenceTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmEssenceTransactions_CrmEssenceLogs_CrmEssenceLogId",
                table: "CrmEssenceTransactions",
                column: "CrmEssenceLogId",
                principalTable: "CrmEssenceLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmEssenceTransactions_CrmEssenceLogs_CrmEssenceLogId",
                table: "CrmEssenceTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "CrmEssenceLogId",
                table: "CrmEssenceTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmEssenceTransactions_CrmEssenceLogs_CrmEssenceLogId",
                table: "CrmEssenceTransactions",
                column: "CrmEssenceLogId",
                principalTable: "CrmEssenceLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
