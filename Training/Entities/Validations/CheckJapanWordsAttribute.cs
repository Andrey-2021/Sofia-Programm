using System.ComponentModel.DataAnnotations;

namespace Entities.Validations;

public class CheckJapanWordsAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        // Получаем экземпляр класса, содержащего свойство
        var instance = validationContext.ObjectInstance;
        if (instance is not CourseQestion course)
            return new ValidationResult("Атрибут может применяться только к свойствам класса CourseQestion.");

        // Проверяем все три свойства на наличие непустых значений
        bool hasKanji = !string.IsNullOrWhiteSpace(course.KanjiWord);
        bool hasHiragana = !string.IsNullOrWhiteSpace(course.HiraganaWord);
        bool hasKatakana = !string.IsNullOrWhiteSpace(course.KatakanaWord);

        // Если хотя бы одно свойство заполнено — валидация успешна
        if (hasKanji || hasHiragana || hasKatakana)
            return ValidationResult.Success;

        // Иначе формируем сообщение об ошибке, привязанное к текущему свойству
        string errorMessage = ErrorMessage ?? "Должно быть указано хотя бы одно слово: Kanji, Hiragana или Katakana.";
        return new ValidationResult(errorMessage, new[] { validationContext.MemberName });
    }
}
