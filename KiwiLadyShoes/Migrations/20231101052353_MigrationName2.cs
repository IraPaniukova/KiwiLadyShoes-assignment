using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiLadyShoes.Migrations
{
    public partial class MigrationName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23ebadaf-bfaf-4971-a5d3-679c19809e56", "813f6b46-4e37-4583-bd29-1727d1342931", "Manager", "MANAGER" },
                    { "be579afc-cad8-4cf4-afb1-7237be813e01", "e4f96e94-ffcb-4170-90a6-ccb78dc01ee4", "Administrator", "ADMINISTRATOR" },
                    { "dd4650a0-b5a7-4f63-9a6c-0ac5c914965f", "c504f680-ef9f-4bd7-b7d9-693d59c5fd50", "Salesperson", "SALESPERSON" },
                    { "e28c0bd7-f57d-44f7-913b-9984686e3d5e", "9c81a138-5bab-416d-9630-4511bf2df528", "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0548a2e3-86f9-491c-9875-4874cc9bf698", 0, new DateTime(2023, 11, 1, 18, 23, 52, 586, DateTimeKind.Local).AddTicks(8304), "51ac23fb-d6d1-4250-bcc0-654b96bd9cf8", "salesperson@example.com", true, "salesperson", "salesperson", false, null, "SALESPERSON@EXAMPLE.COM", "SALESPERSON@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKxU1VN/nOGfE7msaZLeAHDwC85I8Mnhy8NbV6ZGy0M7sFbzjL6Oo/9SA8VDQBWR2A==", "0210888888", false, "357cd227-6e09-4fec-be76-acf63f1952c2", false, "salesperson@example.com" },
                    { "23b1433a-1a14-4cfc-952b-e155a6343eb8", 0, new DateTime(2023, 11, 1, 18, 23, 52, 586, DateTimeKind.Local).AddTicks(8315), "1c4091a7-0b09-47c6-a538-e2755dd2f5e2", "visitor@example.com", true, "visitor", "visitor", false, null, "VISITOR@EXAMPLE.COM", "VISITOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKKavqH0zDgsoZpVwYIS+kmMlndxNkE0wWkiRA59F01GuaHJSQsrGMC+tbXES2EUqw==", "0210888888", false, "b13c95b0-d26e-45d5-8145-3274c79ea2cf", false, "visitor@example.com" },
                    { "287ecbd5-f271-48c4-95fc-047019a2c7ff", 0, new DateTime(2023, 11, 1, 18, 23, 52, 586, DateTimeKind.Local).AddTicks(8244), "c5714837-a0c6-4d84-b329-0fe56491da62", "administrator@example.com", true, "Admin", "admin", false, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR@EXAMPLE.COM", "AQAAAAEAACcQAAAAEG2ePCbvWTHAF1gH2J89xLK5ZPsabfPrpNDef0JVAypGrApeBoyqOaRtTZn51f5VOg==", "0210888888", false, "9d306345-584a-4fd9-bfb0-b303cc5311a6", false, "administrator@example.com" },
                    { "ebc72d8e-0672-486c-a870-5deb6491d00b", 0, new DateTime(2023, 11, 1, 18, 23, 52, 586, DateTimeKind.Local).AddTicks(8292), "f5e2cf22-5889-4037-a08c-ea3e32c23d68", "manager@example.com", true, "manager", "manager", false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDahkMFyb7X/xycUrRObQF1HkDU44GZoJmcu5/ifUSp0tqLBeLG/o+LDAB0vtfdXVw==", "0210888888", false, "9ad819d5-1b9b-424b-af96-657e08f872b5", false, "manager@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dd4650a0-b5a7-4f63-9a6c-0ac5c914965f", "0548a2e3-86f9-491c-9875-4874cc9bf698" },
                    { "e28c0bd7-f57d-44f7-913b-9984686e3d5e", "23b1433a-1a14-4cfc-952b-e155a6343eb8" },
                    { "be579afc-cad8-4cf4-afb1-7237be813e01", "287ecbd5-f271-48c4-95fc-047019a2c7ff" },
                    { "23ebadaf-bfaf-4971-a5d3-679c19809e56", "ebc72d8e-0672-486c-a870-5deb6491d00b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dd4650a0-b5a7-4f63-9a6c-0ac5c914965f", "0548a2e3-86f9-491c-9875-4874cc9bf698" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e28c0bd7-f57d-44f7-913b-9984686e3d5e", "23b1433a-1a14-4cfc-952b-e155a6343eb8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be579afc-cad8-4cf4-afb1-7237be813e01", "287ecbd5-f271-48c4-95fc-047019a2c7ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23ebadaf-bfaf-4971-a5d3-679c19809e56", "ebc72d8e-0672-486c-a870-5deb6491d00b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23ebadaf-bfaf-4971-a5d3-679c19809e56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be579afc-cad8-4cf4-afb1-7237be813e01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd4650a0-b5a7-4f63-9a6c-0ac5c914965f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e28c0bd7-f57d-44f7-913b-9984686e3d5e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0548a2e3-86f9-491c-9875-4874cc9bf698");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23b1433a-1a14-4cfc-952b-e155a6343eb8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "287ecbd5-f271-48c4-95fc-047019a2c7ff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebc72d8e-0672-486c-a870-5deb6491d00b");

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
    }
}
