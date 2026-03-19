using System.Windows.Forms;

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

		/// <summary>
		/// Применяет конфигурацию к контролам формы.
		/// </summary>
		/// <param name="labels">Массив меток для параметров.</param>
		/// <param name="textBoxes">Массив текстовых полей для параметров.</param>
		public override void ApplyTo(Control[] labels, Control[] textBoxes)
		{
			// Скрываем все контролы сначала
			for (int i = 0; i < 3; i++)
			{
				labels[i].Visible = false;
				textBoxes[i].Visible = false;
			}

			// Показываем и настраиваем первые 2 поля
			labels[0].Visible = true;
			textBoxes[0].Visible = true;
			((Label)labels[0]).Text = ParameterLabels[0];
			textBoxes[0].Tag = PropertyNames[0];

			labels[1].Visible = true;
			textBoxes[1].Visible = true;
			((Label)labels[1]).Text = ParameterLabels[1];
			textBoxes[1].Tag = PropertyNames[1];
		}
	}
}
