using System.Text;
namespace Entities;

/// <summary>
/// Очистка текста
/// </summary>
public class TextClearing
{
	/// <summary>
	/// Очистить от лишних пробелов (удаляются пробелы в начале, в конце текста и парные пробелы)
	/// </summary>
	/// <param name="str">Исходный текст</param>
	/// <returns>Очищенный текст</returns>
	public static string? ClearSpaces(string? str)
	{
		if (string.IsNullOrEmpty(str))
			return str;
		return TrimChar(str, ' ');
	}

	/// <summary>
	/// Удаляет двойные символы и символы в начале и в конце строки
	/// (Если строка состоит только из удаляемых символов (ch), тогда возвращается пустая строка)
	/// <param name="text">Текст, в котором надо удалить символы</param>
	/// <param name="ch">Удаляемый символ</param>
	/// <returns>Очищенный текст</returns>
	public static string? TrimChar(string? text, char ch)
	{
		if (text == null) return null;
		if (text == string.Empty) return string.Empty;

		var sb = new StringBuilder(text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == ch && (i == 0
								|| i == text.Length - 1
								|| (i > 0 && text[i - 1] == ch)))
			{
			}
			else
			{
				sb.Append(text[i]);
			}
		}
		if (sb.Length > 0 && sb[sb.Length - 1] == ch) sb.Remove(sb.Length - 1, 1);
		return sb.ToString();
	}
}
