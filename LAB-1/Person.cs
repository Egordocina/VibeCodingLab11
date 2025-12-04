
namespace LAB1
{
	//TODO: XML
	public class Person
	{
		/// <summary>
		/// Приватные поля — настоящая инкапсуляция
		/// </summary>
		private string _firstName = string.Empty;

		//TODO: XML
		private string _lastName = string.Empty;

		//TODO: XML
		private int _age;

		//TODO: XML
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

		//TODO: XML
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

		//TODO: XML
		public int Age
		{
			get { return _age; }
			private set
			{
				const int minage = 0;
				const int maxage = 123;
				if (value < minage || value > maxage)
				{
					throw new ArgumentException("Возраст должен быть в диапазоне " +
						$"{minage} – {maxage} лет");
				}
				_age = value;
			}
		}

		//TODO: XML
		public Gender Gender
		{
			get { return _gender; }
			private set => _gender = value;
		}

		/// <summary>
		/// Конструктор — место для установки значений
		/// </summary>
		/// <param name="firstName">//TODO: XML</param>
		/// <param name="lastName"></param>
		/// <param name="age"></param>
		/// <param name="gender"></param>
		public Person(string firstName, string lastName, int age, Gender gender)
		{
            // валидация сработает автоматически
            FirstName = firstName;
			LastName = lastName;
			Age = age;
			Gender = gender;
		}

		//TODO: remove
		/// <summary>
		/// Вывод на экран
		/// </summary>
		public void Print()
		{
			string genderStr;
            //string genderStr =
            //    Gender == Gender.Male
            //    ? "Мужской"
            //    : "Женский";
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

		//TODO: remove
		/// <summary>
		/// Ввод с клавиатуры
		/// </summary>
		/// <returns>
		/// //TODO: XML</returns>
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

		//TOOD: refactor
		/// <summary>
		/// Случайный человек
		/// </summary>
		/// <returns></returns>
		public static Person GetRandomPerson()
		{
			//TODO: RSDN
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
