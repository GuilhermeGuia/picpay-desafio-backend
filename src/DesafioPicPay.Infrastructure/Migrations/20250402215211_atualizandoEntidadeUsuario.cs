using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPicPay.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoEntidadeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.RenameColumn(
                name: "PayerId",
                table: "Transfer",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "Payee",
                table: "Transfer",
                newName: "ReciverId");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "User",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Transfer",
                newName: "PayerId");

            migrationBuilder.RenameColumn(
                name: "ReciverId",
                table: "Transfer",
                newName: "Payee");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_OwnerId",
                table: "Account",
                column: "OwnerId");
        }
    }
}
