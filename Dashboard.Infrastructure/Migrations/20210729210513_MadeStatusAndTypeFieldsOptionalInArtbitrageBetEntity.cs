using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class MadeStatusAndTypeFieldsOptionalInArtbitrageBetEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageBets_Statuses_StatusId",
                table: "ArbitrageBets");

            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageBets_Types_TypeId",
                table: "ArbitrageBets");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ArbitrageBets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ArbitrageBets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageBets_Statuses_StatusId",
                table: "ArbitrageBets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageBets_Types_TypeId",
                table: "ArbitrageBets",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageBets_Statuses_StatusId",
                table: "ArbitrageBets");

            migrationBuilder.DropForeignKey(
                name: "FK_ArbitrageBets_Types_TypeId",
                table: "ArbitrageBets");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "ArbitrageBets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ArbitrageBets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageBets_Statuses_StatusId",
                table: "ArbitrageBets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArbitrageBets_Types_TypeId",
                table: "ArbitrageBets",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
