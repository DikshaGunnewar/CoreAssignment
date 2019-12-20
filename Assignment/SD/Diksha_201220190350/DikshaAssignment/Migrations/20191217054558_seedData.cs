using Microsoft.EntityFrameworkCore.Migrations;

namespace DikshaAssignment.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "CompanyName", "Designation", "EmailId", "FirstName", "LastName", "Salary", "isActive" },
                values: new object[,]
                {
                    { 1, "New York", "XYZ Inc", "Developer", "john@yopmail.com", "John", "Watson", 30000f, true },
                    { 2, "North America", "Test Inc", "QA", "elena@yopmail.com", "Elena", "Snowball", 50000f, true },
                    { 3, "South America", "ABC Inc", "Deveploer", "tom@yopmail.com", "Tom", "William", 40000f, true },
                    { 4, "London", "Lol Inc", "UI Developer", "suzi@yopmail.com", "Suzi", "Cook", 35000f, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);
        }
    }
}
