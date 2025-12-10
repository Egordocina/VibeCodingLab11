using LAB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1
{
	public class RandomPerson
	{
		public static Person GetRandomPerson()
		{
			//TODO: RSDN
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
	}
}
