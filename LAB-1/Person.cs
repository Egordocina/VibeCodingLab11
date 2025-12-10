
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LAB1
{
	//TODO: XML +
	public class Person
	{
		/// <summary>
		/// Имя
		/// </summary>
		private string _firstName = string.Empty;

		//TODO: XML +
		/// <summary>
		/// Фамилия
		/// </summary>
		private string _lastName = string.Empty;

		//TODO: XML +
		/// <summary>
		/// Возраст
		/// </summary>
		private int _age;

		//TODO: XML +
		/// <summary>
		/// Пол (согласно законодательству Российской Федерации)
		/// </summary>
		private Gender _gender;

		/// <summary>
		/// Патерн русского языка.
		/// </summary>
		private const string _russianLanguageCheck = @"(^[а-яА-Я]+-?[а-яА-Я]+$)";

		/// <summary>
		/// Патерн английского языка.
		/// </summary>
		private const string _englishLanguageCheck = @"(^[a-zA-Z]+-?[a-zA-Z]+$)";

		/// <summary>
		/// Минимальный возраст
		/// </summary>
		public const int minAge = 0;

		/// <summary>
		/// Максимальный возраст
		/// </summary>
		public const int maxAge = 123;

		/// <summary>
		/// Задание имени
		/// </summary>
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				ValidateNameOrSurname(value, "Имя");
				_firstName = CheckRegister(value);
			}
		}

		//TODO: XML +
		/// <summary>
		/// Задание Фамилии
		/// </summary>
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				ValidateNameOrSurname(value, "Фамилия");
				if (!IsNameAndSurnameValid(_firstName, value))
				{
					throw new ArgumentException
						("Фамилия может быть двойной и записана через дефис.\n" +
						 "Фамилия и имя должны быть введены на одном языке.");
				}
				_lastName = CheckRegister(value);
			}
		}

		//TODO: XML +
		/// <summary>
		/// Задание возраста
		/// </summary>
		public int Age
		{
			get		
			{ 
				return _age; 
			}
			
			set
			{
				if (value < minAge || value > maxAge)
				{
					throw new ArgumentException("Возраст должен быть в диапазоне " +
						$"{minAge} – {maxAge} лет");
				}
				_age = value;
			}
		}

		//TODO: XML +
		/// <summary>
		/// Задание пола
		/// </summary>
		public Gender Gender
		{
			get { return _gender; }
			set => _gender = value;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="firstName">Имя</param>
		/// <param name="lastName">Фамилия</param>
		/// <param name="age">Возраст</param>
		/// <param name="gender">Пол</param>
		public Person(string firstName, string lastName, int age, Gender gender)
		{
            // валидация сработает автоматически
            FirstName = firstName;
			LastName = lastName;
			Age = age;
			Gender = gender;
		}

		/// <summary>
		/// Конструктор класса по умолчанию.
		/// </summary>
		public Person() : this("Жаныкбек", "Алмагаанов", 11, Gender.Female)
		{ }

		/// <summary>
		/// Преобразование имени и фамилии в правильные регистры.
		/// </summary>
		/// <param name="name">Имя или Фамилия.</param>
		/// <returns>Имя и фамилию в правильном регистре.</returns>
		public string CheckRegister(string name)
		{
			TextInfo txt = CultureInfo.CurrentCulture.TextInfo;
			return txt.ToTitleCase(name.ToLower());
		}

		/// <summary>
		/// Проверка того, что имя или фамилия введены на одном языке.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <returns>true, если имя или фамилия введены на одном языке;
		/// false, если на разных языках.</returns>
		public bool IsNameOrSurnameValid(string name)
		{
			return (Regex.IsMatch(name, _russianLanguageCheck)
				|| Regex.IsMatch(name, _englishLanguageCheck));
		}

		/// <summary>
		/// Проверка того, что имя и фамилия введены на одном языке.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="surname">Фамилия.</param>
		/// <returns>true, если имя и фамилия введены на одном языке;
		/// false, если на разных языках.</returns>
		public bool IsNameAndSurnameValid(string name, string surname)
		{
			return (Regex.IsMatch(name, _russianLanguageCheck) &&
				Regex.IsMatch(surname, _russianLanguageCheck))
				|| (Regex.IsMatch(name, _englishLanguageCheck) &&
				Regex.IsMatch(surname, _englishLanguageCheck));
		}

		/// <summary>
		/// Валидация имени или фамилии.
		/// </summary>
		/// <param name="name">Имя или фамилия, которые необходимо проверить.</param>
		/// <param name="type">Тип (имя или фамилия) 
		/// для формирования сообщения об ошибке.</param>
		private void ValidateNameOrSurname(string name, string type)
		{
			if (!IsNameOrSurnameValid(name))
			{
				throw new ArgumentException
					($"{type} должно быть написано на одном языке.\n" +
					 $"{type} может быть двойным и записано через дефис.");
			}
		}

		//TODO: remove +
		/// <summary>
		/// Вывод на экран
		/// </summary>
		//public void Print()
		//{
		//	string genderStr;
        //    //string genderStr =
        //    //    Gender == Gender.Male
        //    //    ? "Мужской"
        //    //    : "Женский";
        //    if (Gender == Gender.Male)
		//	{
		//		genderStr = "Мужской";
		//	}
		//	else
		//	{
		//		genderStr = "Женский";
		//	}
		//	Console.WriteLine($"Имя: {FirstName} {LastName}, Возраст: {Age}, Пол: {genderStr}");
		//}

		//TODO: remove +
		/// <summary>
		/// Ввод с клавиатуры
		/// </summary>
		/// <returns>
		/// //TODO: XML</returns>
		//public static Person ReadFromKeyboard()
		//{
		//	string firstName = ReadNonEmpty("Введите имя: ");
		//	string lastName = ReadNonEmpty("Введите фамилию: ");
		//	int age = ReadAge();
		//	Gender gender = ReadGender();
		//
		//	return new Person(firstName, lastName, age, gender);
		//}
		//
		//
		//private static string ReadNonEmpty(string prompt)
		//{
		//	while (true)
		//	{
		//		Console.Write(prompt);
		//		string? input = Console.ReadLine()?.Trim();
		//		if (!string.IsNullOrWhiteSpace(input))
		//			return input;
		//		Console.WriteLine("Ошибка: поле не может быть пустым. Попробуйте ещё раз.");
		//	}
		//}



		//TOOD: refactor
		/// <summary>
		/// Случайный человек
		/// </summary>
		/// <returns></returns>
		//public static Person GetRandomPerson()
		//{
		//	//TODO: RSDN
		//	string[] maleFirst = { "Венцеслав", "Златояр", "Горислав", "Драгомил", "Завид", "Никита" };
		//	string[] femaleFirst = { "Купава", "Богдана", "Рада", "Лада", "Любава", "Добрава" };
		//	string[] maleLast = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Попов", "Смирнов" };
		//	string[] femaleLast = { "Иванова", "Петрова", "Сидорова", "Кузнецова", "Попова", "Смирнова" };
		//
		//	Random rnd = Random.Shared;
		//	bool isMale = rnd.Next(2) == 0;
		//
		//	string first, last;
		//	Gender gender;
		//
		//	if (isMale)
		//	{
		//		first = maleFirst[rnd.Next(maleFirst.Length)];
		//		last = maleLast[rnd.Next(maleLast.Length)];
		//		gender = Gender.Male;
		//	}
		//	else
		//	{
		//		first = femaleFirst[rnd.Next(femaleFirst.Length)];
		//		last = femaleLast[rnd.Next(femaleLast.Length)];
		//		gender = Gender.Female;
		//	}
		//
		//	return new Person(first, last, 18 + rnd.Next(60), gender);
		//}
		/// <summary>
		/// Преобразование к единому стилю
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{

			string genderStr = Gender == Gender.Male ? "М" : "Ж";
			return $"{FirstName} {LastName}, {Age} лет ({genderStr})";
		}

	}
}
