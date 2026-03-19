namespace Model
{
	/// <summary>
	/// Конфигурация UI для почасового сотрудника.
	/// </summary>
	public class HourlyEmployeeUiConfig : EmployeeUiConfigBase
	{
		/// <summary>
		/// Тексты меток для полей параметров.
		/// </summary>
		public override IReadOnlyList<string> ParameterLabels => new[]
		{
			"Почасовая ставка:",
			"Отработанные часы:"
		};

		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		public override IReadOnlyList<string> PropertyNames => new[]
		{
			nameof(HourlyEmployee.HourlyRate),
			nameof(HourlyEmployee.HoursWorked)
		};
	}
}
