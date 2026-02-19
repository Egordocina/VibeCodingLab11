using Model;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ConsoleLoader
{
	/// <summary>
	/// Основной класс программы для расчета зарплат сотрудников(гонщиков) лыжной команды 
	/// "Сутулые псы".
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Создаёт сотрудника, отображает зарплату и возвращает сотрудника.
		/// </summary>
		/// <typeparam name="T">Тип сотрудника.</typeparam>
		/// <param name="handlers">Список обработчиков свойств.</param>
		/// <returns>Созднный сотрудник с отображённой зарплатой.</returns>
		private static IEmployee CreateAndShowEmployee<T>(List<PropertyHandlerDTO> handlers)
			where T : EmployeeBase, new()
		{
			var employee = CreateEmployee<T>(handlers);
			return ShowSalary(employee);
		}

		/// <summary>
		/// Точка входа
		/// </summary>
		public static void Main()
		{
			Console.WriteLine("Расчет зарплат членов лыжной комнанды \"Сутулые псы\"");

			var employeeList = new List<IEmployee>();
			while (true)
			{
				// Переменная-ссылка на интерфейс
				IEmployee employee;
				switch (SelectEmployeeType())
				{
					case 1:
						{
							// Присваивание экземпляра класса HourlyEmployee в переменную
							// интерфейса
							employee = CreateAndShowEmployee<HourlyEmployee>(
							GetPropertyHandlersForHourly());
							employeeList.Add(employee);
							break;
						}
					case 2:
						{
							// Присваивание экземпляра класса SalariedEmployee в переменную
							// интерфейса
							employee = CreateAndShowEmployee<SalariedEmployee>(
							GetPropertyHandlersForSalaried());
							employeeList.Add(employee);
							break;
						}

					case 3:
						{
							// Присваивание экземпляра класса CommissionEmployee в переменную
							// интерфейса
							employee = CreateAndShowEmployee<CommissionEmployee>(
							GetPropertyHandlersForCommission());
							employeeList.Add(employee);
							break;
						}

					case 4:
						return;
				}
			}
		}

		/// <summary>
		/// Создание сотрудника с использованием обработчиков свойств.
		/// </summary>
		/// <typeparam name="T">Тип сотрудника.</typeparam>
		/// <param name="handlers">Список обработчиков.</param>
		/// <returns>Сотрудник.</returns>
		private static T CreateEmployee<T>(List<PropertyHandlerDTO> handlers)
			where T : EmployeeBase, new()
		{
			var employee = new T();
			foreach (var handler in handlers)
			{
				ActionHandlerWithDTO(employee, handler);
			}
			return (T)employee;
		}

		/// <summary>
		/// Валидация и установка строкового свойства.
		/// </summary>
		/// <param name="input">Введённое значение.</param>
		/// <param name="setter">Действие установки значения.</param>
		/// <param name="errorMessage">Сообщение об ошибке.</param>
		private static void ValidateAndSetProperty(
			string input,
			Action<string> setter,
			string errorMessage)
		{
			if (!Regex.IsMatch(input ?? "", @"^[а-яА-Яa-zA-Z\s]+$"))
			{
				throw new IncorrectArgumentException(errorMessage);
			}
			setter(CapitalizeFirstLetter(input));
		}

		/// <summary>
		/// Получение общих обработчиков для всех типов сотрудников.
		/// </summary>
		/// <returns>Список общих обработчиков.</returns>
		private static List<PropertyHandlerDTO> GetCommonPropertyHandlers()
		{
			var exceptionTypesString = new List<Type>
			{
				typeof(IncorrectArgumentException)
			};
			return new List<PropertyHandlerDTO>
			{
				new PropertyHandlerDTO("Имя гонщика", exceptionTypesString,
					emp =>
					{
						var input = Console.ReadLine();
						ValidateAndSetProperty(input, val => emp.Name = val,
							"Имя должно содержать только буквы.");
					}),
				new PropertyHandlerDTO("Фамилия гонщика", exceptionTypesString,
					emp =>
					{
						var input = Console.ReadLine();
						ValidateAndSetProperty(input, val => emp.LastName = val,
							"Фамилия должна содержать только буквы.");
					}),
				new PropertyHandlerDTO("Разряд (выберите из списка ниже)",
					exceptionTypesString,
					emp => emp.Position = SelectPosition()),
				new PropertyHandlerDTO("Страна выступления (выберите из списка ниже)",
					exceptionTypesString,
					emp => emp.Country = SelectDepartment())
			};
		}

		/// <summary>
		/// Получение обработчиков для гонщика с почасовой оплатой.
		/// </summary>
		/// <returns>Список обработчиков.</returns>
		private static List<PropertyHandlerDTO> GetPropertyHandlersForHourly()
		{
			var exceptionTypesNumeric = new List<Type>
			{
				typeof(IncorrectArgumentException),
				typeof(FormatException)
			};
			var common = GetCommonPropertyHandlers();
			common.Add(new PropertyHandlerDTO("Почасовая ставка",
				exceptionTypesNumeric,
				emp => ((HourlyEmployee)emp).HourlyRate =
					Convert.ToDouble(Console.ReadLine())));
			common.Add(new PropertyHandlerDTO("Отработанные часы",
				exceptionTypesNumeric,
				emp => ((HourlyEmployee)emp).HoursWorked =
					Convert.ToDouble(Console.ReadLine())));
			return common;
		}

		/// <summary>
		/// Получение обработчиков для гонщика по окладу.
		/// </summary>
		/// <returns>Список обработчиков.</returns>
		private static List<PropertyHandlerDTO> GetPropertyHandlersForSalaried()
		{
			return GetCommonPropertyHandlers();
		}

		/// <summary>
		/// Получение обработчиков для гонщика с комиссионными.
		/// </summary>
		/// <returns>Список обработчиков.</returns>
		private static List<PropertyHandlerDTO> GetPropertyHandlersForCommission()
		{
			var exceptionTypesNumeric = new List<Type>
			{
				typeof(IncorrectArgumentException),
				typeof(FormatException)
			};
			var common = GetCommonPropertyHandlers();
			common.Add(new PropertyHandlerDTO("Базовая зарплата",
				exceptionTypesNumeric,
				emp => ((CommissionEmployee)emp).BaseSalary =
					Convert.ToDouble(Console.ReadLine())));
			common.Add(new PropertyHandlerDTO("Ставка премии (%)",
				exceptionTypesNumeric,
				emp => ((CommissionEmployee)emp).CommissionRate =
					Convert.ToDouble(Console.ReadLine())));
			common.Add(new PropertyHandlerDTO("Сумма премии (руб., за KPI)",
				exceptionTypesNumeric,
				emp => ((CommissionEmployee)emp).BonusAmount =
					Convert.ToDouble(Console.ReadLine())));
			return common;
		}

		/// <summary>
		/// Выбор разряда из предложенного списка.
		/// </summary>
		/// <returns>Выбранный разряд.</returns>
		private static string SelectPosition()
		{
			Console.WriteLine("\nДоступные разряды:");
			foreach (var pos in EmployeeBase.PositionData)
			{
				Console.WriteLine($"{pos.Key} - {pos.Value.Name}");
			}

			while (true)
			{
				Console.WriteLine("Введите номер разряда:");
				if (int.TryParse(Console.ReadLine(), out int choice)
					&& EmployeeBase.PositionData.ContainsKey(choice))
				{
					return EmployeeBase.PositionData[choice].Name;
				}
				Console.WriteLine("Неверный выбор. Повторите ввод.");
			}
		}

		/// <summary>
		/// Выбор страны гражданства из предложенного списка.
		/// </summary>
		/// <returns>Выбранная страна.</returns>
		private static string SelectDepartment()
		{
			var departments = new Dictionary<int, string>
			{
				{1, "РОССИЯ"},
				{2, "ФРАНЦИЯ"},
				{3, "НОРВЕГИЯ"},
				{4, "ГЕРМАНИЯ"},
				{5, "ФИНЛЯНДИЯ"},
				{6, "КАНАДА"},
				{7, "ИТАЛИЯ"},
				{8, "ЧЕХИЯ"},
				{9, "ШВЕЦИЯ"},
			};

			Console.WriteLine("\nДоступные страны:");
			foreach (var dep in departments)
			{
				Console.WriteLine($"{dep.Key} - {dep.Value}");
			}

			while (true)
			{
				Console.WriteLine("Введите номер страны:");
				if (int.TryParse(Console.ReadLine(), out int choice)
					&& departments.ContainsKey(choice))
				{
					return departments[choice];
				}
				Console.WriteLine("Неверный выбор. Повторите ввод.");
			}
		}

		/// <summary>
		/// Обработчик действий с DTO.
		/// </summary>
		/// <param name="employee">гонщик.</param>
		/// <param name="dto">DTO обработчика.</param>
		private static void ActionHandlerWithDTO(IEmployee employee, 
			PropertyHandlerDTO dto)
		{
			while (true)
			{
				Console.WriteLine($"\nВведите {dto.PropertyName}:");
				try
				{
					dto.PropertyHandlingAction(employee);
					return;
				}
				catch (Exception exception)
				{
					if (dto.ExceptionTypes.Contains(exception.GetType()))
					{
						if (exception is FormatException)
						{
							Console.WriteLine("Значение должно быть числом.");
						}
						else
						{
							Console.WriteLine(exception.Message);
						}
						Console.WriteLine("Повторите ввод");
					}
					else
					{
						// Неожиданное исключение
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Отображение зарплаты с помощью консоли.
		/// </summary>
		/// <param name="employee">гонщик.</param>
		/// <returns>Работник.</returns>
		public static IEmployee ShowSalary(IEmployee employee)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine($"Зарплата для {employee.Name} {employee.LastName} " +
							  $"({employee.Position}, {employee.Country}): " +
							  $"{Math.Round(employee.CalculateSalary(), 2)} руб.");
			Console.ForegroundColor = ConsoleColor.White;
			return employee;
		}

		/// <summary>
		/// Выбирает тип гонщика на основе ввода пользователя.
		/// </summary>
		/// <returns>
		/// Код типа гонщика: 1 - почасовая оплата,
		/// 2 - оплата по окладу, 3 - оплата по ставке.
		/// 4 - выход.
		/// </returns>
		public static int SelectEmployeeType()
		{
			const int MinValueChoice = 1;
			const int MaxValueChoice = 4;

			while (true)
			{
				Console.WriteLine("\nПожалуйста, введите число:\n" +
								  "1 - почасовая оплата, 2 - оплата по окладу, " +
								  "3 - оплата по ставке, 4 - выход:");
				string input = Console.ReadLine();
				if (int.TryParse(input, out int chosenType) &&
					chosenType >= MinValueChoice &&
					chosenType <= MaxValueChoice)
				{
					return chosenType;
				}
				Console.WriteLine("Повторите ввод");
				if (!int.TryParse(input, out int _))
				{
					Console.WriteLine("Введите число.");
				}
				else
				{
					Console.WriteLine(
						$"Число должно быть в диапазоне от {MinValueChoice} " +
						$"до {MaxValueChoice}.");
				}
			}
		}

		/// <summary>
		/// Преобразует первую букву каждого слова в заглавную.
		/// </summary>
		/// <param name="text">Исходный текст.</param>
		/// <returns>Текст с заглавными первыми буквами каждого слова.</returns>
		private static string CapitalizeFirstLetter(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return text;
			}

			var cultureInfo = CultureInfo.CurrentCulture;

			// Разбиваем строку на слова по пробелам
			var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var capitalizedWords = new List<string>();

			foreach (var word in words)
			{
				if (word.Length > 0)
				{
					// Преобразуем первую букву в заглавную, остальные в строчные
					var capitalizedWord = char.ToUpper(word[0], cultureInfo) +
										 word.Substring(1).ToLower(cultureInfo);
					capitalizedWords.Add(capitalizedWord);
				}
			}

			return string.Join(" ", capitalizedWords);
		}
	}
}