using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class Outstanding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Outstanding",
                table: "Todo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_PersonId",
                table: "Todo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentId",
                table: "Person",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Person_PersonId",
                table: "Todo",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Person_PersonId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_PersonId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Person_DepartmentId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Outstanding",
                table: "Todo");
        }
    }
}
