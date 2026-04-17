using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
namespace DocumentsLibrary;

/// <summary>
/// Сервис для экспорта информации о курсе в Excel-файл
/// </summary>
public class TrainingCourseExcelExporter
{
    /// <summary>
    /// Экспортирует информацию о курсе в Excel-файла
    /// </summary>
    /// <param name="course">Курс для экспорта</param>
    /// <returns>Результат выполнения операции создания Excel-файла</returns>
    public async Task<OperationResponce<string?>> ExportCourseToExcelAsync(TrainingCourse course)
    {
        if (course == null)
            throw new ArgumentNullException(nameof(course));

        // Настройка лицензии EPPlus для некоммерческого использования
        ExcelPackage.License.SetNonCommercialPersonal("Diplom");

        try
        {
            using var package = new ExcelPackage();

            // Создаём первую страницу (может быть пустой или содержать общую информацию)
            var firstSheet = package.Workbook.Worksheets.Add("Словарь");
            // Заполняем страницу данными вопросов
            await FillQestionsSheetAsync(firstSheet, course);

            // Создаём вторую страницу с информацией о курсе
            var courseSheet = package.Workbook.Worksheets.Add("Детали курса");
            // Заполняем страницу данными курса
            await FillCourseSheetAsync(courseSheet, course);

            // Автонастройка ширины колонок
            courseSheet.Cells[courseSheet.Dimension.Address].AutoFitColumns();

            // Сохраняем файл
            var TempPath = Path.GetTempPath();
            var trustedFileNameForFileStorage = "temp.xlsx"; // Path.GetRandomFileName();
            var path = Path.Combine(TempPath, trustedFileNameForFileStorage);

            await package.SaveAsAsync(path);// Сохраняем файл
            return OperationResponce<string?>.SetSuccessfullOperation(path, "Excel файл создан");
        }
        catch (Exception ex)
        {
            return OperationResponce<string?>.SetExceptionOperation("Ошибк при создании Excel файла", ex);
        }
    }

    /// <summary>
    /// Заполняет страницу словаря
    /// </summary>
    private async Task FillQestionsSheetAsync(ExcelWorksheet sheet, TrainingCourse course)
    {
        // Заголовки столбцов
        sheet.Cells[1, 1].Value = "№";
        sheet.Cells[1, 2].Value = "Кандзи";
        sheet.Cells[1, 3].Value = "Хирагана";
        sheet.Cells[1, 4].Value = "Катакана";
        sheet.Cells[1, 5].Value = "Слово";
        int row = 2;

        if (course.CourseQestions?.Count > 0)
        {
            // Заполнение данными
            foreach (var question in course.CourseQestions)
            {
                sheet.Cells[row, 1].Value = row - 1;
                sheet.Cells[row, 2].Value = question.KanjiWord ?? "";
                sheet.Cells[row, 3].Value = question.HiraganaWord ?? "";
                sheet.Cells[row, 4].Value = question.KatakanaWord ?? "";
                sheet.Cells[row, 5].Value = question.Word;
                row++;
            }
        }

        // Применяем тонкие чёрные границы ко всем ячейкам с данными
        int lastRow = row - 1;
        int lastCol = 5;

        if (lastRow >= 1)
        {
            var range = sheet.Cells[1, 1, lastRow, lastCol];

            // Тонкие чёрные границы для всех ячеек
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Top.Color.SetColor(Color.Black);
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Color.SetColor(Color.Black);
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Color.SetColor(Color.Black);
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Color.SetColor(Color.Black);

            // Выравниевание по центру
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Жирный шрифт для заголовков
            sheet.Cells[1, 1, 1, lastCol].Style.Font.Bold = true;

            // Автоматическая подгонка ширины колонок
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
        }
    }

    /// <summary>
    /// Заполняет страницу данными курса
    /// </summary>
    private async Task FillCourseSheetAsync(ExcelWorksheet sheet, TrainingCourse course)
    {
        int currentRow = 1;

        // Заголовок
        sheet.Cells[currentRow, 1, currentRow, 2].Merge = true;
        sheet.Cells[currentRow, 1].Value = $"📚 КУРС: {course.Name}";
        sheet.Cells[currentRow, 1].Style.Font.Size = 18;
        sheet.Cells[currentRow, 1].Style.Font.Bold = true;
        sheet.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        sheet.Cells[currentRow, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        sheet.Cells[currentRow, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(68, 114, 196));
        sheet.Cells[currentRow, 1].Style.Font.Color.SetColor(Color.White);
        currentRow += 2;

        //AddPropertyRow(sheet, currentRow++, "ID курса", course.Id.ToString());
        AddPropertyRow(sheet, currentRow++, "Название", course.Name);
        AddPropertyRow(sheet, currentRow++, "Описание", course.Description ?? "Не указано");
        AddPropertyRow(sheet, currentRow++, "Продолжительность", FormatDuration(course.Duration));
        AddPropertyRow(sheet, currentRow++, "Дата создания", course.CreateDate.ToString("dd.MM.yyyy"));
        AddPropertyRow(sheet, currentRow++, "Уровень сложности", FormatDifficultyLevel(course.DifficultyLevel));
        AddPropertyRow(sheet, currentRow++, "Видимость", course.IsVisableForAll ? "👁️ Доступен всем" : "🔒 Ограниченный доступ");
    }
    
    /// <summary>
    /// Добавляет строку с свойством и значением
    /// </summary>
    private void AddPropertyRow(ExcelWorksheet sheet, int row, string propertyName, string value)
    {
        sheet.Cells[row, 1].Value = propertyName;
        sheet.Cells[row, 1].Style.Font.Bold = true;
        sheet.Cells[row, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

        sheet.Cells[row, 2].Value = value;
        sheet.Cells[row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);

        // Альтернативная заливка для чётности
        if (row % 2 == 0)
        {
            sheet.Cells[row, 1, row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[row, 1, row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(240, 248, 255));
        }
    }

    /// <summary>
    /// Создаём продолжительность курса
    /// </summary>
    private string FormatDuration(int minutes)
    {
        if (minutes <= 0) 
            return "Не указана";

        var hours = minutes / 60;
        var mins = minutes % 60;

        if (hours > 0 && mins > 0)
            return $"{hours} ч. {mins} мин. ({minutes} мин.)";
        
        if (hours > 0)
            return $"{hours} ч. ({minutes} мин.)";

        return $"{minutes} мин.";
    }

    /// <summary>
    /// Создаёт уровень сложности
    /// </summary>
    private string FormatDifficultyLevel(int level)
    {
        string str = String.Empty;
        for (int i = 1; i <= level; i++)
        {
            str = str + "⭐";
        }
        str = str + " (" + level + " уровень)";
        return str;
    }
}
