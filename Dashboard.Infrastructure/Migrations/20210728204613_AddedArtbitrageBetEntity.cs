using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dashboard.Infrastructure.Migrations
{
    public partial class AddedArtbitrageBetEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArbitrageBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArbitrageMatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Line = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Stake = table.Column<double>(type: "double precision", nullable: false),
                    Odd = table.Column<double>(type: "double precision", nullable: false),
                    Return = table.Column<double>(type: "double precision", nullable: false),
                    Profit = table.Column<double>(type: "double precision", nullable: false),
                    ProfitARB = table.Column<double>(type: "double precision", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbitrageBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArbitrageBets_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbitrageBets_ArbitrageMatches_ArbitrageMatchId",
                        column: x => x.ArbitrageMatchId,
                        principalTable: "ArbitrageMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbitrageBets_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbitrageBets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArbitrageBets_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageBets_AccountId",
                table: "ArbitrageBets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageBets_ArbitrageMatchId",
                table: "ArbitrageBets",
                column: "ArbitrageMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageBets_CompanyId",
                table: "ArbitrageBets",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageBets_StatusId",
                table: "ArbitrageBets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ArbitrageBets_TypeId",
                table: "ArbitrageBets",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArbitrageBets");
        }
    }
}
