using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Incidents.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "incidents_api");

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                schema: "incidents_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                schema: "incidents_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildID = table.Column<int>(type: "integer", nullable: false),
                    IncidentTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentTypes_IncidentTypeID",
                        column: x => x.IncidentTypeID,
                        principalSchema: "incidents_api",
                        principalTable: "IncidentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypeID",
                schema: "incidents_api",
                table: "Incidents",
                column: "IncidentTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents",
                schema: "incidents_api");

            migrationBuilder.DropTable(
                name: "IncidentTypes",
                schema: "incidents_api");
        }
    }
}
