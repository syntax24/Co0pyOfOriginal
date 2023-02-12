using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_TaskManager_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTitles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTitles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commander_Id = table.Column<long>(type: "bigint", nullable: false),
                    SeniorUser_Id = table.Column<long>(type: "bigint", nullable: false),
                    ReferralRecipient_Id = table.Column<long>(type: "bigint", nullable: false),
                    TaskTitle_Id = table.Column<long>(type: "bigint", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Id = table.Column<long>(type: "bigint", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTitles_TaskTitle_Id",
                        column: x => x.TaskTitle_Id,
                        principalTable: "TaskTitles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadlineExnsion = table.Column<int>(type: "int", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Impossibility = table.Column<int>(type: "int", nullable: false),
                    ImpossibilityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImpossibilityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Done = table.Column<int>(type: "int", nullable: false),
                    DoneTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Task_Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskStatuses_Tasks_Task_Id",
                        column: x => x.Task_Id,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 978, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 981, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 19, 11, 29, 14, 983, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTitle_Id",
                table: "Tasks",
                column: "TaskTitle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatuses_Task_Id",
                table: "TaskStatuses",
                column: "Task_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTitles");

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 336, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 342, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2825));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2022, 12, 31, 10, 39, 29, 347, DateTimeKind.Local).AddTicks(2846));
        }
    }
}
