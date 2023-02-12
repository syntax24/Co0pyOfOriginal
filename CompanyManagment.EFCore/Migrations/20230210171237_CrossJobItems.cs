using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class CrossJobItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CrossJobs");

            migrationBuilder.CreateTable(
                name: "CrossJobItems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrossJobId = table.Column<long>(type: "bigint", nullable: false),
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossJobItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CrossJobItems_CrossJobs_CrossJobId",
                        column: x => x.CrossJobId,
                        principalTable: "CrossJobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrossJobItems_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 479, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 481, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 2, 10, 20, 42, 36, 483, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.CreateIndex(
                name: "IX_CrossJobItems_CrossJobId",
                table: "CrossJobItems",
                column: "CrossJobId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossJobItems_JobId",
                table: "CrossJobItems",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrossJobItems");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CrossJobs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 168, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 7L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "File_States",
                keyColumn: "id",
                keyValue: 8L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 171, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "File_Timings",
                keyColumn: "id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 1, 29, 18, 45, 18, 172, DateTimeKind.Local).AddTicks(9448));
        }
    }
}
