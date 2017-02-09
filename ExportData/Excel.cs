using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData
{
    public class Excel
    {
        private const string FirstSheet = "Hoja1";

        public bool Save(ExcelPackage excel)
        {
            try
            {
                excel.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ExcelPackage Create(string path)
        {
            FileUtilities.Delete(path);
            var excel = new ExcelPackage(new FileInfo(path));
            excel.Workbook.Worksheets.Add(FirstSheet);

            return excel;
        }

        //public ExcelPackage WriteRangeCells(ExcelPackage excel)
        //{
        //    var sheetCurrent = excel.Workbook.Worksheets[FirstSheet];

        //}
    }

    public static class FileUtilities
    {
        public static void Delete(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
                if (File.Exists(path))
                    File.Delete(path);
        }
    }
}