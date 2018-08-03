using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyWealth.Migrations
{
    public partial class Transaction2Trade_Many2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TradeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TradeId",
                table: "Transactions",
                column: "TradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_TradeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransType",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TradeId",
                table: "Transactions",
                column: "TradeId",
                unique: true,
                filter: "[TradeId] IS NOT NULL");
        }
    }
}
