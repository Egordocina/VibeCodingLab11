
using LAB1;

namespace LAB1
{
	/// <summary>
	/// Основной класс программы.
	/// </summary>
	internal class Program
	{
		//TODO: XML +
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
			list1.Print("СПИСОК 1 — создан");
			list2.Print("СПИСОК 2 — создан");
			Wait();

			// Добавление нового человека в список
			list1.Add(ConsoleInput.ReadFromKeyboard());
			list1.Print("СПИСОК 1 — добавлен новый человек");
			Wait();

			// Копирование второго человека из первого списка в конец
			// второго
			Person sharedPerson = list1.Get(1);
			Console.WriteLine($"Копируем человека → {sharedPerson} в список 2");
			list2.Add(sharedPerson);

			list1.Print("СПИСОК 1");
			list2.Print("СПИСОК 2 — теперь содержит того же человека (по ссылке!)");
			Wait();

			// Удаление второго человека из первого списка
			Console.WriteLine("Удаляем второго человека из СПИСОК 1...");
			list1.RemoveAtIndex(1);

			list1.Print("СПИСОК 1 — после удаления");
			list2.Print("СПИСОК 2 — человек ОСТАЛСЯ! (ссылка жива)");
			Wait();

			// Очистка второго списка
			list2.Clear();
			list2.Print("СПИСОК 2 — после очистки");
			Wait();

			Console.WriteLine("Демонстрация завершена. " +
				"Спасибо, что выбрали наш сервис!");
		}
	}
}