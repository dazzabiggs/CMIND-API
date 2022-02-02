using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Attendance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "attendance_api");

            migrationBuilder.CreateTable(
                name: "AttendanceTypes",
                schema: "attendance_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                schema: "attendance_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientID = table.Column<string>(type: "text", nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceLogs",
                schema: "attendance_api",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildID = table.Column<int>(type: "integer", nullable: false),
                    AttendanceTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttendanceLogs_AttendanceTypes_AttendanceTypeID",
                        column: x => x.AttendanceTypeID,
                        principalSchema: "attendance_api",
                        principalTable: "AttendanceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLogs_AttendanceTypeID",
                schema: "attendance_api",
                table: "AttendanceLogs",
                column: "AttendanceTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceLogs",
                schema: "attendance_api");

            migrationBuilder.DropTable(
                name: "ClientDetails",
                schema: "attendance_api");

            migrationBuilder.DropTable(
                name: "AttendanceTypes",
                schema: "attendance_api");
        }
    }
}
