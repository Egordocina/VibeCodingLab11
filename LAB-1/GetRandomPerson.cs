using LAB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
	//TODO: XML
	public class RandomPerson
	{
		//TODO: XML
		public static Person GetRandomPerson()
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

			Random rnd = Random.Shared;
			bool isMale = rnd.Next(2) == 0;

			string first = isMale
				? maleFirst[rnd.Next(maleFirst.Length)]
				: femaleFirst[rnd.Next(femaleFirst.Length)];

            string last = isMale
                ? maleLast[rnd.Next(maleLast.Length)]
                : femaleLast[rnd.Next(femaleLast.Length)];

			Gender gender = isMale
				? Gender.Male
				: Gender.Female;


			return new Person(first, last, 18 + rnd.Next(60), gender);
		}
	}
}
