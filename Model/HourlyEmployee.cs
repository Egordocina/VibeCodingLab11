namespace Model
{
	/// <summary>
	/// Гонщик с почасовой оплатой.
	/// </summary>
	public class HourlyEmployee : BaseEmployee
	{
		/// <summary>
		/// Поле для почасовой ставки.
		/// </summary>
		private double _hourlyRate;

		/// <summary>
		/// Поле для отработанных часов.
		/// </summary>
		private double _hoursWorked;

		/// <summary>
		/// Почасовая ставка.
		/// </summary>
		public double HourlyRate
		{
			get => _hourlyRate;
			set
			{
				const double MinRate = 0;
				if (value <= MinRate)
				{
					throw new IncorrectArgumentException(
						"Почасовая ставка должна быть положительной.");
				}
				_hourlyRate = value;
			}
		}

		/// <summary>
		/// Отработанные часы.
		/// </summary>
		public double HoursWorked
		{
			get => _hoursWorked;
			set
			{
				const int MinHours = 1;
				const int MaxHours = 744;
				if (value < MinHours || value > MaxHours)
				{
					throw new IncorrectArgumentException(
						$"Отработанные часы должны быть от {MinHours} " +
						$"до {MaxHours}.");
				}
				_hoursWorked = value;
			}
		}

		/// <summary>
		/// Расчет: оклад по разряду + (ставка * часы).
		/// </summary>
		public override double CalculateSalary()
		{
			return HourlyRate * HoursWorked;
		}
	}
}