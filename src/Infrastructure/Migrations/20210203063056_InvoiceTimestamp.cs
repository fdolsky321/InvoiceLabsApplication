using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InvoiceTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Invoices",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("bcc6c5c0-ab74-4c4b-9415-2e21b15ba53e"),
                columns: new[] { "CreatedAt", "InvoiceDate" },
                values: new object[] { new DateTime(2021, 2, 3, 7, 30, 55, 803, DateTimeKind.Local).AddTicks(9820), new DateTime(2021, 2, 3, 7, 30, 55, 799, DateTimeKind.Local).AddTicks(7871) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("bcc6c5c0-ab74-4c4b-9415-2e21b15ba53e"),
                column: "InvoiceDate",
                value: new DateTime(2020, 11, 30, 8, 18, 30, 245, DateTimeKind.Local).AddTicks(6324));
        }
    }
}
