using Entities;
using OfficeOpenXml;

namespace DocumentsLibrary;

/// <summary>
/// Импортирует данные из Excel-файла.
/// </summary>
public class LoadExcelData
{
    /// <summary>
    /// Импортирует данные пациентов из Excel-файла.
    /// </summary>
    /// <param name="filePath">Путь к файлу .xlsx.</param>
    /// <returns>Кортеж: успешность, список пациентов, исключение (если есть).</returns>
    public static async Task<OperationResponce<List<CourseQestion>>> ImportFromExcel(string filePath)
    {
        try
        {
            ExcelPackage.License.SetNonCommercialPersonal("Diplom");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл не найден", filePath);

            var courseQestions = new List<CourseQestion>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Словарь"] ?? package.Workbook.Worksheets[0];
                if (worksheet == null)
                    throw new InvalidOperationException("В файле нет листов.");

                int row = 2; // Первая строка — заголовки
                while (true)
                {
                    // Проверяем, что в 4-й колонке есть непустое значение (Слово)
                    string lastName = worksheet.Cells[row, 4].Text?.Trim();
                    if (string.IsNullOrWhiteSpace(lastName))
                        break; // данные закончились

                    string kanjiWord = worksheet.Cells[row, 1].Text?.Trim();
                    string hiraganaWord = worksheet.Cells[row, 2].Text?.Trim();
                    string katakanaWord = worksheet.Cells[row, 3].Text?.Trim();
                    string word = worksheet.Cells[row, 4].Text?.Trim();

                    var courseQestion = new CourseQestion()
                    {
                        KanjiWord = kanjiWord,
                        HiraganaWord=hiraganaWord,
                        KatakanaWord=katakanaWord,
                        Word=word
                    };

                    courseQestions.Add(courseQestion);
                    row++;
                }
                return OperationResponce<List<CourseQestion>>.SetSuccessfullOperation(courseQestions, "Данные из Excel файла прочитаны");
            }
        }
        catch (Exception ex)
        {
            return OperationResponce<List<CourseQestion>>.SetExceptionOperation("Ошибк при извлечении данных из Excel файла", ex);
        }
    }
}
