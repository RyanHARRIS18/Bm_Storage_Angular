using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Property2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnitTypeImageUrl",
                table: "UnitType",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Occupancy",
                table: "Units",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UnitSpecificImageUrl",
                table: "Units",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitTypeImageUrl",
                table: "UnitType");

            migrationBuilder.DropColumn(
                name: "Occupancy",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitSpecificImageUrl",
                table: "Units");
        }
    }
}
