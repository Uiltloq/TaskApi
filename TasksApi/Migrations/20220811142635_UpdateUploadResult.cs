using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksApi.Migrations
{
    public partial class UpdateUploadResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUploadResult");

            migrationBuilder.AlterColumn<string>(
                name: "StoredFileName",
                table: "UploadResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "UploadResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "UploadResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 11, 17, 26, 35, 653, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.CreateIndex(
                name: "IX_UploadResults_TaskId",
                table: "UploadResults",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadResults_Tasks_TaskId",
                table: "UploadResults",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadResults_Tasks_TaskId",
                table: "UploadResults");

            migrationBuilder.DropIndex(
                name: "IX_UploadResults_TaskId",
                table: "UploadResults");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "UploadResults");

            migrationBuilder.AlterColumn<string>(
                name: "StoredFileName",
                table: "UploadResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "UploadResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TaskUploadResult",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false),
                    UploadResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUploadResult", x => new { x.TasksId, x.UploadResultId });
                    table.ForeignKey(
                        name: "FK_TaskUploadResult_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUploadResult_UploadResults_UploadResultId",
                        column: x => x.UploadResultId,
                        principalTable: "UploadResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 10, 18, 19, 12, 724, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.CreateIndex(
                name: "IX_TaskUploadResult_UploadResultId",
                table: "TaskUploadResult",
                column: "UploadResultId");
        }
    }
}
