namespace Model
{
	/// <summary>
	/// Гонщик с оплатой по ставке.
	/// </summary>
	public class CommissionEmployee : BaseEmployee
	{
		/// <summary>
		/// Поле для базовой зарплаты.
		/// </summary>
		private double _baseSalary;

		/// <summary>
		/// Поле для ставки комиссии.
		/// </summary>
		private double _commissionRate;

		/// <summary>
		/// Поле для суммы бонуса.
		/// </summary>
		private double _bonusAmount;

		/// <summary>
		/// Фиксированная зарплата.
		/// </summary>
		public double BaseSalary
		{
			get => _baseSalary;
			set
			{
				if (value <= 0)
				{
					throw new IncorrectArgumentException(
						"Базовая зарплата должна быть положительной.");
				}
				_baseSalary = value;
			}
		}

		/// <summary>
		/// Ставка премии (в %).
		/// </summary>
		public double CommissionRate
		{
			get => _commissionRate;
			set
			{
				const int MinCommissionRate = 0;
				const int MaxCommissionRate = 100;
				if (value <= MinCommissionRate || value > MaxCommissionRate)
				{
					throw new IncorrectArgumentException(
						$"Ставка премии должна быть больше 0 " +
						$"до {MaxCommissionRate}%.");
				}
				_commissionRate = value;
			}
		}

		/// <summary>
		/// Сумма премии (руб., за KPI).
		/// </summary>
		public double BonusAmount
		{
			get => _bonusAmount;
			set
			{
				if (value <= 0)
				{
					throw new IncorrectArgumentException(
						"Сумма премии должна быть положительной.");
				}
				_bonusAmount = value;
			}
		}

		/// <summary>
		/// Расчет: оклад по должности + базовая + (ставка * сумма премии / 100).
		/// </summary>
		public override double CalculateSalary()
		{
			return BaseSalary + (CommissionRate * BonusAmount / 100);
		}
	}
}