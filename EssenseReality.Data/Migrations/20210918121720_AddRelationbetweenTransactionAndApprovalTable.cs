using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class AddRelationbetweenTransactionAndApprovalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EssenceObjectRequiredApprovals_CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals",
                column: "CrmEssenceTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceObjectRequiredApprovals_CrmEssenceTransactions_CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals",
                column: "CrmEssenceTransactionId",
                principalTable: "CrmEssenceTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssenceObjectRequiredApprovals_CrmEssenceTransactions_CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals");

            migrationBuilder.DropIndex(
                name: "IX_EssenceObjectRequiredApprovals_CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals");

            migrationBuilder.DropColumn(
                name: "CrmEssenceTransactionId",
                table: "EssenceObjectRequiredApprovals");
        }
    }
}
