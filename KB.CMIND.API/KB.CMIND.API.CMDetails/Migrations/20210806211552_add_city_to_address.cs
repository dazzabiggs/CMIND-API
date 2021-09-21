using Microsoft.EntityFrameworkCore.Migrations;

namespace KB.CMIND.API.CMDetails.Migrations
{
    public partial class add_city_to_address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "details_api",
                table: "Addresses",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "details_api",
                table: "Addresses");
        }
    }
}
