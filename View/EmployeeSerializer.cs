using System.Text.Json;
using Model;

namespace View
{
	/// <summary>
	/// Статический класс для сериализации и десериализации
	/// списка гонщиков в/из JSON-формата.
	/// </summary>
	public static class EmployeeSerializer
	{
		/// <summary>
		/// Сохраняет список гонщиков в файл в формате JSON.
		/// </summary>
		/// <param name="employees">Список гонщиков.</param>
		/// <param name="path">Путь к файлу.</param>
		/// <exception cref="System.IO.IOException">
		/// Если произошла ошибка записи в файл.
		/// </exception>
		public static void Save(IEnumerable<EmployeeBase> employees, string path)
		{
			var list = new List<object>();
			foreach (var employee in employees)
			{
				list.Add(employee);
			}

			var json = JsonSerializer.Serialize(
				list,
				new JsonSerializerOptions { WriteIndented = true });

			File.WriteAllText(path, json);
		}

		/// <summary>
		/// Загружает список гонщиков из файла в формате JSON.
		/// </summary>
		/// <param name="path">Путь к файлу.</param>
		/// <returns>Список загруженных гонщиков.</returns>
		/// <exception cref="System.IO.FileNotFoundException">
		/// Если файл не найден.
		/// </exception>
		/// <exception cref="System.Text.Json.JsonException">
		/// Если файл содержит некорректный JSON.
		/// </exception>
		public static List<EmployeeBase> Load(string path)
		{
			var text = File.ReadAllText(path);

			using var document = JsonDocument.Parse(text);
			var root = document.RootElement;
			var result = new List<EmployeeBase>();

			foreach (var element in root.EnumerateArray())
			{
				//TODO: refactor
				if (element.TryGetProperty(
					nameof(HourlyEmployee.HourlyRate), out _))
				{
					var hourlyEmployee = JsonSerializer
						.Deserialize<HourlyEmployee>(element.GetRawText())!;
					result.Add(hourlyEmployee);
					continue;
				}

				if (element.TryGetProperty(
					nameof(CommissionEmployee.CommissionRate), out _))
				{
					var commissionEmployee = JsonSerializer
						.Deserialize<CommissionEmployee>(element.GetRawText())!;
					result.Add(commissionEmployee);
					continue;
				}

				var salariedEmployee = JsonSerializer
					.Deserialize<SalariedEmployee>(element.GetRawText())!;
				result.Add(salariedEmployee);
			}

			return result;
		}
	}
}