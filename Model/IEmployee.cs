namespace Model
{
	/// <summary>
	/// Интерфейс для гонщика.
	/// </summary>
	public interface IEmployee
	{
		/// <summary>
		/// Имя гонщика.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Фамилия гонщика.
		/// </summary>
		string LastName { get; set; }

		/// <summary>
		/// Должность гонщика (определяет оклад).
		/// </summary>
		string Position { get; set; }

		/// <summary>
		/// Служба (отдел) гонщика.
		/// </summary>
		string Country { get; set; }

		/// <summary>
		/// Расчет зарплаты гонщика.
		/// </summary>
		/// <returns>Зарплата в рублях.</returns>
		double CalculateSalary();
	}
}
