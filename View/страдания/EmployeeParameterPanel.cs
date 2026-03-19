using System.ComponentModel;

namespace View.страдания
{
	/// <summary>
	/// Базовая панель для параметров сотрудника.
	/// </summary>
	public partial class EmployeeParameterPanel : UserControl
	{
		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		[Browsable(false)]
		public virtual IReadOnlyList<string> PropertyNames => Array.Empty<string>();

		/// <summary>
		/// Инициализирует компоненты панели.
		/// </summary>
		public EmployeeParameterPanel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Очищает значения всех полей на панели.
		/// </summary>
		public virtual void ClearValues()
		{
			foreach (Control control in Controls)
			{
				if (control is TextBox textBox)
				{
					textBox.Clear();
				}
			}
		}

		/// <summary>
		/// Валидирует данные на панели.
		/// </summary>
		/// <exception cref="Exception">Если данные невалидны.</exception>
		public virtual void ValidateData()
		{
			// Базовая реализация — всегда успешно
		}
	}
}
