namespace Model
{
	/// <summary>
	/// Конфигурация UI для сотрудника с комиссией.
	/// </summary>
	public class CommissionEmployeeUiConfig : EmployeeUiConfigBase
	{
		/// <summary>
		/// Тексты меток для полей параметров.
		/// </summary>
		public override IReadOnlyList<string> ParameterLabels => new[]
		{
			"Базовая зарплата:",
			"Ставка премии (%):",
			"Сумма премии:"
		};

		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		public override IReadOnlyList<string> PropertyNames => new[]
		{
			nameof(CommissionEmployee.BaseSalary),
			nameof(CommissionEmployee.CommissionRate),
			nameof(CommissionEmployee.BonusAmount)
		};
	}
}
