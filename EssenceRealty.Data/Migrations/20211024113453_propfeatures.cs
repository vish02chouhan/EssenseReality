using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenceRealty.Data.Migrations
{
    public partial class propfeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatureProperty_Properties_PropertyId",
                table: "PropertyFeatureProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatureProperty_PropertyFeatures_PropertyFeatureId",
                table: "PropertyFeatureProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyFeatureProperty",
                table: "PropertyFeatureProperty");

            migrationBuilder.RenameTable(
                name: "PropertyFeatureProperty",
                newName: "PropertyFeatureProperties");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyFeatureProperty_PropertyFeatureId",
                table: "PropertyFeatureProperties",
                newName: "IX_PropertyFeatureProperties_PropertyFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyFeatureProperties",
                table: "PropertyFeatureProperties",
                columns: new[] { "PropertyId", "PropertyFeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatureProperties_Properties_PropertyId",
                table: "PropertyFeatureProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatureProperties_PropertyFeatures_PropertyFeatureId",
                table: "PropertyFeatureProperties",
                column: "PropertyFeatureId",
                principalTable: "PropertyFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatureProperties_Properties_PropertyId",
                table: "PropertyFeatureProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatureProperties_PropertyFeatures_PropertyFeatureId",
                table: "PropertyFeatureProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyFeatureProperties",
                table: "PropertyFeatureProperties");

            migrationBuilder.RenameTable(
                name: "PropertyFeatureProperties",
                newName: "PropertyFeatureProperty");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyFeatureProperties_PropertyFeatureId",
                table: "PropertyFeatureProperty",
                newName: "IX_PropertyFeatureProperty_PropertyFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyFeatureProperty",
                table: "PropertyFeatureProperty",
                columns: new[] { "PropertyId", "PropertyFeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatureProperty_Properties_PropertyId",
                table: "PropertyFeatureProperty",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatureProperty_PropertyFeatures_PropertyFeatureId",
                table: "PropertyFeatureProperty",
                column: "PropertyFeatureId",
                principalTable: "PropertyFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
