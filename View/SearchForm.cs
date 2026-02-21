using Model;
using View;

namespace View
{
	/// <summary>
	/// Форма для поиска гонщиков по критериям.
	/// </summary>
	public partial class SearchForm : Form
	{
		/// <summary>
		/// Исходный список гонщиков для поиска.
		/// </summary>
		private List<EmployeeBase> sourceEmployees;

		/// <summary>
		/// Ссылка на главную форму.
		/// </summary>
		private MainForm mainForm;

		/// <summary>
		/// Инициализирует форму поиска с исходным списком гонщиков.
		/// </summary>
		/// <param name="source">Исходный список гонщиков для поиска.</param>
		/// <param name="parentForm">Ссылка на главную форму.</param>
		public SearchForm(List<EmployeeBase> source, MainForm parentForm)
		{
			sourceEmployees = source;
			mainForm = parentForm;
			InitializeComponent();
		}

		/// <summary>
		/// Обработчик клика по кнопке "Найти":
		/// выполняет поиск и обновляет таблицу главной формы.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void findButton_Click(object sender, EventArgs eventArgs)
		{
			var queryName = nameTextBox.Text?.Trim();
			var queryLastName = lastNameTextBox.Text?.Trim();
			var queryPosition = positionTextBox.Text?.Trim();
			var queryDepartment = departmentTextBox.Text?.Trim();
			const StringComparison stringComparison = StringComparison.OrdinalIgnoreCase;

			var filteredEmployees = sourceEmployees.Where(
				employee =>
					(string.IsNullOrEmpty(queryName)
					 || employee.Name.IndexOf(queryName, stringComparison) >= 0)
					&& (string.IsNullOrEmpty(queryLastName)
						|| employee.LastName.IndexOf(queryLastName, stringComparison) >= 0)
					&& (string.IsNullOrEmpty(queryPosition)
						|| employee.Position.IndexOf(queryPosition, stringComparison) >= 0)
					&& (string.IsNullOrEmpty(queryDepartment)
						|| employee.Country.IndexOf(queryDepartment, stringComparison) >= 0)
			).ToList();

			mainForm.RefreshGrid(filteredEmployees);
		}

		/// <summary>
		/// Обработчик клика по кнопке "Сброс": очищает поля и показывает полный список.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void resetButton_Click(object sender, EventArgs eventArgs)
		{
			nameTextBox.Clear();
			lastNameTextBox.Clear();
			positionTextBox.Clear();
			departmentTextBox.Clear();
			mainForm.RefreshGrid(sourceEmployees);
		}

		/// <summary>
		/// Обработчик клика по кнопке "Отмена": закрывает форму.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void cancelButton_Click(object sender, EventArgs eventArgs)
		{
			Close();
		}
	}
}