using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksApi.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "В работе" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "На тестировании" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Готово" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Date", "Name", "StatusId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Баг номер 1", 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Date", "Name", "StatusId" },
                values: new object[] { 2, new DateTime(2022, 8, 10, 18, 19, 12, 724, DateTimeKind.Local).AddTicks(3869), "Баг номер 2", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
