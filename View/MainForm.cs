using Model;
using View;

namespace View
{
    /// <summary>
    /// Главная форма приложения для управления списком гонщиков.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список гонщиков.
        /// </summary>
        private List<EmployeeBase> employees = new List<EmployeeBase>();

        /// <summary>
        /// Инициализирует главную форму.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGridColumns();
            RefreshGrid();
        }

        /// <summary>
        /// Инициализирует столбцы в таблице гонщиков.
        /// </summary>
        private void InitializeGridColumns()
        {
            employeesDataGridView.Columns.Clear();
            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Имя",
                DataPropertyName = "Name"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Фамилия",
                DataPropertyName = "LastName"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Разряд",
                DataPropertyName = "Position"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Страна",
                DataPropertyName = "Department"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Тип",
                DataPropertyName = "EmployeeType"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Зарплата (руб.)",
                DataPropertyName = "Salary"
            });
        }

        /// <summary>
        /// Обработчик клика по кнопке "Добавить": открывает форму добавления.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="eventArgs">Аргументы события.</param>
        private void addButton_Click(object sender, EventArgs eventArgs)
        {
            using var addEmployeeForm = new AddEmployeeForm();
            if (addEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                if (addEmployeeForm.CreatedEmployee != null)
                {
                    employees.Add(addEmployeeForm.CreatedEmployee);
                    RefreshGrid();
                }
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке "Удалить": удаляет выбранного гонщика.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="eventArgs">Аргументы события.</param>
        private void removeButton_Click(object sender, EventArgs eventArgs)
        {
            if (employeesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите гонщика для удаления.",
                    "Инфо",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int index = employeesDataGridView.SelectedRows[0].Index;
            if (index >= 0 && index < employees.Count)
            {
                if (MessageBox.Show(
                    "Удалить выбранного гонщика?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    employees.RemoveAt(index);
                    RefreshGrid();
                }
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке "Поиск": открывает форму поиска.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="eventArgs">Аргументы события.</param>
        private void searchButton_Click(object sender, EventArgs eventArgs)
        {
            var searchForm = new SearchForm(employees, this);
            searchForm.Show();
        }

        /// <summary>
        /// Обработчик клика по кнопке "Сохранить": сохраняет список в файл.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="eventArgs">Аргументы события.</param>
        private void saveButton_Click(object sender, EventArgs eventArgs)
        {
            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы 'СО ЕЭС' (*.soees)|*.soees|" +
                         "JSON files (*.json)|*.json",
                DefaultExt = "soees"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EmployeeSerializer.Save(employees, saveFileDialog.FileName);
                    MessageBox.Show(
                        "Сохранено.",
                        "ОК",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        $"Ошибка при сохранении: {exception.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке "Загрузить": загружает список из файла.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="eventArgs">Аргументы события.</param>
        private void loadButton_Click(object sender, EventArgs eventArgs)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы 'СО ЕЭС' (*.soees)|*.soees|" +
                         "JSON files (*.json)|*.json",
                DefaultExt = "soees"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var loadedList = EmployeeSerializer.Load(openFileDialog.FileName);
                    employees = new List<EmployeeBase>(loadedList);
                    RefreshGrid();
                    MessageBox.Show(
                        "Загружено.",
                        "ОК",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        $"Ошибка при загрузке: {exception.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обновляет таблицу гонщиков данными из источника
        /// (или полного списка по умолчанию).
        /// </summary>
        /// <param name="source">
        /// Источник данных для таблицы (опционально).
        /// </param>
        public void RefreshGrid(IEnumerable<EmployeeBase>? source = null)
        {
            var dataSource = (source ?? employees).Select(employee => new
            {
                employee.Name,
                employee.LastName,
                employee.Position,
                employee.Country,
                EmployeeType = employee.GetType().Name,
                Salary = Math.Round(employee.CalculateSalary(), 2)
            }).ToList();

            employeesDataGridView.DataSource = null;
            employeesDataGridView.DataSource = dataSource;
        }

        private void employeesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}