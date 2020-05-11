﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerApp.Infrastructure.Migrations
{
    public partial class SecondMigrationSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brewers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Achouffe" },
                    { 3, "Abbaye Notre-Dame de Scourmont" }
                });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HappyHour" },
                    { 2, "GetDrunk" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholLevel", "BrewerId", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 7.5, 2, true, "Chouffe", 3.1000000000000001 },
                    { 4, 8.8000000000000007, 3, true, "Chimay Bleue", 3.0 },
                    { 5, 7.9000000000000004, 3, true, "Chimay Brune", 2.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "WholesalerBeer",
                columns: new[] { "BeerId", "WholesalerId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 38 },
                    { 2, 1, 18 },
                    { 1, 2, 12 },
                    { 2, 2, 21 }
                });

            migrationBuilder.InsertData(
                table: "WholesalerBeer",
                columns: new[] { "BeerId", "WholesalerId", "Stock" },
                values: new object[,]
                {
                    { 3, 1, 5 },
                    { 3, 2, 18 },
                    { 4, 2, 12 },
                    { 5, 1, 16 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "WholesalerBeer",
                keyColumns: new[] { "BeerId", "WholesalerId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brewers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
