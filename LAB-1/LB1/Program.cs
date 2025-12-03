using System;
using Person;

namespace LB1;

internal class Program
{
	static void Wait() { Console.WriteLine("\nНажмите любую клавишу..."); Console.ReadKey(true); }

	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		var list1 = new PersonList();
		var list2 = new PersonList();

		// a–b
		for (int i = 0; i < 3; i++)
		{
			list1.Add(Person.Person.GetRandomPerson());
			list2.Add(Person.Person.GetRandomPerson());
		}

		list1.Print("СПИСОК 1 — создан");
		list2.Print("СПИСОК 2 — создан");
		Wait();

		// c
		list1.Add(Person.Person.ReadFromKeyboard());
		list1.Print("СПИСОК 1 — добавлен новый человек");
		Wait();

		// d
		Person.Person sharedPerson = list1.Get(1); // второй человек (индекс 1)
		Console.WriteLine($"Копируем человека → {sharedPerson} в список 2");
		list2.Add(sharedPerson);

		list1.Print("СПИСОК 1");
		list2.Print("СПИСОК 2 — теперь содержит того же человека (по ссылке!)");
		Wait();

		// e
		Console.WriteLine("Удаляем второго человека из СПИСОК 1...");
		list1.RemoveAt(1);

		list1.Print("СПИСОК 1 — после удаления");
		list2.Print("СПИСОК 2 — человек ОСТАЛСЯ! (ссылка жива)");
		Wait();

		// f
		list2.Clear();
		list2.Print("СПИСОК 2 — после очистки");
		Wait();

		Console.WriteLine("Демонстрация завершена. Спасибо, что выбрали наш сервис!");
	}
}