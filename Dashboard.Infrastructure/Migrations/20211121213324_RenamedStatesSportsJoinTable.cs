using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class RenamedStatesSportsJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateSports_Sports_SportId",
                table: "StateSports");

            migrationBuilder.DropForeignKey(
                name: "FK_StateSports_States_StateId",
                table: "StateSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StateSports",
                table: "StateSports");

            migrationBuilder.RenameTable(
                name: "StateSports",
                newName: "StatesSports");

            migrationBuilder.RenameIndex(
                name: "IX_StateSports_StateId",
                table: "StatesSports",
                newName: "IX_StatesSports_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_StateSports_SportId",
                table: "StatesSports",
                newName: "IX_StatesSports_SportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatesSports",
                table: "StatesSports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatesSports_Sports_SportId",
                table: "StatesSports",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatesSports_States_StateId",
                table: "StatesSports",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatesSports_Sports_SportId",
                table: "StatesSports");

            migrationBuilder.DropForeignKey(
                name: "FK_StatesSports_States_StateId",
                table: "StatesSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatesSports",
                table: "StatesSports");

            migrationBuilder.RenameTable(
                name: "StatesSports",
                newName: "StateSports");

            migrationBuilder.RenameIndex(
                name: "IX_StatesSports_StateId",
                table: "StateSports",
                newName: "IX_StateSports_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_StatesSports_SportId",
                table: "StateSports",
                newName: "IX_StateSports_SportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateSports",
                table: "StateSports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StateSports_Sports_SportId",
                table: "StateSports",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateSports_States_StateId",
                table: "StateSports",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
