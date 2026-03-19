using System.Globalization;
using Model;

namespace View.страдания
{
	/// <summary>
	/// Панель параметров для сотрудника с комиссией.
	/// </summary>
	public partial class CommissionEmployeeParameterPanel : EmployeeParameterPanel
	{
		/// <summary>
		/// Минимальное значение для рандомайзера.
		/// </summary>
		public override double MinRandomValue => 300.0;

		/// <summary>
		/// Максимальное значение для рандомайзера.
		/// </summary>
		public override double MaxRandomValue => 800.0;

		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		public override IReadOnlyList<string> PropertyNames => new[]
		{
			nameof(CommissionEmployee.BaseSalary),
			nameof(CommissionEmployee.CommissionRate),
			nameof(CommissionEmployee.BonusAmount)
		};

		/// <summary>
		/// Инициализирует компоненты панели.
		/// </summary>
		public CommissionEmployeeParameterPanel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Очищает значения всех полей на панели.
		/// </summary>
		public override void ClearValues()
		{
			BaseSalary = 0;
			CommissionRate = 0;
			BonusAmount = 0;
		}

		/// <summary>
		/// Заполняет панель случайными значениями.
		/// </summary>
		/// <param name="random">Генератор случайных чисел.</param>
		public override void FillRandomValues(Random random)
		{
			BaseSalary = random.Next((int)MinRandomValue, (int)MaxRandomValue) / 100.0;
			CommissionRate = random.Next(10, 25);
			BonusAmount = random.Next(5000, 30000) / 100.0;
		}

		/// <summary>
		/// Создаёт сотрудника с данными из панели.
		/// </summary>
		/// <returns>Экземпляр сотрудника.</returns>
		public override EmployeeBase CreateEmployee()
		{
			return new CommissionEmployee
			{
				BaseSalary = BaseSalary,
				CommissionRate = CommissionRate,
				BonusAmount = BonusAmount
			};
		}

		/// <summary>
		/// Получает или устанавливает базовую зарплату.
		/// </summary>
		public double BaseSalary
		{
			get => double.Parse(baseSalaryTextBox.Text.Replace(".", ","));
			set => baseSalaryTextBox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Получает или устанавливает ставку премии.
		/// </summary>
		public double CommissionRate
		{
			get => double.Parse(commissionRateTextBox.Text.Replace(".", ","));
			set => commissionRateTextBox.Text = value.ToString("F0");
		}

		/// <summary>
		/// Получает или устанавливает сумму премии.
		/// </summary>
		public double BonusAmount
		{
			get => double.Parse(bonusAmountTextBox.Text.Replace(".", ","));
			set => bonusAmountTextBox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
		}
	}
}
