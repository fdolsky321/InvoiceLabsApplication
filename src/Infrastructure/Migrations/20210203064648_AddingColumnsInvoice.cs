using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddingColumnsInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("bcc6c5c0-ab74-4c4b-9415-2e21b15ba53e"),
                columns: new[] { "CreatedAt", "CreatedBy", "InvoiceDate", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2021, 2, 3, 7, 46, 47, 330, DateTimeKind.Local).AddTicks(8634), "Frantisek Dolsky", new DateTime(2021, 2, 3, 7, 46, 47, 328, DateTimeKind.Local).AddTicks(1172), new DateTime(2021, 2, 3, 7, 46, 47, 331, DateTimeKind.Local).AddTicks(490), "Frantisek Dolsky" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("bcc6c5c0-ab74-4c4b-9415-2e21b15ba53e"),
                columns: new[] { "CreatedAt", "CreatedBy", "InvoiceDate", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2021, 2, 3, 7, 30, 55, 803, DateTimeKind.Local).AddTicks(9820), null, new DateTime(2021, 2, 3, 7, 30, 55, 799, DateTimeKind.Local).AddTicks(7871), null, null });
        }
    }
}
