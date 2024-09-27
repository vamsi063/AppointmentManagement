using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class seedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d6f3499-f5c6-4a3b-b6c5-d49c14f415ef", "2", "User", "User" },
                    { "97236806-0c69-4669-9b79-7b386c8c880b", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Hyderabad" },
                    { (byte)2, "Bangalore" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6f3499-f5c6-4a3b-b6c5-d49c14f415ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97236806-0c69-4669-9b79-7b386c8c880b");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: (byte)2);
        }
    }
}
