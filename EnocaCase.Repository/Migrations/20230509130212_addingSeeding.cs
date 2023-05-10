using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnocaCase.Repository.Migrations
{
    public partial class addingSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "Id", "CarrierIsActive", "CarrierName", "CarrierPlusDesiCost" },
                values: new object[] { 1, true, "MNG", 32 });

            migrationBuilder.InsertData(
                table: "CarrierConfiguration",
                columns: new[] { "Id", "CarrierCost", "CarrierId", "CarrierMaxDesi", "CarrierMinDesi" },
                values: new object[] { 1, 4, 1, 10, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarrierId", "OrderCarrierCost", "OrderDate", "OrderDesi" },
                values: new object[] { 1, 1, 44m, new DateTime(2023, 5, 9, 16, 2, 11, 955, DateTimeKind.Local).AddTicks(3474), 13 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarrierConfiguration",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carriers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
