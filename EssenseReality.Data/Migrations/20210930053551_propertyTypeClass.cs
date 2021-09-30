using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class propertyTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_PropertyClasses_PropertyClassId",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "DataId",
                table: "CrmEssenceTransactions");

            migrationBuilder.DropColumn(
                name: "Retry",
                table: "CrmEssenceTransactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CrmEssenceTransactions");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CrmEssenceTransactions",
                newName: "ErrorDescription");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyClassId",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrmPropertyTypeId",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrmPropertyClassId",
                table: "PropertyClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_PropertyClasses_PropertyClassId",
                table: "PropertyTypes",
                column: "PropertyClassId",
                principalTable: "PropertyClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_PropertyClasses_PropertyClassId",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "CrmPropertyTypeId",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "CrmPropertyClassId",
                table: "PropertyClasses");

            migrationBuilder.RenameColumn(
                name: "ErrorDescription",
                table: "CrmEssenceTransactions",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyClassId",
                table: "PropertyTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DataId",
                table: "CrmEssenceTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Retry",
                table: "CrmEssenceTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CrmEssenceTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_PropertyClasses_PropertyClassId",
                table: "PropertyTypes",
                column: "PropertyClassId",
                principalTable: "PropertyClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
