namespace _14.ExportToExcel
{
    using System;
    using System.IO;
    using NPOI.OpenXmlFormats.Spreadsheet;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;


    class Program
    {
        static void Main(string[] args)
        {
            string fileDestinationPath = @"C:\Users\Maika\Desktop\SoftUniStrikeTeam\neshto\test.xls";
            string textFilePath = @"C:\Users\Maika\Desktop\SoftUniStrikeTeam\neshto\StudentData.txt";

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("SoftUni OOP Course Results");

            string[] textDocument = File.ReadAllLines(textFilePath);
            string[] headerRow = textDocument[0].Split('\t');

            IRow rowZero = sheet.CreateRow(0);
            IFont font = workbook.CreateFont();
            font.Color = IndexedColors.White.Index;
            for (int i = 0; i < headerRow.Length; i++)
            {
                ICell cell = rowZero.CreateCell(i);
                ICellStyle style = workbook.CreateCellStyle();
                style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
                style.FillPattern = FillPattern.SolidForeground;
                cell.CellStyle = style;
                cell.CellStyle.SetFont(font);
                cell.SetCellValue(headerRow[i]);
            }
            for (int row = 1; row < textDocument.Length; row++)
            {
                string[] currentRowInfo = textDocument[row].Split('\t');
                sheet.SetColumnWidth(3, 32 * 256);
                sheet.SetColumnWidth(10, 15*256);
                IRow currentRow = sheet.CreateRow(row);
                for (int col = 0; col < currentRowInfo.Length; col++)
                {
                    
                    if (col >= 4 && col <= 9)
                    {
                        ICell cell = currentRow.CreateCell(col);
                        cell.SetCellValue(int.Parse(currentRowInfo[col]));
                    }
                    else
                    {
                        ICell cell = currentRow.CreateCell(col);
                        cell.SetCellValue(currentRowInfo[col]);
                    }
                   
                }
            }
            FileStream sw = File.Create(fileDestinationPath);
            workbook.Write(sw);
            sw.Close();
        }
        //3 - > 10
        public static void Helper()
        {

            
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Sheet1");
            IFont font1 = workbook.CreateFont();
            font1.Color = IndexedColors.Red.Index;
            int x = 1;
            for (int i = 0; i < 15; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < 15; j++)
                {
                    ICell cell = row.CreateCell(j);
                    if (x % 2 == 0)
                    {
                        //fill background with blue
                        ICellStyle style1 = workbook.CreateCellStyle();
                        style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Blue.Index2;
                        style1.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = style1;
                    }
                    else
                    {
                        //fill background with yellow
                        ICellStyle style1 = workbook.CreateCellStyle();
                        style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index2;
                        style1.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = style1;
                    }
                    x++;
                }
            }
            FileStream sw = File.Create("asd");
            workbook.Write(sw);
            sw.Close();
        }
    }
}
