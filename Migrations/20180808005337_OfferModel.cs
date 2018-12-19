using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyWealth.Migrations
{
    public partial class OfferModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(maxLength: 450, nullable: true),
                    SymbolId = table.Column<int>(nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Action = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Expired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_TickerSymbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "TickerSymbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SymbolId",
                table: "Offer",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_UserId",
                table: "Offer",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");
        }
    }
}
