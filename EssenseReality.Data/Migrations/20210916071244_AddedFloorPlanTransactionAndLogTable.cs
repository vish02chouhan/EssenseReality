using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssenseReality.Data.Migrations
{
    public partial class AddedFloorPlanTransactionAndLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Thumbnails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Thumbnails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Thumbnails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Thumbnails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Suburb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Suburb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Suburb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Suburb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PropertyFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "PropertyFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "PropertyFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "PropertyFeatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PropertyClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "PropertyClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "PropertyClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "PropertyClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorPlanId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LeaseLifeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleLifeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stories",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FloorPlanId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Geolocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Geolocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Geolocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Geolocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "ContactStaffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedDate",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifieldBy",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CrmEssenceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JsonObjectBatch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndPointUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    RecivedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Retry = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<int>(type: "int", nullable: false),
                    ModifieldBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmEssenceLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: true),
                    EnquiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaleLifeId = table.Column<int>(type: "int", nullable: false),
                    LeaseLifeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enquiries_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloorPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrmEssenceTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrmEssenceLogId = table.Column<int>(type: "int", nullable: true),
                    JsonObject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retry = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<int>(type: "int", nullable: false),
                    ModifieldBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmEssenceTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrmEssenceTransactions_CrmEssenceLogs_CrmEssenceLogId",
                        column: x => x.CrmEssenceLogId,
                        principalTable: "CrmEssenceLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FloorPlanId",
                table: "Properties",
                column: "FloorPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_FloorPlanId",
                table: "Photos",
                column: "FloorPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmEssenceTransactions_CrmEssenceLogId",
                table: "CrmEssenceTransactions",
                column: "CrmEssenceLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_PropertyId",
                table: "Enquiries",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_FloorPlans_FloorPlanId",
                table: "Photos",
                column: "FloorPlanId",
                principalTable: "FloorPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_FloorPlans_FloorPlanId",
                table: "Properties",
                column: "FloorPlanId",
                principalTable: "FloorPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_FloorPlans_FloorPlanId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_FloorPlans_FloorPlanId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "CrmEssenceTransactions");

            migrationBuilder.DropTable(
                name: "Enquiries");

            migrationBuilder.DropTable(
                name: "FloorPlans");

            migrationBuilder.DropTable(
                name: "CrmEssenceLogs");

            migrationBuilder.DropIndex(
                name: "IX_Properties_FloorPlanId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Photos_FloorPlanId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Thumbnails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Suburb");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "State");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "State");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "State");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "State");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "PropertyFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyClasses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertyClasses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PropertyClasses");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "PropertyClasses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FloorPlanId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LeaseLifeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SaleLifeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Stories",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FloorPlanId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Geolocations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Geolocations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Geolocations");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Geolocations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "ContactStaffs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifieldBy",
                table: "Addresses");
        }
    }
}
