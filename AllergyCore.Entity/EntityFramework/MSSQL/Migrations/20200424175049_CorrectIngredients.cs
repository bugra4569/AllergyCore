using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Migrations
{
    public partial class CorrectIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitsId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: true),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(nullable: true),
                    RowStatus = table.Column<byte>(nullable: false),
                    DeleteUser = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UnitsId",
                table: "Ingredients",
                column: "UnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitsId",
                table: "Ingredients",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitsId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_UnitsId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitsId",
                table: "Ingredients");
        }
    }
}
