
namespace LAB1
{
	public class Person
	{
		/// <summary>
		/// Приватные поля — настоящая инкапсуляция
		/// </summary>
		private string _firstName = string.Empty;
		private string _lastName = string.Empty;
		private int _age;
		private Gender _gender;

		/// <summary>
		/// Публичные свойства только для чтения + валидация в setter'ах
		/// </summary>
		public string FirstName
		{
			get { return _firstName; }
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Имя не может быть пустым или null");
				}
				_firstName = value.Trim();
			}
		}

		public string LastName
		{
			get { return _lastName; }
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Фамилия не может быть пустой или null");
				}
				_lastName = value.Trim();
			}
		}

		public int Age
		{
			get { return _age; }
			private set
			{
				if (value < 0 || value > 123)
				{
					throw new ArgumentException("Возраст должен быть в диапазоне 0–123 лет");
				}
				_age = value;
			}
		}

		public Gender Gender
		{
			get { return _gender; }
			private set => _gender = value;
		}

		/// <summary>
		/// Конструктор — единственное место для установки значений
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="age"></param>
		/// <param name="gender"></param>
		public Person(string firstName, string lastName, int age, Gender gender)
		{
			FirstName = firstName;   // валидация сработает автоматически
			LastName = lastName;
			Age = age;
			Gender = gender;
		}

		/// <summary>
		/// Вывод на экран
		/// </summary>
		public void Print()
		{
			string genderStr;
			if (Gender == Gender.Male)
			{
				genderStr = "Мужской";
			}
			else
			{
				genderStr = "Женский";
			}
			Console.WriteLine($"Имя: {FirstName} {LastName}, Возраст: {Age}, Пол: {genderStr}");
		}

		/// <summary>
		/// Ввод с клавиатуры
		/// </summary>
		/// <returns></returns>
		public static Person ReadFromKeyboard()
		{
			Console.Write("Введите имя: ");
			string firstName = Console.ReadLine() ?? "";

			Console.Write("Введите фамилию: ");
			string lastName = Console.ReadLine() ?? "";

			Console.Write("Введите возраст: ");
			int age = int.Parse(Console.ReadLine() ?? "0");

			Console.Write("Введите пол (м/ж): ");
			string input = (Console.ReadLine() ?? "").ToLower();
			Gender gender = input.StartsWith("м") ? Gender.Male : Gender.Female;

			return new Person(firstName, lastName, age, gender);
		}

		/// <summary>
		/// Случайный человек
		/// </summary>
		/// <returns></returns>
		public static Person GetRandomPerson()
		{
			string[] maleFirst = { "Венцеслав", "Златояр", "Горислав", "Драгомил", "Завид", "Никита" };
			string[] femaleFirst = { "Купава", "Богдана", "Рада", "Лада", "Любава", "Добрава" };
			string[] maleLast = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Попов", "Смирнов" };
			string[] femaleLast = { "Иванова", "Петрова", "Сидорова", "Кузнецова", "Попова", "Смирнова" };

			Random rnd = Random.Shared;
			bool isMale = rnd.Next(2) == 0;

			string first, last;
			Gender gender;

			if (isMale)
			{
				first = maleFirst[rnd.Next(maleFirst.Length)];
				last = maleLast[rnd.Next(maleLast.Length)];
				gender = Gender.Male;
			}
			else
			{
				first = femaleFirst[rnd.Next(femaleFirst.Length)];
				last = femaleLast[rnd.Next(femaleLast.Length)];
				gender = Gender.Female;
			}

			return new Person(first, last, 18 + rnd.Next(60), gender);
		}
		/// <summary>
		/// Преобранование к единому стилю
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string genderStr = Gender == Gender.Male ? "М" : "Ж";
			return $"{FirstName} {LastName}, {Age} лет ({genderStr})";
		}

	}
}
