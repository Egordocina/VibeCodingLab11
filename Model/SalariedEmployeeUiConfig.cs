namespace Model
{
	/// <summary>
	/// Конфигурация UI для сотрудника с окладом.
	/// </summary>
	public class SalariedEmployeeUiConfig : EmployeeUiConfigBase
	{
		/// <summary>
		/// Тексты меток для полей параметров (пусто, т.к. нет дополнительных параметров).
		/// </summary>
		public override IReadOnlyList<string> ParameterLabels => Array.Empty<string>();

		/// <summary>
		/// Имена свойств для привязки данных (пусто, т.к. нет дополнительных параметров).
		/// </summary>
		public override IReadOnlyList<string> PropertyNames => Array.Empty<string>();
	}
}
