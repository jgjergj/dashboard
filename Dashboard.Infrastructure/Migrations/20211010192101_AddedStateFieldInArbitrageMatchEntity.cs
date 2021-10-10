using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class AddedStateFieldInArbitrageMatchEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "ArbitrageMatches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageMatches_StateId",
                table: "ArbitrageMatches",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageMatches_States_StateId",
                table: "ArbitrageMatches",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageMatches_States_StateId",
                table: "ArbitrageMatches");

            migrationBuilder.DropIndex(
                name: "IX_ArbitrageMatches_StateId",
                table: "ArbitrageMatches");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "ArbitrageMatches");
        }
    }
}
