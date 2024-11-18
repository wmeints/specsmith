using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SpecSmith.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenario_Features_FeatureId",
                table: "Scenario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scenario",
                table: "Scenario");

            migrationBuilder.RenameTable(
                name: "Scenario",
                newName: "Scenarios");

            migrationBuilder.RenameIndex(
                name: "IX_Scenario_FeatureId",
                table: "Scenarios",
                newName: "IX_Scenarios_FeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scenarios",
                table: "Scenarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ScenarioId = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ScenarioId",
                table: "Steps",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenarios_Features_FeatureId",
                table: "Scenarios",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenarios_Features_FeatureId",
                table: "Scenarios");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scenarios",
                table: "Scenarios");

            migrationBuilder.RenameTable(
                name: "Scenarios",
                newName: "Scenario");

            migrationBuilder.RenameIndex(
                name: "IX_Scenarios_FeatureId",
                table: "Scenario",
                newName: "IX_Scenario_FeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scenario",
                table: "Scenario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenario_Features_FeatureId",
                table: "Scenario",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
