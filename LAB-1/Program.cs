
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
		/// Получение информации о списке людей.
		/// </summary>
		/// <param name="personList">список людей</param>
		/// <param name="title"></param>
		public static void Print(PersonList personList, string title)
		{
			Console.WriteLine($"\n=== {title} === (количество: {personList.Count})");
			if (personList.Count == 0)
			{
				Console.WriteLine("   [список пуст]");
			}
			else
			{
				for (int i = 0; i < personList.Count; i++)
					Console.WriteLine($"{i + 1,2}. {personList.Get(i)}");
			}
			Console.WriteLine(new string('-', 40));
		}

		/// <summary>
		/// Точка входа в программу.
		/// </summary>
		static void Main(string[] args)
		{
			// Создание двух списков людей по 3 человека
			Console.OutputEncoding = System.Text.Encoding.UTF8;	
			var list1 = new PersonList();
			var list2 = new PersonList();

			// Генерирование списка случайных людей
			for (int i = 0; i < 3; i++)
			{
				list1.Add(RandomPerson.GetRandomPerson());
				list2.Add(RandomPerson.GetRandomPerson());
			}
			// Уведомление о создании списков и вывод
			Print(list1, "СПИСОК 1 — создан");
			Print(list2, "СПИСОК 2 — создан");
			Wait();

			// Добавление нового человека в список
			list1.Add(ConsoleInput.ReadFromKeyboard());
			Print(list1, "СПИСОК 1 — добавлен новый человек");
			Wait();

			// Копирование второго человека из первого списка в конец
			// второго
			Person sharedPerson = list1.Get(1);
			Console.WriteLine($"Копируем человека → {sharedPerson} в список 2");
			list2.Add(sharedPerson);

			Print(list1, "СПИСОК 1");
			Print(list2, "СПИСОК 2 — теперь содержит того же человека (по ссылке!)");
			Wait();

			// Удаление второго человека из первого списка
			Console.WriteLine("Удаляем второго человека из СПИСОК 1...");
			list1.RemoveAtIndex(1);

			Print(list1, "СПИСОК 1 — после удаления");
			Print(list2, "СПИСОК 2 — человек ОСТАЛСЯ! (ссылка жива)");
			Wait();

			// Очистка второго списка
			list2.Clear();
			Print(list2, "СПИСОК 2 — после очистки");
			Wait();

			Console.WriteLine("Демонстрация завершена. " +
				"Спасибо, что выбрали наш сервис!");
		}
	}
}