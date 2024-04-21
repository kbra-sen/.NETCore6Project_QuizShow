using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizShow.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReleationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_PointID",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PointID",
                table: "Questions",
                column: "PointID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_PointID",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PointID",
                table: "Questions",
                column: "PointID",
                unique: true);
        }
    }
}
