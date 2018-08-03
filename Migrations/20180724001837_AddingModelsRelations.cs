using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyWealth.Migrations
{
    public partial class AddingModelsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TickerSymbol",
                table: "Wealths");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TickerSymbol",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "TradeType",
                table: "Trades");

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Wealths",
                maxLength: 15,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransType",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "Trades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Trades",
                maxLength: 15,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Wealths_SymbolId",
                table: "Wealths",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SymbolId",
                table: "Trades",
                column: "SymbolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_TickerSymbols_SymbolId",
                table: "Trades",
                column: "SymbolId",
                principalTable: "TickerSymbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wealths_TickerSymbols_SymbolId",
                table: "Wealths",
                column: "SymbolId",
                principalTable: "TickerSymbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_TickerSymbols_SymbolId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Wealths_TickerSymbols_SymbolId",
                table: "Wealths");

            migrationBuilder.DropIndex(
                name: "IX_Wealths_SymbolId",
                table: "Wealths");

            migrationBuilder.DropIndex(
                name: "IX_Trades_SymbolId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Wealths");

            migrationBuilder.DropColumn(
                name: "TransType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Trades");

            migrationBuilder.AddColumn<string>(
                name: "TickerSymbol",
                table: "Wealths",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TickerSymbol",
                table: "Trades",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TradeType",
                table: "Trades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
