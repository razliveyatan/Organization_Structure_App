using DAL.Types;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddValuesToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Random random = new Random();
            StringBuilder sqlBuilder = new StringBuilder();

            for (int i = 1; i <= 50; i++)
            {
                int CustomTaskId = i;
                int ManagerId = (random.Next(1, 10) != i) ? (random.Next(1, 10)) : (random.Next(1, 10));
                int EmployeeId = (random.Next(10, 20) != i) ? (random.Next(10, 20)) : (random.Next(10, 20));
                string CustomTaskText = $"CustomTaskText {i}";
                DateTime CustomTaskDueDate = DateTime.Now.AddDays(random.Next(11, 31));
                DateTime CustomTaskAssignDate = DateTime.Now.AddDays(random.Next(1, 10));

                sqlBuilder.AppendLine($"INSERT INTO CustomTasks (CustomTaskId, ManagerId, EmployeeId, CustomTaskText, CustomTaskDueDate, CustomTaskAssignDate) VALUES ({CustomTaskId}, {ManagerId}, {EmployeeId}, '{CustomTaskText}', '{CustomTaskDueDate:yyyy-MM-dd HH:mm:ss}', '{CustomTaskAssignDate:yyyy-MM-dd HH:mm:ss}');");
            }

            for (int i = 1; i <= 50; i++)
            {
                int ReportId = i;
                int ManagerId = (random.Next(1, 10) != i) ? (random.Next(1, 10)) : (random.Next(1, 10));
                int EmployeeId = (random.Next(10, 20) != i) ? (random.Next(10, 20)) : (random.Next(10, 20));
                string ReportText = $"ReportText {i}";
                int ReportStatus = (random.Next(1, 3));
                DateTime ReportDate = DateTime.Now.AddDays(random.Next(1, 31));

                sqlBuilder.AppendLine($"INSERT INTO Reports (ReportId, ManagerId, EmployeeId, ReportText, ReportStatus, ReportDate) VALUES ({ReportId}, {ManagerId}, {EmployeeId}, '{ReportText}',{ReportStatus}, '{ReportDate:yyyy-MM-dd HH:mm:ss}');");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
