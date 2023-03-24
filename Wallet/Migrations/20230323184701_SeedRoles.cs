using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallet.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into aspnetroles values(1, 'User', 'User', 'UserStamp1')");
            migrationBuilder.Sql("insert into aspnetroles values(2, 'Admin', 'Admin', 'AdminStamp1')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete aspnetroles");
        }
    }
}
