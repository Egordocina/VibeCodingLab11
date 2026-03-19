using System.Globalization;
using Model;
using View.страдания;

namespace View
{
	/// <summary>
	/// Форма для добавления нового гонщика.
	/// </summary>
	public partial class AddEmployeeForm : Form
	{
		/// <summary>
		/// Событие создания сотрудника (для слабой связанности с MainForm).
		/// </summary>
		public event EventHandler<EmployeeBase>? EmployeeCreated;

		/// <summary>
		/// Текущая панель параметров сотрудника.
		/// </summary>
		private EmployeeParameterPanel? _currentParameterPanel;

		/// <summary>
		/// Инициализирует компоненты формы и настраивает события.
		/// </summary>
		public AddEmployeeForm()
		{
			InitializeComponent();
			ApplyStyles();
			LoadComboBoxes();

			// Создаём панель параметров по умолчанию
			UpdateParameterPanel();

#if !DEBUG
			randomButton.Visible = false;
#endif

			hourlyRadioButton.CheckedChanged += OnPaymentTypeChanged;
			salariedRadioButton.CheckedChanged += OnPaymentTypeChanged;
			commissionRadioButton.CheckedChanged += OnPaymentTypeChanged;
		}

		/// <summary>
		/// Применяет стиль Windows 11 Dark ко всем элементам формы.
		/// </summary>
		private void ApplyStyles()
		{
			StyleHelper.ApplyFormStyle(this);
			this.ApplyStyle();
		}

		/// <summary>
		/// Загружает варианты в комбо-боксы для разрядов и стран.
		/// </summary>
		private void LoadComboBoxes()
		{
			foreach (var position in EmployeeBase.PositionData.Values)
			{
				positionComboBox.Items.Add(position.Name);
			}

			foreach (var country in EmployeeBase.CountryData.Values)
			{
				countryComboBox.Items.Add(country);
			}
		}

		/// <summary>
		/// Обновляет панель параметров при изменении типа оплаты.
		/// </summary>
		private void OnPaymentTypeChanged(object? sender = null,
			EventArgs? e = null)
		{
			UpdateParameterPanel();
		}

