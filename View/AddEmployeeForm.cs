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
		/// Созданный гонщик или null, если не создан.
		/// </summary>
		public EmployeeBase? CreatedEmployee { get; private set; }

		/// <summary>
		/// Инициализирует компоненты формы и настраивает события.
		/// </summary>
		public AddEmployeeForm()
		{
			InitializeComponent();
			LoadComboBoxes();
			UpdateParameterLabels();
			hourlyRadioButton.CheckedChanged += (sender, eventArgs) => UpdateParameterLabels();
			salariedRadioButton.CheckedChanged += (sender, eventArgs) => UpdateParameterLabels();
			commissionRadioButton.CheckedChanged += (sender, eventArgs) => UpdateParameterLabels();
		}

		/// <summary>
		/// Загружает варианты в комбо-боксы для разрядов и стран.
		/// </summary>
		private void LoadComboBoxes()
		{
			positionComboBox.Items.AddRange(new object[] {
				"3 разряд",
				"2 разряд",
				"1 разряд",
				"КМС",
				"МС",
				"МСМК"
			});

			countryComboBox.Items.AddRange(new object[] {
				"РОССИЯ",
				"ФРАНЦИЯ",
				"НОРВЕГИЯ",
				"ГЕРМАНИЯ",
				"ФИНЛЯНДИЯ",
				"КАНАДА",
				"ИТАЛИЯ",
				"ЧЕХИЯ",
				"ШВЕЦИЯ"
			});
		}

		/// <summary>
		/// Обновляет лейблы и видимость параметров в зависимости от типа оплаты.
		/// </summary>
		private void UpdateParameterLabels()
		{
			if (hourlyRadioButton.Checked)
			{
				parameter1Label.Text = "Почасовая ставка:";
				parameter2Label.Text = "Отработанные часы:";
				parameter3Label.Visible = false;
				parameter3TextBox.Visible = false;
				parameter2Label.Visible = true;
				parameter2TextBox.Visible = true;
				parameter1Label.Visible = true;
				parameter1TextBox.Visible = true;
			}
			else if (salariedRadioButton.Checked)
			{
				parameter1Label.Text = "(нет доп. параметров)";
				parameter2Label.Visible = false;
				parameter2TextBox.Visible = false;
				parameter3Label.Visible = false;
				parameter3TextBox.Visible = false;
				parameter1Label.Visible = false;
				parameter1TextBox.Visible = false;
			}
			else
			{
				parameter1Label.Text = "Базовая зарплата:";
				parameter2Label.Text = "Ставка премии (%):";
				parameter3Label.Text = "Сумма премии:";
				parameter2Label.Visible = true;
				parameter2TextBox.Visible = true;
				parameter3Label.Visible = true;
				parameter3TextBox.Visible = true;
				parameter1Label.Visible = true;
				parameter1TextBox.Visible = true;
			}
		}

		/// <summary>
		/// Обработчик клика по кнопке "ОК":
		/// валидирует данные и создает гонщика.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void okButton_Click(object sender, EventArgs eventArgs)
		{
			try
			{
				ValidateCommonFields();
				EmployeeBase employee;
				if (hourlyRadioButton.Checked)
				{
					var hourlyEmployee = new HourlyEmployee();
					hourlyEmployee.HourlyRate = ParseDouble(parameter1TextBox.Text, "Почасовая ставка");
					hourlyEmployee.HoursWorked = ParseDouble(parameter2TextBox.Text, "Отработанные часы");
					employee = hourlyEmployee;
				}
				else if (commissionRadioButton.Checked)
				{
					var commissionEmployee = new CommissionEmployee();
					commissionEmployee.BaseSalary = ParseDouble(parameter1TextBox.Text, "Базовая зарплата");
					commissionEmployee.CommissionRate = ParseDouble(parameter2TextBox.Text, "Ставка премии");
					commissionEmployee.BonusAmount = ParseDouble(parameter3TextBox.Text, "Сумма премии");
					employee = commissionEmployee;
				}
				else
				{
					employee = new SalariedEmployee();
				}

				employee.Name = nameTextBox.Text;
				employee.LastName = lastNameTextBox.Text;
				employee.Position = positionComboBox.SelectedItem?.ToString() ?? string.Empty;
				employee.Country = countryComboBox.SelectedItem?.ToString() ?? string.Empty;
				CreatedEmployee = employee;
				DialogResult = DialogResult.OK;
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
		/// Обработчик клика по кнопке "Отмена": закрывает форму без сохранения.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void cancelButton_Click(object sender, EventArgs eventArgs)
		{
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Обработчик клика по кнопке "Создать случайного гонщика": заполняет поля случайными данными.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="eventArgs">Аргументы события.</param>
		private void randomButton_Click(object sender, EventArgs eventArgs)
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

			// Случайный пол (0 - мужской, 1 - женский)
			bool isMale = random.Next(2) == 0;
			// Выбор имени и фамилии по роду
			string name = isMale
				? maleNames[random.Next(maleNames.Length)]
				: femaleNames[random.Next(femaleNames.Length)];

			string lastName = isMale
				? maleLastNames[random.Next(maleLastNames.Length)]
				: femaleLastNames[random.Next(femaleLastNames.Length)];

			nameTextBox.Text = name;
			lastNameTextBox.Text = lastName;
			positionComboBox.SelectedIndex = random.Next(positionComboBox.Items.Count);
			// Выбираем случайно из списка
			countryComboBox.SelectedIndex = random.Next(countryComboBox.Items.Count);
			// Выбор типа
			int type = random.Next(3);
			hourlyRadioButton.Checked = type == 0;
			salariedRadioButton.Checked = type == 1;
			commissionRadioButton.Checked = type == 2;
			// Параметры по типу
			if (hourlyRadioButton.Checked)
			{
				parameter1TextBox.Text = (random.Next(1000, 2000) / 10.0).ToString("F1", cultureInfo);
				// Ставка 100.0 - 200.0 руб/час
				parameter2TextBox.Text = random.Next(160, 200).ToString();
				// Часы 160-200 в месяц
			}
			else if (commissionRadioButton.Checked)
			{
				parameter1TextBox.Text = (random.Next(30000, 80000) / 100.0).ToString("F2", cultureInfo);
				// Базовая 300.00 - 800.00 руб.
				parameter2TextBox.Text = random.Next(10, 25).ToString();
				// % 10-25%
				parameter3TextBox.Text = (random.Next(5000, 30000) / 100.0).ToString("F2", cultureInfo);
				// Сумма 50.00 - 300.00 руб.
			}

			// Обновляем видимость параметров
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
					nameTextBox.Text.Trim(),
					namePattern))
			{
				throw new IncorrectArgumentException(
					"Имя должно содержать только буквы и не быть пустым.");
			}

			if (string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
				!System.Text.RegularExpressions.Regex.IsMatch(
					lastNameTextBox.Text.Trim(),
					namePattern))
			{
				throw new IncorrectArgumentException(
					"Фамилия должна содержать только буквы и не быть пустой.");
			}

			if (positionComboBox.SelectedIndex < 0 ||
				string.IsNullOrEmpty(positionComboBox.SelectedItem?.ToString()))
			{
				throw new IncorrectArgumentException(
					"Разряд должна быть выбрана.");
			}

			if (countryComboBox.SelectedIndex < 0 ||
				string.IsNullOrEmpty(countryComboBox.SelectedItem?.ToString()))
			{
				throw new IncorrectArgumentException(
					"Страна должна быть выбрана.");
			}
		}

		/// <summary>
		/// Парсит строку в double с валидацией.
		/// </summary>
		/// <param name="input">Строка для парсинга.</param>
		/// <param name="field">Название поля для сообщения об ошибке.</param>
		/// <returns>Парсированное значение.</returns>
		/// <exception cref="IncorrectArgumentException">
		/// Если строка не число или отрицательное.
		/// </exception>
		private double ParseDouble(string input, string field)
		{
			if (string.IsNullOrWhiteSpace(input) ||
				!double.TryParse(
					input,
					NumberStyles.Any,
					CultureInfo.InvariantCulture,
					out var value))
			{
				throw new IncorrectArgumentException(
					$"{field} должно быть числом.");
			}

			if (value < 0)
			{
				throw new IncorrectArgumentException(
					$"{field} не может быть отрицательным.");
			}

			return value;
		}
	}
}