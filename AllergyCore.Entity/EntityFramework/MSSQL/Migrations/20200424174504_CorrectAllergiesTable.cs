using Microsoft.EntityFrameworkCore.Migrations;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Migrations
{
    public partial class CorrectAllergiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Causes",
                table: "Allergies");

            migrationBuilder.AddColumn<bool>(
                name: "IsCommon",
                table: "Allergies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCritical",
                table: "Allergies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeathlyForKids",
                table: "Allergies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "RateOfIncidence",
                table: "Allergies",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCommon",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "IsCritical",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "IsDeathlyForKids",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "RateOfIncidence",
                table: "Allergies");

            migrationBuilder.AddColumn<string>(
                name: "Causes",
                table: "Allergies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
