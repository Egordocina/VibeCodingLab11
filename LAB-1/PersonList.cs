namespace LAB1
{
	public class PersonList
	{
		private readonly List<Person> _people = new();

		public void Add(Person person) => _people.Add(person);

		public bool Remove(Person person) => _people.Remove(person);

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= _people.Count)
				throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне диапазона");
			_people.RemoveAt(index);
		}

		public Person Get(int index)
		{
			if (index < 0 || index >= _people.Count)
				throw new ArgumentOutOfRangeException(nameof(index));
			return _people[index];
		}

		public int IndexOf(Person person) => _people.IndexOf(person);

		public void Clear() => _people.Clear();

		public int Count => _people.Count;

		public void Print(string title)
		{
			Console.WriteLine($"\n=== {title} === (количество: {Count})");
			if (Count == 0)
			{
				Console.WriteLine("   [список пуст]");
			}
			else
			{
				for (int i = 0; i < _people.Count; i++)
					Console.WriteLine($"{i + 1,2}. {_people[i]}");
			}
			Console.WriteLine(new string('-', 40));
		}
	}
}
