using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyWealth.Migrations
{
    public partial class ModelPropertyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Transactions",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Trades",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<int>(
                name: "ToAccount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromAccount",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Transactions",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Trades",
                newName: "TimeStamp");

            migrationBuilder.AlterColumn<string>(
                name: "ToAccount",
                table: "Transactions",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FromAccount",
                table: "Transactions",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
