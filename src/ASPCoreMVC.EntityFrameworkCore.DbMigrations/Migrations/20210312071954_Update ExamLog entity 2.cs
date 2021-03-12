﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPCoreMVC.Migrations
{
    public partial class UpdateExamLogentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoneScore",
                table: "ASPCoreMVC_ExamLog",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoneScore",
                table: "ASPCoreMVC_ExamLog");
        }
    }
}
