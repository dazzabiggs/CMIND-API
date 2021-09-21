﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KB.CMIND.API.CMDetails.Migrations
{
    public partial class Removetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                schema: "details_api",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                schema: "details_api",
                table: "Addresses",
                type: "text",
                nullable: true);
        }
    }
}
