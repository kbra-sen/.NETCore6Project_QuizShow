using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizShow.Migrations
{
    /// <inheritdoc />
    public partial class RemovePointOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointsID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PointOrders_Points_PointsID",
                        column: x => x.PointsID,
                        principalTable: "Points",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointOrders_PointsID",
                table: "PointOrders",
                column: "PointsID");
        }
    }
}
