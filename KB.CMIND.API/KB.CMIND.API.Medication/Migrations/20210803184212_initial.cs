using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Medication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "medication_api");

            migrationBuilder.CreateTable(
                name: "MedicationTypes",
                schema: "medication_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicationItems",
                schema: "medication_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MedicationTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicationItems_MedicationTypes_MedicationTypeID",
                        column: x => x.MedicationTypeID,
                        principalSchema: "medication_api",
                        principalTable: "MedicationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationDelivery",
                schema: "medication_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dosage = table.Column<string>(type: "text", nullable: true),
                    Times = table.Column<string>(type: "text", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChildID = table.Column<int>(type: "integer", nullable: false),
                    MedicationItemID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationDelivery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicationDelivery_MedicationItems_MedicationItemID",
                        column: x => x.MedicationItemID,
                        principalSchema: "medication_api",
                        principalTable: "MedicationItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationDelivery_MedicationItemID",
                schema: "medication_api",
                table: "MedicationDelivery",
                column: "MedicationItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationItems_MedicationTypeID",
                schema: "medication_api",
                table: "MedicationItems",
                column: "MedicationTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationDelivery",
                schema: "medication_api");

            migrationBuilder.DropTable(
                name: "MedicationItems",
                schema: "medication_api");

            migrationBuilder.DropTable(
                name: "MedicationTypes",
                schema: "medication_api");
        }
    }
}
