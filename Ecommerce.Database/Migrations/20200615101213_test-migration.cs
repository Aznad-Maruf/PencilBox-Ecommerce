using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApp.Migrations
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                            
                                 DELETE FROM Customers WHERE id = 3; 
                                 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
