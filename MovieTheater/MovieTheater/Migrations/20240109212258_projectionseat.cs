using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Migrations
{
    /// <inheritdoc />
    public partial class projectionseat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ProjectionHalls_ProjectionHallId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ProjectionHallId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ProjectionHallId",
                table: "Seats");

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 12, 22, 22, 58, 586, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 14, 22, 22, 58, 586, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 10, 22, 22, 58, 586, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 13, 22, 22, 58, 586, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 16, 22, 22, 58, 586, DateTimeKind.Local).AddTicks(3490));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectionHallId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 12, 22, 0, 21, 616, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 14, 22, 0, 21, 616, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 10, 22, 0, 21, 616, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 13, 22, 0, 21, 616, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAndTimeOfProjecton",
                value: new DateTime(2024, 1, 16, 22, 0, 21, 616, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProjectionHallId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProjectionHallId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProjectionHallId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProjectionHallId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProjectionHallId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ProjectionHallId",
                table: "Seats",
                column: "ProjectionHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ProjectionHalls_ProjectionHallId",
                table: "Seats",
                column: "ProjectionHallId",
                principalTable: "ProjectionHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
