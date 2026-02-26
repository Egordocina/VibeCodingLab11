using Model;
using View;

namespace View
{
    /// <summary>
    /// Главная форма для управления списком гонщиков.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список гонщиков.
        /// </summary>
        private List<EmployeeBase> employees = new List<EmployeeBase>();

        /// <summary>
        /// Инициализирует компоненты формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ApplyStyles();
            InitializeGridColumns();
            RefreshGrid();
        }

        /// <summary>
        /// Применяет стиль Windows 11 Dark ко всем элементам формы.
        /// </summary>
        private void ApplyStyles()
        {
            StyleHelper.ApplyFormStyle(this);
            StyleHelper.ApplyButtonStyle(addButton);
            StyleHelper.ApplyButtonStyle(removeButton);
            StyleHelper.ApplyButtonStyle(searchButton);
            StyleHelper.ApplyButtonStyle(saveButton);
            StyleHelper.ApplyButtonStyle(loadButton);
            StyleHelper.ApplyDataGridViewStyle(employeesDataGridView);
        }

        /// <summary>
        /// Инициализирует колонки в DataGridView.
        /// </summary>
        private void InitializeGridColumns()
        {
            employeesDataGridView.AutoGenerateColumns = false;
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
                DataPropertyName = "Country"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Тип",
                DataPropertyName = "TypeName"
            });

            employeesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Зарплата (руб.)",
                DataPropertyName = "Salary"
            });
        }

        /// <summary>
        /// Обработчик клика по кнопке "Добавить": 
        /// открывает форму добавления.
        /// </summary>
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
        /// Обработчик клика по кнопке "Удалить":
        /// удаляет выбранного гонщика.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs eventArgs)
        {
            if (employeesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите гонщика для удаления.",
                    "Ошибка",
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
        private void searchButton_Click(object sender, EventArgs eventArgs)
        {
            var searchForm = new SearchForm(employees, this);
            searchForm.Show();
        }

        /// <summary>
        /// Обработчик клика по кнопке "Сохранить":
        /// сохраняет данные в файл.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs eventArgs)
        {
            using var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы 'прикольные' (*.xaxalol)|*.xaxalol|" +
                         "JSON files (*.json)|*.json",
                DefaultExt = "xaxalol"
			};

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EmployeeSerializer.Save(
                        employees, saveFileDialog.FileName);
                    MessageBox.Show(
                        "Сохранено.",
                        "Успех",
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
        /// Обработчик клика по кнопке "Загрузить":
        /// загружает данные из файла.
        /// </summary>
        private void loadButton_Click(object sender, EventArgs eventArgs)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы 'прикольные' (*.xaxalol)|*.xaxalol|" +
                         "JSON files (*.json)|*.json",
                DefaultExt = "xaxalol"
			};

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var loadedList = EmployeeSerializer.Load(
                        openFileDialog.FileName);
                    employees = new List<EmployeeBase>(loadedList);
                    RefreshGrid();
                    MessageBox.Show(
                        "Загружено.",
                        "Успех",
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
        /// Обновляет данные в DataGridView.
        /// </summary>
        public void RefreshGrid(IEnumerable<EmployeeBase>? source = null)
        {
            var dataSource = (source ?? employees).Select(employee => new
            {
                employee.Name,
                employee.LastName,
                employee.Position,
                employee.Country,
                employee.TypeName,
                Salary = Math.Round(employee.CalculateSalary(), 2)
            }).ToList();

            employeesDataGridView.DataSource = null;
            employeesDataGridView.DataSource = dataSource;
        }

        private void employeesDataGridView_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
