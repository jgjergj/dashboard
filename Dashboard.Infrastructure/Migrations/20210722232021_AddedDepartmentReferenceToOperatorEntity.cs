using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class AddedDepartmentReferenceToOperatorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Operators",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operators_DepartmentId",
                table: "Operators",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Departments_DepartmentId",
                table: "Operators",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Departments_DepartmentId",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Operators_DepartmentId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Operators");
        }
    }
}
