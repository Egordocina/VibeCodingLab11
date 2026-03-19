using System.Windows.Forms;

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

		/// <summary>
		/// Применяет конфигурацию к контролам формы.
		/// </summary>
		/// <param name="labels">Массив меток для параметров.</param>
		/// <param name="textBoxes">Массив текстовых полей для параметров.</param>
		public abstract void ApplyTo(Control[] labels, Control[] textBoxes);
	}
}
