using System.ComponentModel;
using Model;

namespace View.страдания
{
	/// <summary>
	/// Базовая панель для параметров сотрудника.
	/// </summary>
	public abstract partial class EmployeeParameterPanel : UserControl
	{
		/// <summary>
		/// Имена свойств для привязки данных.
		/// </summary>
		[Browsable(false)]
		public virtual IReadOnlyList<string> PropertyNames => Array.Empty<string>();

		/// <summary>
		/// Минимальное значение для рандомайзера.
		/// </summary>
		[Browsable(false)]
		public abstract double MinRandomValue { get; }

		/// <summary>
		/// Максимальное значение для рандомайзера.
		/// </summary>
		[Browsable(false)]
		public abstract double MaxRandomValue { get; }

		/// <summary>
		/// Инициализирует компоненты панели.
		/// </summary>
		protected EmployeeParameterPanel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Очищает значения всех полей на панели.
		/// </summary>
		public abstract void ClearValues();

		/// <summary>
		/// Заполняет панель случайными значениями.
		/// </summary>
		/// <param name="random">Генератор случайных чисел.</param>
		public abstract void FillRandomValues(Random random);

		/// <summary>
		/// Создаёт сотрудника с данными из панели.
		/// </summary>
		/// <returns>Экземпляр сотрудника.</returns>
		public abstract EmployeeBase CreateEmployee();
	}
}
