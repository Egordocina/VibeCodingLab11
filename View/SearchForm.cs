using Model;

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

        //TODO: нарушение инкапсуляции+
        /// <summary>
        /// Событие выбора гонщиков (для слабой связанности с MainForm).
        /// </summary>
        public event Action<List<EmployeeBase>>? EmployeesSelected;

        /// <summary>
        /// Инициализирует форму поиска с исходным списком гонщиков.
        /// </summary>
        public SearchForm(List<EmployeeBase> source)
        {
            sourceEmployees = source;
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
            StyleHelper.ApplyLabelStyle(countryLabel);
            StyleHelper.ApplyTextBoxStyle(countryTextBox);
            StyleHelper.ApplyButtonStyle(findButton);
            StyleHelper.ApplyButtonStyle(resetButton);
            StyleHelper.ApplyButtonStyle(cancelButton);
        }

        /// <summary>
        /// Обработчик клика по кнопке "Найти": выполняет поиск.
        /// </summary>
        private void FindButton_Click(object sender, EventArgs eventArgs)
        {
            var queryName = nameTextBox.Text?.Trim();
            var queryLastName = lastNameTextBox.Text?.Trim();
            var queryPosition = positionTextBox.Text?.Trim();
            var queryCountry = countryTextBox.Text?.Trim();
            const StringComparison comparison =
                StringComparison.OrdinalIgnoreCase;

            var filteredEmployees = sourceEmployees.Where(
                employee =>
                    (string.IsNullOrEmpty(queryName)
                     || employee.Name.IndexOf(
                         queryName, comparison) >= 0)
                    && (string.IsNullOrEmpty(queryLastName)
                        || employee.LastName.IndexOf(
                            queryLastName, comparison) >= 0)
                    && (string.IsNullOrEmpty(queryPosition)
                        || employee.Position.IndexOf(
                            queryPosition, comparison) >= 0)
                    && (string.IsNullOrEmpty(queryCountry)
                        || employee.Country.IndexOf(
                            queryCountry, comparison) >= 0)
            ).ToList();

            EmployeesSelected?.Invoke(filteredEmployees);
        }

        /// <summary>
        /// Обработчик клика по кнопке "Сброс": очищает поля.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs eventArgs)
        {
            nameTextBox.Clear();
            lastNameTextBox.Clear();
            positionTextBox.Clear();
            countryTextBox.Clear();
            EmployeesSelected?.Invoke(sourceEmployees);
        }

        /// <summary>
        /// Обработчик клика по кнопке "Отмена": закрывает форму.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}
