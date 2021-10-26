using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class enquiryModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiries_Properties_PropertyId",
                table: "Enquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_Properties_PropertyId",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_PropertyId",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Enquiries_PropertyId",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Enquiries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PropertyFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Enquiries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_PropertyId",
                table: "PropertyFeatures",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_PropertyId",
                table: "Enquiries",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiries_Properties_PropertyId",
                table: "Enquiries",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_Properties_PropertyId",
                table: "PropertyFeatures",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
