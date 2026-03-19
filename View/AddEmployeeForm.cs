using System.Globalization;
using Model;

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
		/// Массивы контролов для полиморфной обработки параметров.
		/// </summary>
		private readonly Control[] _parameterLabels;

		//TODO: XML
		private readonly Control[] _parameterTextBoxes;

		/// <summary>
		/// Конфигурация текстов лейблов для каждого типа сотрудника.
		/// </summary>
		private static readonly string[][] _labelConfigs =
		[
			["Почасовая ставка:", "Отработанные часы:"],
			[],
			["Базовая зарплата:", "Ставка премии (%):", "Сумма премии:"]
		];

		/// <summary>
		/// Инициализирует компоненты формы и настраивает события.
		/// </summary>
		public AddEmployeeForm()
		{
			InitializeComponent();
			ApplyStyles();
			LoadComboBoxes();

			// Инициализация массивов контролов для полиморфной обработки
			_parameterLabels = 
				[parameter1Label, parameter2Label, parameter3Label];
			_parameterTextBoxes = 
				[parameter1TextBox, parameter2TextBox, parameter3TextBox];

			UpdateParameterLabels();

#if !DEBUG
			randomButton.Visible = false;
#endif

			hourlyRadioButton.CheckedChanged += UpdateParameterLabels;
			salariedRadioButton.CheckedChanged += UpdateParameterLabels;
			commissionRadioButton.CheckedChanged += UpdateParameterLabels;
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
		/// Обновляет лейблы и видимость параметров в зависимости от типа оплаты.
		/// </summary>
		private void UpdateParameterLabels(object? sender = null, 
			EventArgs? e = null)
		{
			var configIndex = hourlyRadioButton.Checked 
								? 0 
								: salariedRadioButton.Checked 
									? 1
									: 2;
			var config = _labelConfigs[configIndex];

			// Полиморфная обработка контролов через массивы
			for (int i = 0; i < 3; i++)
			{
				var visible = i < config.Length;
				_parameterLabels[i].Visible = visible;
				_parameterTextBoxes[i].Visible = visible;

				if (visible && i < config.Length)
					((Label)_parameterLabels[i]).Text = config[i];
			}
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
			//TODO: {}
			if (hourlyRadioButton.Checked)
				return CreateHourlyEmployee();

			//TODO: {}
			if (commissionRadioButton.Checked)
				return CreateCommissionEmployee();

			return new SalariedEmployee();
		}

		/// <summary>
		/// Создает почасового сотрудника.
		/// </summary>
		private HourlyEmployee CreateHourlyEmployee() => new()
		{
			HourlyRate = ParseDouble(
				parameter1TextBox.Text, "Почасовая ставка"),
			HoursWorked = ParseDouble(
				parameter2TextBox.Text, "Отработанные часы")
		};

		/// <summary>
		/// Создает сотрудника с комиссией.
		/// </summary>
		private CommissionEmployee CreateCommissionEmployee() => new()
		{
			BaseSalary = ParseDouble(
				parameter1TextBox.Text, "Базовая зарплата"),
			CommissionRate = ParseDouble(
				parameter2TextBox.Text, "Ставка премии"),
			BonusAmount = ParseDouble(
				parameter3TextBox.Text, "Сумма премии")
		};

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

			// Очищаем все поля параметров
			foreach (var textBox in _parameterTextBoxes)
				textBox.Text = string.Empty;

			// Заполняем в зависимости от типа
			if (hourlyRadioButton.Checked)
			{
				parameter1TextBox.Text = (random.Next(1000, 2000) / 10.0)
					.ToString("F1", cultureInfo);
				parameter2TextBox.Text = random.Next(160, 200).ToString();
			}
			else if (commissionRadioButton.Checked)
			{
				parameter1TextBox.Text =
					(random.Next(30000, 80000) / 100.0).ToString(
						"F2", cultureInfo);
				parameter2TextBox.Text = random.Next(10, 25).ToString();
				parameter3TextBox.Text =
					(random.Next(5000, 30000) / 100.0).ToString(
						"F2", cultureInfo);
			}

			UpdateParameterLabels();
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
