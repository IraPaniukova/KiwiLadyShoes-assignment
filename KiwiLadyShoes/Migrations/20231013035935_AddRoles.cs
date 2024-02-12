using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiLadyShoes.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2965d307-de8e-4917-96b2-5aa40dce3f83", "f47a3a67-b270-4651-b638-ab023b260648", "Salesperson", "SALESPERSON" },
                    { "3d673303-1204-487b-8428-c1aa60346921", "a1dd3e5b-f8f1-45a8-8105-06883818a288", "Administrator", "ADMINISTRATOR" },
                    { "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c", "dc0a117f-5dc8-4f65-b13e-28517a987bd9", "Manager", "MANAGER" },
                    { "cc691c8c-d7ab-43b4-af45-b001e1a7af8c", "2d638904-7d5f-4dde-9df3-b06bb882e2a6", "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "59dc85ee-dc82-4815-b667-91fe4a5764d8", 0, new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5435), "654b7d95-fd83-4183-bc22-3bd45d63fe11", "visitor@example.com", true, "visitor", "visitor", false, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDIvwcZFQECgqMqRiErpfvZKhlqJnk5kpZzojrquLw8oyJ0gYSKQTidh9TEvcIS7hA==", "0210888888", false, "345b520a-21b7-4257-8fe4-9ebc00358542", false, "visitor@example.com" },
                    { "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7", 0, new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5411), "4be77d31-6981-48a3-81bb-e021f266c716", "manager@example.com", true, "manager", "manager", false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEN+TLucPAaWi8IFY7QBXzB9k31Liu+teQPo+SfhogJa8gM+S4cNJ48AYyaLZYLXRag==", "0210888888", false, "5250b0d9-eab2-4f53-ae18-5c938a928b74", false, "manager@example.com" },
                    { "825ddba5-4393-44de-849c-b655151fda95", 0, new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5422), "106a06da-8511-4401-b93c-e7dafb3891ff", "salesperson@example.com", true, "salesperson", "salesperson", false, null, "SALESPERSON@EXAMPLE.COM", "SALESPERSON@EXAMPLE.COM", "AQAAAAEAACcQAAAAEA+lJrjkQP6ibD8RMlRNKXNbF/L8JqV1aqofdwziNO9boG/qBKT2o+i3C/eoiOWEmQ==", "0210888888", false, "16281fca-2b6e-47e3-b4fe-377357bc47a6", false, "salesperson@example.com" },
                    { "c3f95308-0d7e-4125-80ac-94b75420a0e6", 0, new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5365), "ceebcfdb-4539-401a-935f-9fa2bac6359e", "administrator@example.com", true, "Admin", "admin", false, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAENSFJIBJGi2PmFCImRcrtKQRRxJ3jbSIS2f/VKKrajP74SIGttwoqQTPZIGcw4czdw==", "0210888888", false, "b5f95908-bbb9-4c0a-ac84-bd4a3cd1e5f8", false, "administrator@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc691c8c-d7ab-43b4-af45-b001e1a7af8c", "59dc85ee-dc82-4815-b667-91fe4a5764d8" },
                    { "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c", "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7" },
                    { "2965d307-de8e-4917-96b2-5aa40dce3f83", "825ddba5-4393-44de-849c-b655151fda95" },
                    { "3d673303-1204-487b-8428-c1aa60346921", "c3f95308-0d7e-4125-80ac-94b75420a0e6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc691c8c-d7ab-43b4-af45-b001e1a7af8c", "59dc85ee-dc82-4815-b667-91fe4a5764d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c", "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2965d307-de8e-4917-96b2-5aa40dce3f83", "825ddba5-4393-44de-849c-b655151fda95" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d673303-1204-487b-8428-c1aa60346921", "c3f95308-0d7e-4125-80ac-94b75420a0e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2965d307-de8e-4917-96b2-5aa40dce3f83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d673303-1204-487b-8428-c1aa60346921");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc691c8c-d7ab-43b4-af45-b001e1a7af8c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59dc85ee-dc82-4815-b667-91fe4a5764d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "825ddba5-4393-44de-849c-b655151fda95");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3f95308-0d7e-4125-80ac-94b75420a0e6");
        }
    }
}
