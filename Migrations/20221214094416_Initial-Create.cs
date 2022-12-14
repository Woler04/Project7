using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project7.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirsstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TaskListModel",
                columns: table => new
                {
                    TaskListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskListTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskListModel", x => x.TaskListId);
                    table.ForeignKey(
                        name: "FK_TaskListModel_UserModel_UserModelUserId",
                        column: x => x.UserModelUserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TaskModel",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskListId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskListModelTaskListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModel", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskModel_TaskListModel_TaskListModelTaskListId",
                        column: x => x.TaskListModelTaskListId,
                        principalTable: "TaskListModel",
                        principalColumn: "TaskListId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskListModel_UserModelUserId",
                table: "TaskListModel",
                column: "UserModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_TaskListModelTaskListId",
                table: "TaskModel",
                column: "TaskListModelTaskListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskModel");

            migrationBuilder.DropTable(
                name: "TaskListModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
