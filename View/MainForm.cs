using Model;
using System.ComponentModel;
using View;
using View.Services;

namespace View
{
	/// <summary>
	/// Главная форма для управления списком гонщиков.
	/// </summary>
	public partial class MainForm : Form
	{
		//TODO: мультиделит + шизоделитинг
		/// <summary>
		/// Список гонщиков.
		/// </summary>
		private List<EmployeeBase> _employees = new List<EmployeeBase>();

		/// <summary>
		/// Источник данных для привязки к DataGridView.
		/// </summary>
		private readonly BindingSource _bindingSource = new();

		/// <summary>
		/// Сервис управления выделением.
		/// </summary>
		private readonly ISelectionService<EmployeeBase> _selectionService;

		/// <summary>
		/// Инициализирует компоненты формы.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			_selectionService = new SelectionService<EmployeeBase>();

			// Инициализация BindingSource
			_bindingSource.DataSource = _employees;
			employeesDataGridView.DataSource = _bindingSource;

			ApplyStyles();
			InitializeGridColumns();
			InitializeToolbar();
			RefreshGrid();
		}

		/// <summary>
		/// Применяет стиль Windows 11 Dark ко всем элементам формы.
		/// </summary>
		private void ApplyStyles()
		{
			StyleHelper.ApplyFormStyle(this);
			StyleHelper.ApplyButtonStyle(addButton);
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
			employeesDataGridView.MultiSelect = true;
			employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
		/// Инициализирует панель инструментов.
		/// </summary>
		private void InitializeToolbar()
		{
			var toolStrip = new ToolStrip();

			var selectAllBtn = new ToolStripButton("Выделить все");
			selectAllBtn.Click += (s, e) => _selectionService.SelectAll(employeesDataGridView);

			var deselectAllBtn = new ToolStripButton("Снять выделение");
			deselectAllBtn.Click += (s, e) => _selectionService.DeselectAll(employeesDataGridView);

			var invertBtn = new ToolStripButton("Инвертировать");
			invertBtn.Click += (s, e) => _selectionService.InvertSelection(employeesDataGridView);

			var deleteBtn = new ToolStripButton("Удалить выбранные");
			deleteBtn.Click += DeleteSelected_Click;

			toolStrip.Items.AddRange(new ToolStripItem[] { selectAllBtn, deselectAllBtn, invertBtn, deleteBtn });

			StyleHelper.ApplyToolStripStyle(toolStrip);
			Controls.Add(toolStrip);
		}

		/// <summary>
		/// Обработчик клика по кнопке "Добавить":
		/// открывает форму добавления.
		/// </summary>
		private void AddButton_Click(object sender, EventArgs eventArgs)
		{
			var addEmployeeForm = new AddEmployeeForm();
			addEmployeeForm.EmployeeCreated += (s, employee) =>
			{
				_employees.Add(employee);
				_bindingSource.ResetBindings(false);
			};
			addEmployeeForm.Show();
		}

		/// <summary>
		/// Удаляет выбранных гонщиков.
		/// </summary>
		private void DeleteSelected()
		{
			int count = _selectionService.GetSelectedCount(employeesDataGridView);
			if (count == 0)
			{
				MessageBox.Show(
					"Выберите гонщиков для удаления.",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			if (MessageBox.Show(
				$"Удалить {count} гонщиков?",
				"Подтверждение",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_selectionService.DeleteSelected(_employees, employeesDataGridView);
				_bindingSource.ResetBindings(false);
			}
		}

		/// <summary>
		/// Обработчик кнопки "Удалить выбранные" на панели инструментов.
		/// </summary>
		private void DeleteSelected_Click(object sender, EventArgs e)
		{
			DeleteSelected();
		}

		/// <summary>
		/// Обработчик клика по кнопке "Поиск": открывает форму поиска.
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs eventArgs)
		{
			var searchForm = new SearchForm(_employees);
			searchForm.EmployeesSelected += (s, args) => RefreshGrid(args);
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
						_employees, saveFileDialog.FileName);
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
					_employees = new List<EmployeeBase>(loadedList);
					_bindingSource.DataSource = _employees;
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
			_bindingSource.DataSource = source ?? _employees;
		}
	}
}
