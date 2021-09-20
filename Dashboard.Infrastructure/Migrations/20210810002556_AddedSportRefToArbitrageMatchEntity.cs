using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class AddedSportRefToArbitrageMatchEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "ArbitrageMatches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageMatches_SportId",
                table: "ArbitrageMatches",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageMatches_Sports_SportId",
                table: "ArbitrageMatches",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageMatches_Sports_SportId",
                table: "ArbitrageMatches");

            migrationBuilder.DropIndex(
                name: "IX_ArbitrageMatches_SportId",
                table: "ArbitrageMatches");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "ArbitrageMatches");
        }
    }
}
