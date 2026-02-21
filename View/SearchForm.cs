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
        public SearchForm(List<EmployeeBase> source, MainForm parentForm)
        {
            sourceEmployees = source;
            mainForm = parentForm;
            InitializeComponent();
            ApplyStyles();
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark ко всем элементам формы.
        /// </summary>
        private void ApplyStyles()
        {
            StyleHelper.ApplyFormStyle(this);
            StyleHelper.ApplyLabelStyle(nameLabel);
            StyleHelper.ApplyTextBoxStyle(nameTextBox);
            StyleHelper.ApplyLabelStyle(lastNameLabel);
            StyleHelper.ApplyTextBoxStyle(lastNameTextBox);
            StyleHelper.ApplyLabelStyle(positionLabel);
            StyleHelper.ApplyTextBoxStyle(positionTextBox);
            StyleHelper.ApplyLabelStyle(departmentLabel);
            StyleHelper.ApplyTextBoxStyle(departmentTextBox);
            StyleHelper.ApplyButtonStyle(findButton);
            StyleHelper.ApplyButtonStyle(resetButton);
            StyleHelper.ApplyButtonStyle(cancelButton);
        }

        /// <summary>
        /// Обработчик клика по кнопке "Найти": выполняет поиск.
        /// </summary>
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
        /// Обработчик клика по кнопке "Сброс": очищает поля.
        /// </summary>
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
        private void cancelButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}
