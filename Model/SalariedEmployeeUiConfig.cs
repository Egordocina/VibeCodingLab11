using System.Windows.Forms;

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

		/// <summary>
		/// Применяет конфигурацию к контролам формы.
		/// </summary>
		/// <param name="labels">Массив меток для параметров.</param>
		/// <param name="textBoxes">Массив текстовых полей для параметров.</param>
		public override void ApplyTo(Control[] labels, Control[] textBoxes)
		{
			// Скрываем все контролы (нет параметров)
			for (int i = 0; i < 3; i++)
			{
				labels[i].Visible = false;
				textBoxes[i].Visible = false;
			}
		}
	}
}
