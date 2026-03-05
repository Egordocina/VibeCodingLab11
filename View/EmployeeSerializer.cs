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
		//TODO: XML+
		/// <summary>
		/// Параметры сериализации и десериализации JSON.
		/// </summary>
		private static readonly JsonSerializerOptions _jsonOptions = new()
		{
			WriteIndented = true
		};

		/// <summary>
		/// Сохраняет список гонщиков в файл в формате JSON.
		/// </summary>
		/// <param name="employees">Список гонщиков.</param>
		/// <param name="path">Путь к файлу.</param>
		/// <exception cref="System.IO.IOException">
		/// Если произошла ошибка записи в файл.
		/// </exception>
		public static void Save(IEnumerable<EmployeeBase> employees, string path) =>
			File.WriteAllText(path, JsonSerializer.Serialize(employees, _jsonOptions));

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
		public static List<EmployeeBase> Load(string path) =>
			JsonSerializer.Deserialize<List<EmployeeBase>>(
				File.ReadAllText(path), _jsonOptions)
			//TODO: rewrite+
			?? throw new JsonException("Не удалось десериализовать параметры сотрудников.");
	}
}