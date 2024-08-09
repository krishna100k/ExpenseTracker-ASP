﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class newlending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Lendings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Lendings_UserId",
                table: "Lendings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lendings_Users_UserId",
                table: "Lendings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lendings_Users_UserId",
                table: "Lendings");

            migrationBuilder.DropIndex(
                name: "IX_Lendings_UserId",
                table: "Lendings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lendings");
        }
    }
}
