using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskApp.Migrations
{
    public partial class API : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 1, "Krystian", "Nowak" });

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 2, "Maciej", "Kowalski" });

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 3, "Zbigniew", "Czajka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCollections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 1, "Krystian", "Nowak" });

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 2, "Maciej", "Kowalski" });

            migrationBuilder.InsertData(
                table: "UserCollections",
                columns: new[] { "Id", "firstName", "lastName" },
                values: new object[] { 3, "Zbigniew", "Czajka" });
        }
    }
}
