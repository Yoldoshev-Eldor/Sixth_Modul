using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimbleCar.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TableChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Car_CarID1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CarID1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CarID1",
                table: "Reviews",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarID1",
                table: "Reviews",
                column: "CarID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Car_CarID1",
                table: "Reviews",
                column: "CarID1",
                principalTable: "Car",
                principalColumn: "CarID");
        }
    }
}
