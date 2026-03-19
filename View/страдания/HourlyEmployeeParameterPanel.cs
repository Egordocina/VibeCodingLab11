using System.Globalization;
using Model;

namespace View.страдания
{
	/// <summary>
	/// Панель параметров для почасового сотрудника.
	/// </summary>
	public partial class HourlyEmployeeParameterPanel : EmployeeParameterPanel
	{
		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		public override IReadOnlyList<string> PropertyNames => new[]
		{
			nameof(HourlyEmployee.HourlyRate),
			nameof(HourlyEmployee.HoursWorked)
		};

		/// <summary>
		/// Инициализирует компоненты панели.
		/// </summary>
		public HourlyEmployeeParameterPanel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Очищает значения всех полей на панели.
		/// </summary>
		public override void ClearValues()
		{
			hourlyRateTextBox.Clear();
			hoursWorkedTextBox.Clear();
		}

		/// <summary>
		/// Получает или устанавливает почасовую ставку.
		/// </summary>
		public double HourlyRate
		{
			get => double.Parse(hourlyRateTextBox.Text.Replace(".", ","));
			set => hourlyRateTextBox.Text = value.ToString("F1", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Получает или устанавливает отработанные часы.
		/// </summary>
		public double HoursWorked
		{
			get => double.Parse(hoursWorkedTextBox.Text.Replace(".", ","));
			set => hoursWorkedTextBox.Text = value.ToString(CultureInfo.InvariantCulture);
		}
	}
}
