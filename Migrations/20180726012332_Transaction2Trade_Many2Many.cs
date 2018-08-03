using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyWealth.Migrations
{
    public partial class Transaction2Trade_Many2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactionrs_TradeId",
                table: "Transactionrs");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "Transactionrs");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactionrs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactionrs_TradeId",
                table: "Transactionrs",
                column: "TradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactionrs_TradeId",
                table: "Transactionrs");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactionrs");

            migrationBuilder.AddColumn<int>(
                name: "TransType",
                table: "Transactionrs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactionrs_TradeId",
                table: "Transactionrs",
                column: "TradeId",
                unique: true,
                filter: "[TradeId] IS NOT NULL");
        }
    }
}
