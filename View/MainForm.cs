using Model;
using System.ComponentModel;
using View;

namespace View
{
    /// <summary>
    /// Главная форма для управления списком гонщиков.
    /// </summary>
    public partial class MainForm : Form
    {
        //TODO: RSDN+
        /// <summary>
        /// Список гонщиков.
        /// </summary>
        private List<EmployeeBase> employees = new List<EmployeeBase>();

        /// <summary>
        /// Источник данных для привязки к DataGridView.
        /// </summary>
        private readonly BindingSource _bindingSource = new();

        /// <summary>
        /// Инициализирует компоненты формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Инициализация BindingSource
            _bindingSource.DataSource = employees;
            employeesDataGridView.DataSource = _bindingSource;

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
            employeesDataGridView.AutoGenerateColumns = true;
            employeesDataGridView.Columns.Clear();
            
            employeesDataGridView.ColumnAdded += (s, e) =>
            {
                if (e.Column.DataPropertyName == nameof(EmployeeBase.Salary))
                {
                    e.Column.ReadOnly = true;
                }
            };
        }

        /// <summary>
        /// Обработчик клика по кнопке "Добавить":
        /// открывает форму добавления.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs eventArgs)
        {
            using var addEmployeeForm = new AddEmployeeForm();
            if (addEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                if (addEmployeeForm.CreatedEmployee != null)
                {
                    employees.Add(addEmployeeForm.CreatedEmployee);
                    _bindingSource.ResetBindings(false);
                }
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке "Удалить":
        /// удаляет выбранного гонщика.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs eventArgs)
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
                    _bindingSource.ResetBindings(false);
                }
            }
        }

        /// <summary>
        /// Обработчик клика по кнопке "Поиск": открывает форму поиска.
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs eventArgs)
        {
            var searchForm = new SearchForm(employees);
            searchForm.EmployeesSelected += RefreshGrid;
            searchForm.Show();
        }

        /// <summary>
        /// Обработчик клика по кнопке "Сохранить":
        /// сохраняет данные в файл.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs eventArgs)
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
        private void LoadButton_Click(object sender, EventArgs eventArgs)
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
                    _bindingSource.DataSource = employees;
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
        /// Обновляет данные в DataGridView (для поиска).
        /// </summary>
        private void RefreshGrid(IEnumerable<EmployeeBase>? source = null)
        {
            _bindingSource.DataSource = source ?? employees;
        }
    }
}
