using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class addInstructorCourseManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Inst_Course_ID",
                table: "Course_Inst",
                column: "Course_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Inst_Courses_Course_ID",
                table: "Course_Inst",
                column: "Course_ID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Inst_Instructors_Ins_ID",
                table: "Course_Inst",
                column: "Ins_ID",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Inst_Courses_Course_ID",
                table: "Course_Inst");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Inst_Instructors_Ins_ID",
                table: "Course_Inst");

            migrationBuilder.DropIndex(
                name: "IX_Course_Inst_Course_ID",
                table: "Course_Inst");
        }
    }
}
