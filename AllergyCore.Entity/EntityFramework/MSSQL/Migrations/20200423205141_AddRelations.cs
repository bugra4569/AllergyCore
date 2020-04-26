using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "AllergyMaterialRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true),
                    RowStatus = table.Column<byte>(nullable: false),
                    AllergyId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyMaterialRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllergyMaterialRelations_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyMaterialRelations_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsMaterialRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true),
                    RowStatus = table.Column<byte>(nullable: false),
                    IndredientId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsMaterialRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsMaterialRelations_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientsMaterialRelations_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FoodId",
                table: "Ingredients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergyMaterialRelations_AllergyId",
                table: "AllergyMaterialRelations",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergyMaterialRelations_MaterialId",
                table: "AllergyMaterialRelations",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsMaterialRelations_IngredientId",
                table: "IngredientsMaterialRelations",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsMaterialRelations_MaterialId",
                table: "IngredientsMaterialRelations",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Foods_FoodId",
                table: "Ingredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Foods_FoodId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "AllergyMaterialRelations");

            migrationBuilder.DropTable(
                name: "IngredientsMaterialRelations");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_FoodId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
