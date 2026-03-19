using System.Windows.Forms;

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

			// Показываем и настраиваем все 3 поля
			for (int i = 0; i < 3; i++)
			{
				labels[i].Visible = true;
				textBoxes[i].Visible = true;
				((Label)labels[i]).Text = ParameterLabels[i];
				textBoxes[i].Tag = PropertyNames[i];
			}
		}
	}
}
