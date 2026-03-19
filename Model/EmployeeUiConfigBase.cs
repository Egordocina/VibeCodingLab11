namespace Model
{
	/// <summary>
	/// Базовый класс для конфигурации UI параметров сотрудника.
	/// </summary>
	public abstract class EmployeeUiConfigBase
	{
		/// <summary>
		/// Тексты меток для полей параметров.
		/// </summary>
		public abstract IReadOnlyList<string> ParameterLabels { get; }

		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		public abstract IReadOnlyList<string> PropertyNames { get; }

		/// <summary>
		/// Количество параметров.
		/// </summary>
		public int ParameterCount => ParameterLabels.Count;
	}
}
