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
		/// Минимальное значение для рандомайзера.
		/// </summary>
		public override double MinRandomValue => 100.0;

		/// <summary>
		/// Максимальное значение для рандомайзера.
		/// </summary>
		public override double MaxRandomValue => 200.0;

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
			HourlyRate = 0;
			HoursWorked = 0;
		}

		/// <summary>
		/// Заполняет панель случайными значениями.
		/// </summary>
		/// <param name="random">Генератор случайных чисел.</param>
		public override void FillRandomValues(Random random)
		{
			HourlyRate = random.Next((int)MinRandomValue, (int)MaxRandomValue) / 10.0;
			HoursWorked = random.Next(160, 200);
		}

		/// <summary>
		/// Создаёт сотрудника с данными из панели.
		/// </summary>
		/// <returns>Экземпляр сотрудника.</returns>
		public override EmployeeBase CreateEmployee()
		{
			return new HourlyEmployee
			{
				HourlyRate = HourlyRate,
				HoursWorked = HoursWorked
			};
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
			set => hoursWorkedTextBox.Text = value.ToString("F0");
		}
	}
}
