using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnocaCase.Repository.Migrations
{
    public partial class editSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarrierConfiguration",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarrierCost",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Carriers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarrierPlusDesiCost",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 5, 9, 18, 43, 44, 999, DateTimeKind.Local).AddTicks(8089));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarrierConfiguration",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarrierCost",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Carriers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarrierPlusDesiCost",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 5, 9, 16, 2, 11, 955, DateTimeKind.Local).AddTicks(3474));
        }
    }
}
