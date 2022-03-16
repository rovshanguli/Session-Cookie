using Microsoft.EntityFrameworkCore.Migrations;



namespace EntityFrameWork_MigrationLesson.Migrations
{
    public partial class AddImageColumnToExpertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Experts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Experts");
        }
    }
}
