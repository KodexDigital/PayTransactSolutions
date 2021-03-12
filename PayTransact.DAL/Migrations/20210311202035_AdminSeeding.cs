using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayTransact.Persistence.Migrations
{
    public partial class AdminSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36E00FD4-F329-40EA-AD28-2C326721A9BD", "36E00FD4-F329-40EA-AD28-2C326721A9BD", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "D15B65B9-7702-4AD8-882F-93BDB8D19500", 0, "59c81077-f736-4123-af79-c3b2cc6f69d0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kodexkenth@gmail.com", false, "Super", " ", "Admin", false, null, "kodexkenth@gmail.com", "kodexkenth@gmail.com", "AQAAAAEAACcQAAAAEAhisJBKJkv/dUvZwEQz9RF9N+NKc9HUHfmoORNuTVEyoJUtdL7rGdRntK1HOd10Lw==", null, false, "a98f01cc-dc4b-4602-83ca-fb81d8fc2633", false, "kodexkenth@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "36E00FD4-F329-40EA-AD28-2C326721A9BD", "D15B65B9-7702-4AD8-882F-93BDB8D19500" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "36E00FD4-F329-40EA-AD28-2C326721A9BD", "D15B65B9-7702-4AD8-882F-93BDB8D19500" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36E00FD4-F329-40EA-AD28-2C326721A9BD");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D15B65B9-7702-4AD8-882F-93BDB8D19500");
        }
    }
}
