using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UnitDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractFiles_Unit_UnitID",
                table: "ContractFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_UnitType_UnitTypeID",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_UnitTypeID",
                table: "Units",
                newName: "IX_Units_UnitTypeID");

            migrationBuilder.AddColumn<string>(
                name: "UnitTypeDescription",
                table: "UnitType",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitDescription",
                table: "Units",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractFiles_Units_UnitID",
                table: "ContractFiles",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitType_UnitTypeID",
                table: "Units",
                column: "UnitTypeID",
                principalTable: "UnitType",
                principalColumn: "UnitTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractFiles_Units_UnitID",
                table: "ContractFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitType_UnitTypeID",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitTypeDescription",
                table: "UnitType");

            migrationBuilder.DropColumn(
                name: "UnitDescription",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameIndex(
                name: "IX_Units_UnitTypeID",
                table: "Unit",
                newName: "IX_Unit_UnitTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractFiles_Unit_UnitID",
                table: "ContractFiles",
                column: "UnitID",
                principalTable: "Unit",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_UnitType_UnitTypeID",
                table: "Unit",
                column: "UnitTypeID",
                principalTable: "UnitType",
                principalColumn: "UnitTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
