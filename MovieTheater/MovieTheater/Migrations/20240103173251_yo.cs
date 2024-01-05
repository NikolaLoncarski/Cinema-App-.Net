using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class yo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTickets_Users_UserId",
                table: "MovieTickets");

            migrationBuilder.DropIndex(
                name: "IX_MovieTickets_UserId",
                table: "MovieTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieTickets");

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 6, 18, 32, 50, 853, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 8, 18, 32, 50, 853, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 4, 18, 32, 50, 853, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 7, 18, 32, 50, 853, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 10, 18, 32, 50, 853, DateTimeKind.Local).AddTicks(628));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 6, 18, 17, 28, 995, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 8, 18, 17, 28, 995, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 4, 18, 17, 28, 995, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 7, 18, 17, 28, 995, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 10, 18, 17, 28, 995, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.CreateIndex(
                name: "IX_MovieTickets_UserId",
                table: "MovieTickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTickets_Users_UserId",
                table: "MovieTickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
