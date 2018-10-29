using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "giftCardId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "percentCardId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sumSaleId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SumSale",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SumSale", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_giftCardId",
                table: "Orders",
                column: "giftCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_percentCardId",
                table: "Orders",
                column: "percentCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_sumSaleId",
                table: "Orders",
                column: "sumSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GiftCards_giftCardId",
                table: "Orders",
                column: "giftCardId",
                principalTable: "GiftCards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PercentCards_percentCardId",
                table: "Orders",
                column: "percentCardId",
                principalTable: "PercentCards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SumSale_sumSaleId",
                table: "Orders",
                column: "sumSaleId",
                principalTable: "SumSale",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GiftCards_giftCardId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PercentCards_percentCardId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SumSale_sumSaleId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "SumSale");

            migrationBuilder.DropIndex(
                name: "IX_Orders_giftCardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_percentCardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_sumSaleId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "giftCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "percentCardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "sumSaleId",
                table: "Orders");
        }
    }
}
