using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission08_Team12.Migrations
{
    public partial class AddedQuadrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quadrant",
                table: "ToDo",
                newName: "QuadrantId");

            migrationBuilder.CreateTable(
                name: "Quadrants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuadrantName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "Id", "QuadrantName" },
                values: new object[] { 1, "Urgent/Important" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "Id", "QuadrantName" },
                values: new object[] { 2, "Urgent/Not Important" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "Id", "QuadrantName" },
                values: new object[] { 3, "Not Urgent/Important" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "Id", "QuadrantName" },
                values: new object[] { 4, "Not Urgent/Not Important" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_QuadrantId",
                table: "ToDo",
                column: "QuadrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Quadrants_QuadrantId",
                table: "ToDo",
                column: "QuadrantId",
                principalTable: "Quadrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Quadrants_QuadrantId",
                table: "ToDo");

            migrationBuilder.DropTable(
                name: "Quadrants");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_QuadrantId",
                table: "ToDo");

            migrationBuilder.RenameColumn(
                name: "QuadrantId",
                table: "ToDo",
                newName: "Quadrant");
        }
    }
}
