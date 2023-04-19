using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhiasAmooz.DataLayer.Migrations
{
    public partial class mig_fixWalletType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "WalletTypeTypeId",
                table: "Wallets",
                newName: "WalletTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_WalletTypeTypeId",
                table: "Wallets",
                newName: "IX_Wallets_WalletTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets",
                column: "WalletTypeId",
                principalTable: "WalletTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "WalletTypeId",
                table: "Wallets",
                newName: "WalletTypeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_WalletTypeId",
                table: "Wallets",
                newName: "IX_Wallets_WalletTypeTypeId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                table: "Wallets",
                column: "WalletTypeTypeId",
                principalTable: "WalletTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
