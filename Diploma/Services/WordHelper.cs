using Diploma.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.ObjectModel;

public class WordHelper : IDisposable
{
    private Application _wordApp;
    private Document _doc;
    private string _filePath;

    public WordHelper()
    {
        _wordApp = new Application();
        _doc = _wordApp.Documents.Add();
        _wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
    }

    public string CreateWord(ObservableCollection<Payment> payments)
    {
        // добавляем параграф с заголовком
        var para = _doc.Paragraphs.Add();
        string date = $"{DateTime.Now:dd.MM.yyyy hh.mm}";
        para.Range.Text = $"График платежа - {date}";
        para.Range.Font.Bold = 1;
        para.Range.Font.Size = 14;
        para.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

        // добавляем таблицу
        var table = _doc.Tables.Add(para.Range, payments.Count, 5);
        table.Borders.Enable = 1;
        table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

        // заполняем заголовки столбцов
        table.Cell(1, 1).Range.Text = "Период";
        table.Cell(1, 2).Range.Text = "Сумма платежа";
        table.Cell(1, 3).Range.Text = "Проценты";
        table.Cell(1, 4).Range.Text = "Главный долг";
        table.Cell(1, 5).Range.Text = "Остаток задолжности";

        // заполняем таблицу данными
        for (int i = 0; i < payments.Count; i++)
        {
            table.Cell(i + 2, 1).Range.Text = $"{payments[i].Period}";
            table.Cell(i + 2, 2).Range.Text = $"{payments[i].Amount}";
            table.Cell(i + 2, 3).Range.Text = $"{payments[i].Interest}";
            table.Cell(i + 2, 4).Range.Text = $"{payments[i].Principal}";
            table.Cell(i + 2, 5).Range.Text = $"{payments[i].Balance}";
        }

        // сохраняем документ
        string path = $"C:\\Users\\arman\\OneDrive\\Рабочий стол\\График платежей\\Words\\ГП - {date}.docx";
        _doc.SaveAs2(path);

        return path;
    }

    public void Dispose()
    {
        _doc.Close();
        _wordApp.Quit();
    }
}