		/// <summary>
		/// Обновляет панель параметров в зависимости от выбранного типа сотрудника.
		/// </summary>
		private void UpdateParameterPanel()
		{
			// Очищаем старую панель
			parametersGroupBox.Controls.Clear();
			_currentParameterPanel?.Dispose();

			// Создаём новую панель
			_currentParameterPanel = CreateParameterPanel();
			parametersGroupBox.Controls.Add(_currentParameterPanel);
			_currentParameterPanel.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// Создаёт панель параметров для выбранного типа сотрудника.
		/// </summary>
		/// <returns>Панель параметров.</returns>
		private EmployeeParameterPanel CreateParameterPanel()
		{
			if (hourlyRadioButton.Checked)
				return new HourlyEmployeeParameterPanel();

			if (commissionRadioButton.Checked)
				return new CommissionEmployeeParameterPanel();

			return new SalariedEmployeeParameterPanel();
		}

		/// <summary>
		/// Обработчик клика по кнопке "ОК":
		/// валидирует данные и создает сотрудника.
		/// </summary>
		private void OkButton_Click(object sender, EventArgs eventArgs)
		{
			try
			{
				ValidateCommonFields();

				var employee = CreateEmployee();

				employee.Name = CapitalizeFirstLetter(
					nameTextBox.Text.Trim());
				employee.LastName = CapitalizeFirstLetter(
					lastNameTextBox.Text.Trim());
				employee.Position =
					positionComboBox.SelectedItem?.ToString() ?? string.Empty;
				employee.Country =
					countryComboBox.SelectedItem?.ToString() ?? string.Empty;

				// Вызываем событие создания сотрудника
				EmployeeCreated?.Invoke(this, employee);
				Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(
					exception.Message,
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Создает сотрудника нужного типа.
		/// </summary>
		private EmployeeBase CreateEmployee()
		{
			if (hourlyRadioButton.Checked)
			{
				return CreateHourlyEmployee();
			}

			if (commissionRadioButton.Checked)
			{
				return CreateCommissionEmployee();
			}

			return new SalariedEmployee();
		}

		/// <summary>
		/// Создает почасового сотрудника.
		/// </summary>
		private HourlyEmployee CreateHourlyEmployee()
		{
			var panel = (HourlyEmployeeParameterPanel)_currentParameterPanel!;
			return new HourlyEmployee
			{
				HourlyRate = panel.HourlyRate,
				HoursWorked = panel.HoursWorked
			};
		}

		/// <summary>
		/// Создает сотрудника с комиссией.
		/// </summary>
		private CommissionEmployee CreateCommissionEmployee()
		{
			var panel = (CommissionEmployeeParameterPanel)_currentParameterPanel!;
			return new CommissionEmployee
			{
				BaseSalary = panel.BaseSalary,
				CommissionRate = panel.CommissionRate,
				BonusAmount = panel.BonusAmount
			};
		}

		/// <summary>
		/// Обработчик клика по кнопке "Отмена":
		/// закрывает форму без сохранения.
		/// </summary>
		private void CancelButton_Click(object sender, EventArgs eventArgs)
		{
			Close();
		}

		/// <summary>
		/// Обработчик клика по кнопке "Создать случайного
		/// гонщика": заполняет поля случайными данными.
		/// </summary>
		private void RandomButton_Click(object sender, EventArgs eventArgs)
		{
			var random = new Random();
			var cultureInfo = CultureInfo.InvariantCulture;
			string[] maleNames = {
				"Мирослав",
				"Борислав",
				"Добромир",
				"Твердислав",
				"Неждан",
				"Первуша",
				"Вторак",
				"Истома",
				"Мстислав",
				"Ярослав",
				"Владимир"
			};

			string[] femaleNames = {
				"Людмила",
				"Ярослава",
				"Святослава",
				"Милослава",
				"Доброслава",
				"Звенислава",
				"Предслава",
				"Ждана",
				"Млада",
				"Бронислава",
				"Предслава"
			};

			string[] maleLastNames = {
				"Рюрикович",
				"Мономахов",
				"Изяславич",
				"Новгородец",
				"Молчун",
				"Смеян",
				"Рыбарь",
				"Коваль",
				"Оболенский",
				"Бел",
				"Кузнецов"
			};

			string[] femaleLastNames = {
				"Рюрикович",
				"Мономахова",
				"Изяславич",
				"Новгородец",
				"Молчун",
				"Смеян",
				"Рыбарь",
				"Коваль",
				"Оболенская",
				"Бел",
				"Кузнецова"
			};

			bool isMale = random.Next(2) == 0;
			string name = isMale
				? maleNames[random.Next(maleNames.Length)]
				: femaleNames[random.Next(femaleNames.Length)];

			string lastName = isMale
				? maleLastNames[random.Next(maleLastNames.Length)]
				: femaleLastNames[random.Next(femaleLastNames.Length)];

			nameTextBox.Text = name;
			lastNameTextBox.Text = lastName;
			positionComboBox.SelectedIndex =
				random.Next(positionComboBox.Items.Count);
			countryComboBox.SelectedIndex =
				random.Next(countryComboBox.Items.Count);
			int type = random.Next(3);
			hourlyRadioButton.Checked = type == 0;
			salariedRadioButton.Checked = type == 1;
			commissionRadioButton.Checked = type == 2;

			// Обновляем панель и заполняем случайными значениями
			UpdateParameterPanel();
			FillRandomParameterValues(random, cultureInfo);
		}

		/// <summary>
		/// Заполняет случайными значениями поля параметров в зависимости от типа панели.
		/// </summary>
		/// <param name="random">Генератор случайных чисел.</param>
		/// <param name="cultureInfo">Культура для форматирования чисел.</param>
		private void FillRandomParameterValues(Random random, CultureInfo cultureInfo)
		{
			if (_currentParameterPanel is HourlyEmployeeParameterPanel hourlyPanel)
			{
				hourlyPanel.HourlyRate = random.Next(1000, 2000) / 10.0;
				hourlyPanel.HoursWorked = random.Next(160, 200);
			}
			else if (_currentParameterPanel is CommissionEmployeeParameterPanel commissionPanel)
			{
				commissionPanel.BaseSalary = random.Next(30000, 80000) / 100.0;
				commissionPanel.CommissionRate = random.Next(10, 25);
				commissionPanel.BonusAmount = random.Next(5000, 30000) / 100.0;
			}
			// SalariedEmployeeParameterPanel не имеет полей для заполнения
		}

		/// <summary>
		/// Валидирует общие поля: имя, фамилию, разряд, страну.
		/// </summary>
		private void ValidateCommonFields()
		{
			var namePattern = @"^[а-яА-ЯёЁa-zA-Z\s]+$";
			if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
				!System.Text.RegularExpressions.Regex.IsMatch(
					nameTextBox.Text.Trim(), namePattern))
			{
				throw new IncorrectArgumentException(
					"Имя должно содержать только буквы и не быть пустым.");
			}

			if (string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
				!System.Text.RegularExpressions.Regex.IsMatch(
					lastNameTextBox.Text.Trim(), namePattern))
			{
				throw new IncorrectArgumentException(
					"Фамилия должна содержать только буквы " +
					"и не быть пустой.");
			}

			// Проверяем, что имя и фамилия введены на одном языке
			if (!AreSameLanguage(nameTextBox.Text.Trim(), 
				lastNameTextBox.Text.Trim()))
			{
				throw new IncorrectArgumentException(
					"Имя и фамилия должны быть введены на одном языке.");
			}

			if (positionComboBox.SelectedIndex < 0 ||
				string.IsNullOrEmpty(
					positionComboBox.SelectedItem?.ToString()))
			{
				throw new IncorrectArgumentException(
					"Разряд должна быть выбрана.");
			}

			if (countryComboBox.SelectedIndex < 0 ||
				string.IsNullOrEmpty(
					countryComboBox.SelectedItem?.ToString()))
			{
				throw new IncorrectArgumentException(
					"Страна должна быть выбрана.");
			}
		}

		/// <summary>
		/// Проверяет, что оба текста введены на одном языке 
		/// (кириллица или латиница).
		/// </summary>
		private bool AreSameLanguage(string text1, string text2)
		{
			if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
			{
				return true;
			}

			// Проверяем первую букву каждого текста
			bool isCyrillic1 = IsCyrillic(text1[0]);
			bool isCyrillic2 = IsCyrillic(text2[0]);

			return isCyrillic1 == isCyrillic2;
		}

		/// <summary>
		/// Проверяет, является ли символ кириллическим.
		/// </summary>
		private bool IsCyrillic(char c)
		{
			return (c >= 'а' && c <= 'я') || 
				(c >= 'А' && c <= 'Я') || 
				c == 'ё' || c == 'Ё';
		}

		/// <summary>
		/// Парсит строку в double с валидацией.
		/// </summary>
		private double ParseDouble(string input, string field)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				throw new IncorrectArgumentException(
					$"{field} должно быть числом.");
			}
			// Нормализуем: точка - запятая
			var normalized = input.Trim().Replace('.', ',');

			if (!double.TryParse(
				normalized, NumberStyles.Any,
				CultureInfo.CurrentCulture, out var value))
			{
				throw new IncorrectArgumentException(
					$"{field} должно быть числом.");
			}

			if (double.IsNaN(value) || double.IsInfinity(value))
			{
				throw new IncorrectArgumentException(
					$"{field} должно быть корректным числом.");
			}

			if (value < 0)
			{
				throw new IncorrectArgumentException(
					$"{field} не может быть отрицательным.");
			}

			return value;
		}

		/// <summary>
		/// Преобразует первую букву каждого слова в заглавную.
		/// </summary>
		/// <param name="text">Исходный текст.</param>
		/// <returns>Текст с заглавными буквами.</returns>
		private string CapitalizeFirstLetter(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return text;
			}

			var cultureInfo = CultureInfo.CurrentCulture;
			var words = text.Split(
			new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var capitalizedWords = new List<string>();

			foreach (var word in words)
			{
				if (word.Length > 0)
				{
					var capitalizedWord = char.ToUpper(word[0], cultureInfo) +
						word.Substring(1).ToLower(cultureInfo);
					capitalizedWords.Add(capitalizedWord);
				}
			}

			return string.Join(" ", capitalizedWords);
		}
	}
}
