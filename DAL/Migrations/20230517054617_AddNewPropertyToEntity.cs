using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Text;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyToEntity : Migration
    {


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            Random random = new Random();
            StringBuilder sqlBuilder = new StringBuilder();

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
                {sqlBuilder.ToString()};
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
                {sqlBuilder.ToString()};
            ");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Employees");
        }
    }
}
