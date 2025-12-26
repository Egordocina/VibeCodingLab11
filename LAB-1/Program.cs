
using LAB1;
using PersonLibrary;

namespace LAB1
{
	/// <summary>
	/// Основной класс программы.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Ожиадние действия пользователя
		/// </summary>
		static void Wait() 
		{ 
			Console.WriteLine("\nНажмите любую клавишу..."); 
			Console.ReadKey(true);
		}

		/// <summary>
		/// Точка входа в программу.
		/// </summary>
		static void Main(string[] args)
		{
			// 5.a. Создание списка PersonList, состоящего из рандомного кол-ва
			// взрослых и детей
			PersonList personList = new PersonList();

			Console.WriteLine("Рандомный список взрослых и детей — создан");
			Wait();

			Console.WriteLine("Рандомный список взрослых и детей:\n");

			Random random = new Random();

			for (int i = 0; i < 7; i++)
			{
				if (random.NextDouble() < 0.5)
				{
					personList.Add(RandomPerson.GetRandomAdult());
				}
				else
				{
					personList.Add(RandomPerson.GetRandomChild());
				}
			}

			// 5.b. Вывод на экран описания всех людей списка.
			Console.WriteLine(personList.GetInfo());
			
			Console.WriteLine("Список выведен");
			Wait();

			// 5.c. Определение типа четвертого человека в списке
			// и выполнения методов, присущих этому классу.
			if (personList.Count() > 3)
			{
				var fourthPerson = personList.Get(3);
				string typeName = fourthPerson is Adult ? "Взрослый" : "Ребенок";
				Console.WriteLine($"Тип четвертого человека: {typeName}");

				switch (fourthPerson)
				{
					case Adult adult:
						{
							Console.WriteLine($"Четвертый взрослый: {adult.LastName} {adult.FirstName}");
							Console.WriteLine(adult.GetExtraIncome());
							break;
						}
					case Child child:
						{
							Console.WriteLine($"Четвертый ребенок: {child.LastName} {child.FirstName}");
							Console.WriteLine(child.GetViolinLessons());
							break;
						}
				}
			}

			Console.WriteLine("Характеристики человека  выведены");
			Wait();

			Console.WriteLine("Демонстрация завершена. " +
		"Спасибо, что выбрали наш сервис!");
			Console.ReadKey();
		}

	}
}