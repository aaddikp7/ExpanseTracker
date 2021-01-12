using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpanseTracker.Migrations
{
    public partial class addFileNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Expenses",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Expenses");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "Expenses",
                type: "varbinary(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
