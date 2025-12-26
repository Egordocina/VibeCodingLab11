using System;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
	/// <summary>
	/// Класс Adult.
	/// </summary>
	public class Adult : Person
	{
		/// <summary>
		/// Поле номера паспорта.
		/// </summary>
		private string _numPass;

		/// <summary>
		/// Поле серии паспорта.
		/// </summary>
		private string _seriesPass;

		/// <summary>
		/// Поле партнера.
		/// </summary>
		private Adult _partner;

		/// <summary>
		/// Поле работы.
		/// </summary>
		private string _job;

		/// <inheritdoc/>
		public override int MinAge { get; } = 18;

		/// <summary>
		/// Количество цифр в серии паспорта.
		/// </summary>
		public const int PassSeriesDigits = 4;

		/// <summary>
		/// Количество цифр в номере паспорта.
		/// </summary>
		public const int PassNumDigits = 6;

		/// <summary>
		/// Конструктор класса Adult.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="surname">Фамилия.</param>
		/// <param name="age">Возраст.</param>
		/// <param name="gender">Пол.</param>
		/// <param name="numPass">Номер паспорта.</param>
		/// <param name="seriesPass">Серия паспорта.</param>
		/// <param name="partner">Партнер.</param>
		/// <param name="job">Работа.</param>
		public Adult(string name, string surname, int age, Gender gender,
			string numPass, string seriesPass, Adult partner,
			string job)
			: base(name, surname, age, gender)
		{
			_numPass = numPass;
			_seriesPass = seriesPass;
			_partner = partner;
			_job = job;
		}

		/// <summary>
		/// Конструктор класса Adult по умолчанию.
		/// </summary>
		public Adult() : this("Аскар", "Фридрихов", 62, Gender.Male,
			"", "", null, null)
		{ }

		/// <summary>
		/// Задание номера паспорта.
		/// </summary>
		public string NumPass
		{
			get
			{
				return _numPass;
			}

			set
			{
				if (value.Length == PassNumDigits
					&& IsSeriesOrNumberPassportValid(value))
				{
					_numPass = value;
				}
				else
				{
					throw new ArgumentException
						($"Номер паспорта должен содержать " +
						$"{PassNumDigits} цифр");
				}
			}
		}

		/// <summary>
		/// Задание серии паспорта.
		/// </summary>
		public string SeriesPass
		{
			get
			{
				return _seriesPass;
			}

			set
			{
				if (value.Length == PassSeriesDigits
					&& IsSeriesOrNumberPassportValid(value))
				{
					_seriesPass = value;
				}
				else
				{
					throw new ArgumentException
						($"Серия паспорта должна содержать " +
						$"{PassSeriesDigits} цифры");
				}
			}
		}

		//TODO: XML+
		/// <summary>
		/// Поучение партнера
		/// </summary>
		public Adult Partner
		{
			get
			{
				return _partner;
			}
			set
			{
				if (value != null && value.Gender == Gender)
				{
					throw new ArgumentException
						("Однополые браки запрещены в РФ " +
						"(Семейный кодекс РФ)");
				}

				if (value != null)
				{
					value._partner = this;
				}

				_partner = value;
			}
		}

		/// <summary>
		/// Задание работы.
		/// </summary>
		public string Job
		{
			get { return _job; }
			set
			{
				_job = string.IsNullOrWhiteSpace(value)
					? "Безработный" : value;
			}
		}

		/// <summary>
		/// Получение информации о взрослом.
		/// </summary>
		/// <returns>Строка с данными полей объекта класса Adult.</returns>
		public override string GetInfo()
		{
			string partner = string.Empty;

			if (Gender == Gender.Male && Partner == null)
			{
				partner = "Не женат";
			}

			if (Gender == Gender.Female && Partner == null)
			{
				partner = "Не замужем";
			}

			if (Partner != null)
			{
				partner = Partner.LastName + " " + Partner.FirstName;
			}

			if (Job == null)
			{
				Job = "Безработный";
			}

			return base.GetInfo() + $", серия паспорта: {SeriesPass}, " +
				$"номер паспорта: {NumPass}, партнер: {partner}, " +
				$"место работы: {Job}\n";
		}

		/// <summary>
		/// Проверка того, что серия и номер паспорта содержат только цифры.
		/// </summary>
		/// <param name="pass">Серия или номер паспорта.</param>
		/// <returns>true, если серия или номер паспорта содержат 
		/// только цифры; false, если и символы.</returns>
		public bool IsSeriesOrNumberPassportValid(string pass)
		{
			return Regex.IsMatch(pass, @"^\d+$");
		}

		/// <summary>
		/// Метод для класса Adult.
		/// </summary>
		/// <returns>Строка.</returns>
		public string GetExtraIncome()
		{
			//BUG:+
			return "Голосует за Путина";
		}
	}
}