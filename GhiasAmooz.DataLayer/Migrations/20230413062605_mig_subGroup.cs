using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhiasAmooz.DataLayer.Migrations
{
    public partial class mig_subGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubGroupId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubGroupId",
                table: "Courses",
                column: "SubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_SubGroupId",
                table: "Courses",
                column: "SubGroupId",
                principalTable: "CourseGroups",
                principalColumn: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_SubGroupId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SubGroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SubGroupId",
                table: "Courses");
        }
    }
}
