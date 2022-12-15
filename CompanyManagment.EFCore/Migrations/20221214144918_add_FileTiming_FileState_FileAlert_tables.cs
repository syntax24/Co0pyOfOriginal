using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagment.EFCore.Migrations
{
    public partial class add_FileTiming_FileState_FileAlert_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File_Timings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deadline = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tips = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Timings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "File_States",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    FileTiming_Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_States", x => x.id);
                    table.ForeignKey(
                        name: "FK_File_States_File_Timings_FileTiming_Id",
                        column: x => x.FileTiming_Id,
                        principalTable: "File_Timings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_Alerts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File_Id = table.Column<long>(type: "bigint", nullable: false),
                    FileState_Id = table.Column<long>(type: "bigint", nullable: false),
                    AdditionalDeadline = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Alerts", x => x.id);
                    table.ForeignKey(
                        name: "FK_File_Alerts_File_States_FileState_Id",
                        column: x => x.FileState_Id,
                        principalTable: "File_States",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Alerts_Files_File_Id",
                        column: x => x.File_Id,
                        principalTable: "Files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "File_Timings",
                columns: new[] { "id", "CreationDate", "Deadline", "Tips", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 12, 14, 18, 19, 16, 901, DateTimeKind.Local).AddTicks(1160), 1, "	پس از مراجعه موکل و ثبت اولیه پرونده در نرم افزار ، در صورتی که تا پایان زمان مندرج در کادر ، موکل پرونده را تعیین و تکلیف ننماید و شما قادر به ورود به پرونده نباشید ، نرم افزار به شما گزارش میدهد . ", "ثبت اولیه در سیستم" },
                    { 2L, new DateTime(2022, 12, 14, 18, 19, 16, 909, DateTimeKind.Local).AddTicks(9236), 1, "	پس از ارائه دادخواست توسط شما یا موکل ، اگر تا پایان مهلت مندرج در این کادر ، دعوتنامه ای صادر نشده باشد ، نرم افزار به شما گزارش میدهد . ", "انتظار برای دریافت دعوتنامه اول" },
                    { 3L, new DateTime(2022, 12, 14, 18, 19, 16, 909, DateTimeKind.Local).AddTicks(9360), 1, "	پس از شرکت در جلسه اول رسیدگی ، اگر تا پایان مهلت مندرج در کادر ، دعوتنامه جدید یا دادنامه صادر نشده باشد ، نرم افزار به شما گزارش میدهد . ", "انتظار برای دریافت دعوتنامه دوم به بعد یا دادنامه" },
                    { 4L, new DateTime(2022, 12, 14, 18, 19, 16, 909, DateTimeKind.Local).AddTicks(9375), 1, "	پس از صدور دادنامه ، تا قبل از پایان مدت اعتراض مندرج در کادر ، اخطار مهلت اعتراض را نرم افزار به شما گزارش میدهد تا در فرصت مقرر اقدام به ثبت اعتراض نمائید . بدیهیست در صورت عدم ثبت اعتراض در مهلت مقرر دادنامه شما قطعی خواهد شد . ", "مهلت اعتراض به دادنامه" },
                    { 5L, new DateTime(2022, 12, 14, 18, 19, 16, 909, DateTimeKind.Local).AddTicks(9384), 1, "پس از ثبت اعتراض ، در صورتی که تا پایان مهلت مندرج در کادر ، دعوتنامه ای برای شما صادر نگردد ، نرم افزار به شما گزارش میدهد . ", "انتظار برای دریافت دعوتنامه پس از اعتراض" },
                    { 6L, new DateTime(2022, 12, 14, 18, 19, 16, 909, DateTimeKind.Local).AddTicks(9394), 1, "پس از شرکت در جلسه اول رسیدگی ، اگر تا پایان مهلت مندرج در کادر ، دعوتنامه جدید یا دادنامه صادر نشده باشد ، نرم افزار به شما گزارش میدهد .", "انتظار برای دریافت دعوتنامه دوم به بعد یا دادنامه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_Alerts_File_Id",
                table: "File_Alerts",
                column: "File_Id");

            migrationBuilder.CreateIndex(
                name: "IX_File_Alerts_FileState_Id",
                table: "File_Alerts",
                column: "FileState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_File_States_FileTiming_Id",
                table: "File_States",
                column: "FileTiming_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_Alerts");

            migrationBuilder.DropTable(
                name: "File_States");

            migrationBuilder.DropTable(
                name: "File_Timings");
        }
    }
}
