﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientServer.Migrations
{
    public partial class ChangesNameConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Accounts_AccountGuid",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_RoleGuid",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employees_Guid",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_EmployeeGuid",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomGuid",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Employees_Guid",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_UniversityGuid",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "tb_m_universities");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "tb_m_rooms");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "tb_m_employees");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "tb_m_educations");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "tb_tr_bookings");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "AccountRoles",
                newName: "tb_tr_account_roles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_universities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "tb_m_universities",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_universities",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_universities",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_universities",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_rooms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "tb_m_rooms",
                newName: "floor");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "tb_m_rooms",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_rooms",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_rooms",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "ModifiedTime",
                table: "tb_m_rooms",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_m_roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_roles",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "NIK",
                table: "tb_m_employees",
                newName: "nik");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "tb_m_employees",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_m_employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_employees",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "tb_m_employees",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_employees",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "tb_m_employees",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "HiringDate",
                table: "tb_m_employees",
                newName: "hiring_date");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "tb_m_employees",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_employees",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "tb_m_employees",
                newName: "birth_date");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_NIK_Email_PhoneNumber",
                table: "tb_m_employees",
                newName: "IX_tb_m_employees_nik_email_phone_number");

            migrationBuilder.RenameColumn(
                name: "Major",
                table: "tb_m_educations",
                newName: "major");

            migrationBuilder.RenameColumn(
                name: "GPA",
                table: "tb_m_educations",
                newName: "gpa");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "tb_m_educations",
                newName: "degree");

            migrationBuilder.RenameColumn(
                name: "UniversityGuid",
                table: "tb_m_educations",
                newName: "university_guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_educations",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_educations",
                newName: "created_time");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_UniversityGuid",
                table: "tb_m_educations",
                newName: "IX_tb_m_educations_university_guid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tb_tr_bookings",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "tb_tr_bookings",
                newName: "remarks");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_tr_bookings",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "tb_tr_bookings",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "RoomGuid",
                table: "tb_tr_bookings",
                newName: "room_guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_tr_bookings",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "tb_tr_bookings",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "EmployeeGuid",
                table: "tb_tr_bookings",
                newName: "employee_guid");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_tr_bookings",
                newName: "created_time");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomGuid",
                table: "tb_tr_bookings",
                newName: "IX_tb_tr_bookings_room_guid");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EmployeeGuid",
                table: "tb_tr_bookings",
                newName: "IX_tb_tr_bookings_employee_guid");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tb_m_accounts",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "OTP",
                table: "tb_m_accounts",
                newName: "otp");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_m_accounts",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_m_accounts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "tb_m_accounts",
                newName: "is_used");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "tb_m_accounts",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "ExpiredTime",
                table: "tb_m_accounts",
                newName: "expired_time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_m_accounts",
                newName: "created_time");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "tb_tr_account_roles",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "tb_tr_account_roles",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tb_tr_account_roles",
                newName: "created_time");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRoles_RoleGuid",
                table: "tb_tr_account_roles",
                newName: "IX_tb_tr_account_roles_RoleGuid");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRoles_AccountGuid",
                table: "tb_tr_account_roles",
                newName: "IX_tb_tr_account_roles_AccountGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_account_roles",
                table: "tb_tr_account_roles",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_guid",
                table: "tb_m_accounts",
                column: "guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_educations_tb_m_employees_Guid",
                table: "tb_m_educations",
                column: "Guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_guid",
                table: "tb_m_educations",
                column: "university_guid",
                principalTable: "tb_m_universities",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_AccountGuid",
                table: "tb_tr_account_roles",
                column: "AccountGuid",
                principalTable: "tb_m_accounts",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_RoleGuid",
                table: "tb_tr_account_roles",
                column: "RoleGuid",
                principalTable: "tb_m_roles",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_bookings_tb_m_employees_employee_guid",
                table: "tb_tr_bookings",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_bookings_tb_m_rooms_room_guid",
                table: "tb_tr_bookings",
                column: "room_guid",
                principalTable: "tb_m_rooms",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_guid",
                table: "tb_m_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_educations_tb_m_employees_Guid",
                table: "tb_m_educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_guid",
                table: "tb_m_educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_AccountGuid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_RoleGuid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_bookings_tb_m_employees_employee_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_bookings_tb_m_rooms_room_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_bookings",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_account_roles",
                table: "tb_tr_account_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_employees",
                table: "tb_m_employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "tb_tr_bookings",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "tb_tr_account_roles",
                newName: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "tb_m_universities",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "tb_m_rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tb_m_employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "tb_m_educations",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Bookings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "Bookings",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Bookings",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "room_guid",
                table: "Bookings",
                newName: "RoomGuid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Bookings",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Bookings",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "employee_guid",
                table: "Bookings",
                newName: "EmployeeGuid");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Bookings",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_bookings_room_guid",
                table: "Bookings",
                newName: "IX_Bookings_RoomGuid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_bookings_employee_guid",
                table: "Bookings",
                newName: "IX_Bookings_EmployeeGuid");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "AccountRoles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "AccountRoles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "AccountRoles",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_account_roles_RoleGuid",
                table: "AccountRoles",
                newName: "IX_AccountRoles_RoleGuid");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_account_roles_AccountGuid",
                table: "AccountRoles",
                newName: "IX_AccountRoles_AccountGuid");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Universities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Universities",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Universities",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Universities",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Universities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Rooms",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "floor",
                table: "Rooms",
                newName: "Floor");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Rooms",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Rooms",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Rooms",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Rooms",
                newName: "ModifiedTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Roles",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Roles",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Roles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "nik",
                table: "Employees",
                newName: "NIK");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Employees",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Employees",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Employees",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Employees",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "hiring_date",
                table: "Employees",
                newName: "HiringDate");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Employees",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Employees",
                newName: "BirthDate");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_employees_nik_email_phone_number",
                table: "Employees",
                newName: "IX_Employees_NIK_Email_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "major",
                table: "Educations",
                newName: "Major");

            migrationBuilder.RenameColumn(
                name: "gpa",
                table: "Educations",
                newName: "GPA");

            migrationBuilder.RenameColumn(
                name: "degree",
                table: "Educations",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "university_guid",
                table: "Educations",
                newName: "UniversityGuid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Educations",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Educations",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_educations_university_guid",
                table: "Educations",
                newName: "IX_Educations_UniversityGuid");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "otp",
                table: "Accounts",
                newName: "OTP");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "Accounts",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Accounts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "is_used",
                table: "Accounts",
                newName: "IsUsed");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Accounts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "expired_time",
                table: "Accounts",
                newName: "ExpiredTime");

            migrationBuilder.RenameColumn(
                name: "created_time",
                table: "Accounts",
                newName: "CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Accounts_AccountGuid",
                table: "AccountRoles",
                column: "AccountGuid",
                principalTable: "Accounts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_RoleGuid",
                table: "AccountRoles",
                column: "RoleGuid",
                principalTable: "Roles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employees_Guid",
                table: "Accounts",
                column: "Guid",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_EmployeeGuid",
                table: "Bookings",
                column: "EmployeeGuid",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomGuid",
                table: "Bookings",
                column: "RoomGuid",
                principalTable: "Rooms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Employees_Guid",
                table: "Educations",
                column: "Guid",
                principalTable: "Employees",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_UniversityGuid",
                table: "Educations",
                column: "UniversityGuid",
                principalTable: "Universities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
