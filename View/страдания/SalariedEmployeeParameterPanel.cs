using Model;

namespace View.страдания
{
	/// <summary>
	/// Панель параметров для сотрудника с окладом.
	/// </summary>
	public partial class SalariedEmployeeParameterPanel : EmployeeParameterPanel
	{
		/// <summary>
		/// Минимальное значение для рандомайзера.
		/// </summary>
		public override double MinRandomValue => 0;

		/// <summary>
		/// Максимальное значение для рандомайзера.
		/// </summary>
		public override double MaxRandomValue => 0;

		/// <summary>
		/// Инициализирует компоненты панели.
		/// </summary>
		public SalariedEmployeeParameterPanel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Очищает значения всех полей на панели.
		/// </summary>
		public override void ClearValues()
		{
			// Нет полей для очистки
		}

		/// <summary>
		/// Заполняет панель случайными значениями.
		/// </summary>
		/// <param name="random">Генератор случайных чисел.</param>
		public override void FillRandomValues(Random random)
		{
			// Нет параметров для заполнения
		}

		/// <summary>
		/// Создаёт сотрудника с данными из панели.
		/// </summary>
		/// <returns>Экземпляр сотрудника.</returns>
		public override EmployeeBase CreateEmployee()
		{
			return new SalariedEmployee();
		}
	}
}
