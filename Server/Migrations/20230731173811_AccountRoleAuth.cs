using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientServer.Migrations
{
    public partial class AccountRoleAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_time", "modified_date", "name" },
                values: new object[] { new Guid("4887ec13-b482-47b3-9b24-08db91a71770"), new DateTime(2023, 8, 1, 0, 38, 11, 643, DateTimeKind.Local).AddTicks(5580), new DateTime(2023, 8, 1, 0, 38, 11, 643, DateTimeKind.Local).AddTicks(5589), "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("4887ec13-b482-47b3-9b24-08db91a71770"));
        }
    }
}
