using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPCRS1.Migrations
{
    public partial class unitcmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "unit_cmp",
                table: "processDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unit_cmp",
                table: "ExcelData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unit_cmp",
                table: "processDatas");

            migrationBuilder.DropColumn(
                name: "unit_cmp",
                table: "ExcelData");
        }
    }
}
