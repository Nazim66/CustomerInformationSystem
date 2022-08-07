using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddCustomerModeltoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    LandPhone = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    PostOffice = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    Zilla = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
