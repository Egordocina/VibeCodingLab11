
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PersonLibrary
{
	public abstract class Person
	{
		/// <summary>
		/// Имя
		/// </summary>
		private string _firstName = string.Empty;

		/// <summary>
		/// Фамилия
		/// </summary>
		private string _lastName = string.Empty;

		/// <summary>
		/// Возраст
		/// </summary>
		private int _age;

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

		//TODO: RSDN +
		/// <summary>
		/// Минимальный возраст
		/// </summary>
		public virtual int MinAge { get; } = 0;

		//TODO: RSDN +
		/// <summary>
		/// Максимальный возраст
		/// </summary>
		public virtual int MaxAge { get; } = 123;

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
				if (value < MinAge || value > MaxAge)
				{
					throw new ArgumentException("Возраст должен быть в диапазоне " +
						$"{MinAge} – {MaxAge} лет");
				}
				_age = value;
			}
		}

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
		/// Получение информации о персоне, пункт 2.
		/// </summary>
		/// <returns>Строка с данными полей объекта класса Person.</returns>
		public virtual string GetInfo()
		{
			string genderStr = _gender == Gender.Male ? "мужской" : "женский";
	
			return $"{LastName} {FirstName}, возраст: {Age}, пол: {genderStr}";
		}

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