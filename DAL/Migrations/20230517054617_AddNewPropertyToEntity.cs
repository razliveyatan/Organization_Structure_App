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
                 name: "ManagerFullName",
                 table: "Employees",
                  type: "TEXT",
                  nullable: false,
                  defaultValue: "");
            migrationBuilder.AddColumn<bool>(
                 name: "IsManager",
                 table: "Employees",                 
                  nullable: false,
                  defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.DropColumn(
               name: "ManagerFullName",
               table: "Employees");
            migrationBuilder.DropColumn(
               name: "IsManager",
               table: "Employees");
        }
    }
}
