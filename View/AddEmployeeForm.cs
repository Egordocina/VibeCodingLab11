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
        /// Инициализирует компоненты формы и настраивает события.
        /// </summary>
        public AddEmployeeForm()
        {
            InitializeComponent();
            ApplyStyles();
            LoadComboBoxes();
            UpdateParameterLabels();
            hourlyRadioButton.CheckedChanged +=
                (sender, eventArgs) => UpdateParameterLabels();
            salariedRadioButton.CheckedChanged +=
                (sender, eventArgs) => UpdateParameterLabels();
            commissionRadioButton.CheckedChanged +=
                (sender, eventArgs) => UpdateParameterLabels();
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
        /// Обновляет лейблы и видимость параметров
        /// в зависимости от типа оплаты.
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
        private void OkButton_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                ValidateCommonFields();
                EmployeeBase employee;
                if (hourlyRadioButton.Checked)
                {
                    var hourlyEmployee = new HourlyEmployee();
                    hourlyEmployee.HourlyRate = ParseDouble(
                        parameter1TextBox.Text, "Почасовая ставка");
                    hourlyEmployee.HoursWorked = ParseDouble(
                        parameter2TextBox.Text, "Отработанные часы");
                    employee = hourlyEmployee;
                }
                else if (commissionRadioButton.Checked)
                {
                    var commissionEmployee = new CommissionEmployee();
                    commissionEmployee.BaseSalary = ParseDouble(
                        parameter1TextBox.Text, "Базовая зарплата");
                    commissionEmployee.CommissionRate = ParseDouble(
                        parameter2TextBox.Text, "Ставка премии");
                    commissionEmployee.BonusAmount = ParseDouble(
                        parameter3TextBox.Text, "Сумма премии");
                    employee = commissionEmployee;
                }
                else
                {
                    employee = new SalariedEmployee();
                }

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
        /// Парсит строку в double с валидацией.
        /// </summary>
        private double ParseDouble(string input, string field)
        {
            if (string.IsNullOrWhiteSpace(input) ||
                !double.TryParse(
                    input,NumberStyles.Any,
                    CultureInfo.InvariantCulture,out var value))
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
