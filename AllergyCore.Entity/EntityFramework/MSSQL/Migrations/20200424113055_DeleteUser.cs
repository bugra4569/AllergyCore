using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Migrations
{
    public partial class DeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Materials",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "IngredientsMaterialRelations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "IngredientsMaterialRelations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Ingredients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Foods",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "Foods",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AllergyMaterialRelations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "AllergyMaterialRelations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Allergies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteUser",
                table: "Allergies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "IngredientsMaterialRelations");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "IngredientsMaterialRelations");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AllergyMaterialRelations");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "AllergyMaterialRelations");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "DeleteUser",
                table: "Allergies");
        }
    }
}
