using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllergyCore.Entity.EntityFramework.MSSQL.Migrations
{
    public partial class CorrectRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyMaterialRelations");

            migrationBuilder.DropTable(
                name: "IngredientsMaterialRelations");

            migrationBuilder.DropColumn(
                name: "IsDeathly",
                table: "Allergies");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Allergies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MaterialId",
                table: "Ingredients",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_MaterialId",
                table: "Allergies",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Materials_MaterialId",
                table: "Allergies",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Materials_MaterialId",
                table: "Ingredients",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Materials_MaterialId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Materials_MaterialId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MaterialId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_MaterialId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Allergies");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeathly",
                table: "Allergies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AllergyMaterialRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    RowStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndredientId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    RowStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }
    }
}
