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
			baseSalaryTextBox.Clear();
			commissionRateTextBox.Clear();
			bonusAmountTextBox.Clear();
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
			set => commissionRateTextBox.Text = value.ToString(CultureInfo.InvariantCulture);
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
