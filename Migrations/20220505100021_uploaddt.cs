using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPCRS1.Migrations
{
    public partial class uploaddt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "uploaddt",
                table: "processDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uploaddt",
                table: "processDatas");
        }
    }
}
