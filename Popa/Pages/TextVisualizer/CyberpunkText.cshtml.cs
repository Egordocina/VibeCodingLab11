using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Pora.Pages.TextVisualizer
{
	public class CyberpunkTextModel : PageModel
	{
		[BindProperty]
		public decimal UserInput { get; set; } = 0;

		public string BinaryResult { get; set; } = "0";
		public string OctalResult { get; set; } = "0";
		public string HexResult { get; set; } = "0";

		public void OnPost()
		{
			try
			{
				// Конвертация в целое число (только для положительных)
				long intValue = (long)UserInput;

				BinaryResult = Convert.ToString(intValue, 2);
				OctalResult = Convert.ToString(intValue, 8);
				HexResult = Convert.ToString(intValue, 16).ToUpper();
			}
			catch
			{
				// Обработка ошибок
				BinaryResult = "Ошибка";
				OctalResult = "Ошибка";
				HexResult = "Ошибка";
			}
		}
	}
}