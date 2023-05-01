using Diploma.Models;
using System;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using System.Collections.ObjectModel;

namespace Diploma.Services
{
    public class ExcelHelper : IDisposable
    {
        private Application _excel;
        private Workbook _workbook;

        public ExcelHelper()
        {
            _excel = new Application();
            _workbook = _excel.Workbooks.Add();
            _excel.DisplayAlerts = false;
        }

        public string CreateExcel(ObservableCollection<Payment> payments)
        {
            Worksheet worksheet = _workbook.Sheets[1];
            string date = $"{DateTime.Now:dd.MM.yyyy hh.mm}";

            worksheet.Cells[1, 1] = "Период";
            worksheet.Cells[1, 2] = "Сумма платежа";
            worksheet.Cells[1, 3] = "Проценты";
            worksheet.Cells[1, 4] = "Главный долг";
            worksheet.Cells[1, 5] = "Остаток задолжности";

            for (int i = 0; i < payments.Count; i++)
            {
                worksheet.Cells[i + 2, 1] = $"{payments[i].Period}";
                worksheet.Cells[i + 2, 2] = $"{payments[i].Amount}";
                worksheet.Cells[i + 2, 3] = $"{payments[i].Interest}";
                worksheet.Cells[i + 2, 4] = $"{payments[i].Principal}";
                worksheet.Cells[i + 2, 5] = $"{payments[i].Balance}";
            }

            Range range = worksheet.Range["A1", $"E{payments.Count - 1}"];
            range.Columns.AutoFit();
            range.Borders.LineStyle = XlLineStyle.xlContinuous;
  
            string path = $"C:\\Users\\arman\\OneDrive\\Рабочий стол\\График платежей\\Excels\\ГП - {date}.xlsx";
            _workbook.SaveAs(path);
            
            return path;
        }

        public void Dispose()
        {          
            _workbook.Close();
            _excel.Quit();
        }
    }
}
