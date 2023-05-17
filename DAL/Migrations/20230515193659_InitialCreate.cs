using System;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using DAL.Types;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomTasks",
                columns: table => new
                {
                    CustomTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomTaskText = table.Column<string>(type: "TEXT", nullable: false),
                    CustomTaskDueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomTaskAssignDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTasks", x => x.CustomTaskId);
                    table.ForeignKey(
                        name: "FK_CustomTasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomTasks_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportText = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomTasks_EmployeeId",
                table: "CustomTasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTasks_ManagerId",
                table: "CustomTasks",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ManagerId",
                table: "Reports",
                column: "ManagerId");
            Random random = new Random();
            StringBuilder sqlBuilder = new StringBuilder();

            for (int i = 1; i <= 50; i++)
            {
                string FirstName = $"First Name {i}";
                string LastName = $"Last Name {i}";
                int EmployeeId = i;
                string Position = $"Position {i}";
                string Address = $"Address {i}";
                string Phone = $"Phone {i}";
                string PictureUrl = $"PictureUrl {i}";
                int ManagerId = (RandomNumberGenerator.GetInt32(1, 10) != i) ? (random.Next(1, 10)) : (random.Next(1, 10));

                sqlBuilder.AppendLine($"SELECT '{FirstName}', '{LastName}','{PictureUrl}', '{EmployeeId}', '{Position}','{Address}','{Phone}','{ManagerId}'");

                // Add UNION ALL for all except the last entry
                if (i < 50)
                {
                    sqlBuilder.AppendLine("UNION ALL");
                }
            }
            migrationBuilder.Sql($@"
              INSERT INTO Employees (FirstName, LastName, EmployeeId, Position, Address, Phone, ManagerId, PictureUrl)
                {sqlBuilder.ToString()}
            ");

            for (int i = 0; i < 50; i++)
            {
                int ManagerId = (random.Next(1, 10) != i) ? (random.Next(1, 10)) : (random.Next(1, 10));
                int EmployeeId = (random.Next(10, 20) != i) ? (random.Next(10, 20)) : (random.Next(10, 20));
                string CustomTaskText = $"CustomTaskText {i}";
                DateTime CustomTaskDueDate = DateTime.Now.AddDays(random.Next(11, 31));
                DateTime CustomTaskAssignDate = DateTime.Now.AddDays(random.Next(1, 10));

                sqlBuilder.AppendLine($"SELECT '{ManagerId}', '{EmployeeId}', '{CustomTaskText}','{CustomTaskDueDate}','{CustomTaskAssignDate}'");
                // Add UNION ALL for all except the last entry
                if (i < 50)
                {
                    sqlBuilder.AppendLine("UNION ALL");
                }
                migrationBuilder.Sql($@"
              INSERT INTO CustomTasks (ManagerId, EmployeeId, CustomTaskText, CustomTaskDueDate, CustomTaskAssignDate)
                {sqlBuilder.ToString()}
            ");
            }

            for (int i = 0; i < 50; i++)
            {
                int ManagerId = (random.Next(1, 10) != i) ? (random.Next(1, 10)) : (random.Next(1, 10));
                int EmployeeId = (random.Next(10, 20) != i) ? (random.Next(10, 20)) : (random.Next(10, 20));
                string ReportText = $"ReportText {i}";
                int ReportStatus = (random.Next(1, 3));
                DateTime ReportDate = DateTime.Now.AddDays(random.Next(1, 31));

                sqlBuilder.AppendLine($"SELECT '{ManagerId}', '{EmployeeId}','{ReportText}','{ReportStatus}','{ReportDate}'");
                // Add UNION ALL for all except the last entry
                if (i < 50)
                {
                    sqlBuilder.AppendLine("UNION ALL");
                }
                migrationBuilder.Sql($@"
              INSERT INTO Reports (ManagerId, EmployeeId, ReportText, ReportStatus, ReportDate)
                {sqlBuilder.ToString()}
            ");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTasks");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Employees");
        }


    }
}
