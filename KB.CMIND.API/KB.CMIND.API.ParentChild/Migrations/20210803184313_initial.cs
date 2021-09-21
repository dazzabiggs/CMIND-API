using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.ParentChild.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "child_record_api");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "child_record_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street1 = table.Column<string>(type: "text", nullable: true),
                    Street2 = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                schema: "child_record_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    AddressID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Children_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "child_record_api",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                schema: "child_record_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    AddressID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parents_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "child_record_api",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildParent",
                schema: "child_record_api",
                columns: table => new
                {
                    ChildrenID = table.Column<int>(type: "integer", nullable: false),
                    ParentsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildParent", x => new { x.ChildrenID, x.ParentsID });
                    table.ForeignKey(
                        name: "FK_ChildParent_Children_ChildrenID",
                        column: x => x.ChildrenID,
                        principalSchema: "child_record_api",
                        principalTable: "Children",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildParent_Parents_ParentsID",
                        column: x => x.ParentsID,
                        principalSchema: "child_record_api",
                        principalTable: "Parents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildParent_ParentsID",
                schema: "child_record_api",
                table: "ChildParent",
                column: "ParentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Children_AddressID",
                schema: "child_record_api",
                table: "Children",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_AddressID",
                schema: "child_record_api",
                table: "Parents",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildParent",
                schema: "child_record_api");

            migrationBuilder.DropTable(
                name: "Children",
                schema: "child_record_api");

            migrationBuilder.DropTable(
                name: "Parents",
                schema: "child_record_api");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "child_record_api");
        }
    }
}
