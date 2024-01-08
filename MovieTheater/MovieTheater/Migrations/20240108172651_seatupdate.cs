using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class seatupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 11, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 13, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 9, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 12, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 15, 18, 26, 51, 179, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "Reserved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "Reserved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Seats");

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
    }
}
