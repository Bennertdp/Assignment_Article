using Microsoft.EntityFrameworkCore.Migrations;
using OfficeOpenXml;
using System;
using System.IO;

#nullable disable

namespace Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Data", "Excel"));
            string fileName = "DataExcel.xlsx";
            string excelFilePath = Path.Combine(basePath, fileName);

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Articles"];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    int articleId = Convert.ToInt32(worksheet.Cells[row, 1].Value);
                    int content = Convert.ToInt32(worksheet.Cells[row, 2].Value);
                    string unit = worksheet.Cells[row, 3].Value.ToString();

                    migrationBuilder.InsertData(
                        table: "Articles",
                        columns: new[] { "ArticleId", "Content", "Unit" },
                        values: new object[] { articleId, content, unit });
                }

                worksheet = package.Workbook.Worksheets["ArticleDescriptions"];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    int articleId = Convert.ToInt32(worksheet.Cells[row, 1].Value);
                    string language = worksheet.Cells[row, 2].Value.ToString();
                    string description = worksheet.Cells[row, 3].Value.ToString();

                    migrationBuilder.InsertData(
                        table: "ArticleDescriptions",
                        columns: new[] { "ArticleId", "Language", "Description" },
                        values: new object[] { articleId, language, description });
                }

            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the seeded data if necessary
            // You may need to write specific logic here to reverse the seeding process
        }
    }
}
