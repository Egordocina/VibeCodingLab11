using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Model
{
	/// <summary>
	/// Базовый класс гонщика с фиксированным окладом по разряду.
	/// </summary>
	[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
	[JsonDerivedType(typeof(HourlyEmployee), "hourly")]
	[JsonDerivedType(typeof(CommissionEmployee), "commission")]
	[JsonDerivedType(typeof(SalariedEmployee), "salaried")]
	public abstract class EmployeeBase : IEmployee
	{
		/// <summary>
		/// Имя гонщика.
		/// </summary>
		private string _name;

		/// <summary>
		/// Фамилия гонщика.
		/// </summary>
		private string _lastName;

		/// <summary>
		/// Разряд гонщика.
		/// </summary>
		private string _position;

		/// <summary>
		/// Страна гонщика.
		/// </summary>
		private string _country;

		/// <summary>
		/// Данные о разрядах: номер (название, оклад).
		/// </summary>
		public static readonly Dictionary<int, (string Name, double Salary)>
			PositionData = new()
		{
			{ 1, ("3 разряд", 60000) },
			{ 2, ("2 разряд", 75000) },
			{ 3, ("1 разряд", 90000) },
			{ 4, ("КМС", 110000) },
			{ 5, ("МС", 130000) },
			{ 6, ("МСМК", 150000) }
		};

		/// <summary>
		/// Данные о странах: номер название.
		/// </summary>
		public static readonly Dictionary<int, string> CountryData = new()
		{
			{ 1, "Россия" },
			{ 2, "Франция" },
			{ 3, "Норвегия" },
			{ 4, "Германия" },
			{ 5, "Финляндия" },
			{ 6, "Канада" },
			{ 7, "Италия" },
			{ 8, "Чехия" },
			{ 9, "Швеция" },
			{ 10, "Страна 404" }
		};

		/// <summary>
		/// Русское название типа сотрудника.
		/// </summary>
		[DisplayName("Тип")]
		public abstract string TypeName { get; }

		/// <summary>
		/// Имя гонщика.
		/// </summary>
		[DisplayName("Имя")]
		public string Name
		{
			get => _name;
			set => SetName(value);
		}

		/// <summary>
		/// Фамилия гонщика.
		/// </summary>
		[DisplayName("Фамилия")]
		public string LastName
		{
			get => _lastName;
			set => SetLastName(value);
		}

		/// <summary>
		/// Разряд гонщика (определяет оклад).
		/// </summary>
		[DisplayName("Разряд")]
		public string Position
		{
			get => _position;
			set => SetPosition(value);
		}

		/// <summary>
		/// Страна гонщика.
		/// </summary>
		[DisplayName("Страна")]
		public string Country
		{
			get => _country;
			set => SetCountry(value);
		}

		/// <summary>
		/// Устанавливает имя после валидации строки.
		/// </summary>
		/// <param name="value">
		/// Новое значение имени.
		/// </param>
		private void SetName(string value)
		{
			ValidateString(value, 50, "Имя");
			_name = value;
		}

		/// <summary>
		/// Устанавливает фамилию после валидации строки.
		/// </summary>
		/// <param name="value">
		/// Новое значение фамилии.
		/// </param>
		private void SetLastName(string value)
		{
			ValidateString(value, 50, "Фамилия");
			_lastName = value;
		}

		/// <summary>
		/// Устанавливает разряд после валидации строки.
		/// </summary>
		/// <param name="value">
		/// Новое значение разряда.
		/// </param>
		private void SetPosition(string value)
		{
			ValidateString(value, 100, "Разряд");
			_position = value;
		}

		/// <summary>
		/// Устанавливает страну после валидации строки.
		/// </summary>
		/// <param name="value">
		/// Новое значение разряда.
		/// </param>
		private void SetCountry(string value)
		{
			ValidateString(value, 63, "Страна");
			_country = value;
		}

		/// <summary>
		/// Валидация строки для свойств.
		/// </summary>
		/// <param name="value">Значение.</param>
		/// <param name="maxLength">Максимальная длина.</param>
		/// <param name="fieldName">Имя поля для ошибки.</param>
		private static void ValidateString(string value, int maxLength,
			string fieldName)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new IncorrectArgumentException(
					$"{fieldName} не может быть пустым.");
			}
			if (value.Length > maxLength)
			{
				throw new IncorrectArgumentException(
					$"{fieldName} не может превышать " +
					$"{maxLength} символов.");
			}
		}

		/// <summary>
		/// Расчет зарплаты
		/// </summary>
		/// <returns>Оклад в рублях.</returns>
		public abstract double CalculateSalary();

		/// <summary>
		/// Зарплата (для привязки к DataGridView).
		/// </summary>
		[Browsable(true)]
		[DisplayName("Зарплата (руб.)")]
		public double Salary => Math.Round(CalculateSalary(), 2);
	}
}