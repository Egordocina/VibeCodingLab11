using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	/// <summary>
	/// Класс для генерации случайного человека
	/// </summary>
	public class RandomPerson
	{
		/// <summary>
		/// Метод для генерации случайного человека
		/// </summary>
		/// <returns></returns>
		public static void SetRandomPerson(Person person)
		{
			string[] maleFirst =
			{
				"Венцеслав", "Златояр", "Горислав",
				"Драгомил", "Завид", "Никита"
			};

			string[] femaleFirst =
			{
				"Купава", "Богдана", "Рада",
				"Лада", "Любава", "Добрава"
			};

			string[] maleLast =
			{
				"Иванов", "Петров", "Сидоров",
				"Кузнецов", "Попов", "Смирнов"
			};

			string[] femaleLast =
			{
				"Иванова", "Петрова", "Сидорова",
				"Кузнецова", "Попова", "Смирнова"
			};


			Random random = new Random
				(Guid.NewGuid().GetHashCode());

			person.Age = random.Next(person.MinAge, person.MaxAge);

			person.Gender = (Gender)random.Next(2);

			switch (person.Gender)
			{
				//TODO: rewrite+
				case Gender.Male:
				{
					person.FirstName = maleFirst
						[random.Next(0, maleFirst.Length)];
					person.LastName = maleLast
						[random.Next(0, maleLast.Length)];
					break;
				}
				case Gender.Female:
				{
					person.FirstName = femaleFirst
						 [random.Next(0, femaleFirst.Length)];
					person.LastName = femaleLast
						 [random.Next(0, femaleLast.Length)];
					break;
				}
			}
		}

		/// <summary>
		/// Метод присоения полям Person рандомных значений
		/// с заданным полом.
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		public static void SetRandomPerson(Person person,
			Gender gender)
		{
			string[] maleFirst =
			{
				"Венцеслав", "Златояр", "Горислав",
				"Драгомил", "Завид", "Никита"
			};

			string[] femaleFirst =
			{
				"Купава", "Богдана", "Рада",
				"Лада", "Любава", "Добрава"
			};

			string[] maleLast =
			{
				"Иванов", "Петров", "Сидоров",
				"Кузнецов", "Попов", "Смирнов"
			};

			string[] femaleLast =
			{
				"Иванова", "Петрова", "Сидорова",
				"Кузнецова", "Попова", "Смирнова"
			};


			Random random = new Random(Guid.NewGuid().GetHashCode());

			person.Age = random.Next(person.MinAge, person.MaxAge);
			person.Gender = gender;

			switch (person.Gender)
			{
				//TODO: rewrite+
				case Gender.Male:
				{
					person.FirstName = maleFirst
						[random.Next(0, maleFirst.Length)];
					person.LastName = maleLast
						[random.Next(0, maleLast.Length)];
					break;
				}
				case Gender.Female:
				{
					person.FirstName = femaleFirst
						 [random.Next(0, femaleFirst.Length)];
					person.LastName = femaleLast
						 [random.Next(0, femaleLast.Length)];
					break;
				}
			}
		}

		/// <summary>
		/// Метод присоения полям Adult рандомных значений.
		/// </summary>
		/// <param name="adult">Объект класса Adult.</param>
		public static void SetRandomAdult(Adult adult)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());

			string[] jobPlace =
			{
				"Газпром нефть", "Роснефть", "Магнит", "Росатом",
				"Почта России","Россети", "Сбер", "Роскосмос",
				"Норильский никель", "Русгидро", "Тинькофф",
			};

			adult.Job = jobPlace[random.Next(0, jobPlace.Length)];

			adult.Age = random.Next(adult.MinAge, adult.MaxAge);

			adult.SeriesPass =
				PassDataGeneration(Adult.PassSeriesDigits);

			adult.NumPass =
				PassDataGeneration(Adult.PassNumDigits);

			if (random.Next(2) == 0)
			{
				var partnerGender =
					adult.Gender == Gender.Male
					? Gender.Female
					: Gender.Male;

				adult.Partner = GetRandomAdult(partnerGender);
			}
		}
		/// <summary>
		/// Метод генерации паспортных данных.
		/// </summary>
		/// <param name="numberOfDigits">Кол-во цифр в номере 
		/// или серии паспорта.</param>
		/// <returns>Строку с номером или серией паспорта.</returns>
		private static string PassDataGeneration
			(int numberOfDigits)
		{
			string passportId = "";
			for (int i = 0; i < numberOfDigits; i++)
			{
				passportId += Random.Shared.Next(0, 10).ToString();
			}

			return passportId;
		}
		/// <summary>
		/// Метод заполнения полей обьекта класса Adult.
		/// </summary>
		/// <returns>Объект класса Adult.</returns>
		public static Adult GetRandomAdult()
		{
			Adult adult = new Adult();
			SetRandomPerson(adult);
			SetRandomAdult(adult);
			return adult;
		}

		public static Adult GetRandomAdult(Gender gender)
		{
			Adult adult = new Adult();
			SetRandomPerson(adult, gender);
			SetRandomAdult(adult);
			return adult;
		}

		/// <summary>
		/// Метод присоения полям Child рандомных значений.
		/// </summary>
		/// <param name="adult">Объект класса Adult.</param>
		public static void SetRandomChild(Child child)
		{
			Random random = new Random
				(Guid.NewGuid().GetHashCode());

			string[] placeOfStudy =
			{
				"МБОУ СОШ №24»", "МОУ «СОШ №12»",
				"МБОУ «СОШ №1»", "Лицей им. Н.Г. Булакина»",
				"МБОУ «СОШ №6»", "МБОУ «СОШ №7»", "МБОУ «СОШ №8»",
			};

			child.PlaceOfStudy = placeOfStudy
				[random.Next(0, placeOfStudy.Length)];

			child.Age = random.Next(child.MinAge, child.MaxAge);

			Adult father = GetRandomAdult(Gender.Male);
			child.Father = father;

			Adult mother = GetRandomAdult(Gender.Female);
			child.Mother = mother;

			mother.LastName = father.LastName + "а";

			//TODO: switch-case+
			switch (child.Gender)
			{
				case Gender.Male:
					child.LastName = father.LastName;
					break;
				case Gender.Female:
					child.LastName = mother.LastName;
					break;
					// default не нужен, Gender имеет только два значения
			}
					}
		/// <summary>
		/// Метод заполнения полей обьекта класса Child.
		/// </summary>
		/// <returns>Объект класса Child</returns>
		public static Child GetRandomChild()
		{
			Child child = new Child();
			SetRandomPerson(child);
			SetRandomChild(child);
			return child;
		}
	}
}
