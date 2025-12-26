namespace PersonLibrary
{
	//TODO: XML +
	/// <summary>
	/// Класс PersonList
	/// </summary>
	public class PersonList
	{
		/// <summary>
		/// Объявление списка объектов типа Person
		/// </summary>
		private readonly List<Person> _people = new();

		/// <summary>
		/// Добавление человека
		/// </summary>
		/// <param name="person">Объект класса Person</param>
		public void Add(Person person) => _people.Add(person);

		/// <summary>
		/// Удаление человека
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		public bool Remove(Person person) => _people.Remove(person);

		/// <summary>
		/// Удаление персон по индексу.
		/// </summary>
		/// <param name="index">Индекс объекта.</param>
		/// <exception cref="ArgumentOutOfRangeException">Исключение, которое
		/// генерируется, если введенный индекс находится за пределами 
		/// дипазона</exception>
		public void RemoveAtIndex(int index)
		{
			if (index < 0 || index >= _people.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index),
				"Индекс вне диапазона");
			}
			 _people.RemoveAt(index);
		}

		/// <summary>
		/// Поиск персоны по указанному индексу.
		/// </summary>
		/// <param name="index">Индекс объекта.</param>
		/// <returns>index</returns>
		/// <exception cref="ArgumentOutOfRangeException">Исключение, которое
		/// генерируется, если введенный индекс находится за пределами его
		/// границ.</exception>
		public Person Get(int index)
		{
			if (index < 0 || index >= _people.Count)
				//TODO: rewrite
				{
				throw new ArgumentOutOfRangeException(nameof(index));
				}
			return _people[index];
		}

		/// <summary>
		/// Получение индекса по человеку.
		/// </summary>
		/// <param name="person">Объект класса Person.</param>
		/// <returns>Индекс объекта.</returns>
		public int IndexOf(Person person) => _people.IndexOf(person);

		/// <summary>
		/// Удаление всех людей.
		/// </summary>
		public void Clear() => _people.Clear();

		/// <summary>
		/// Количество персон в списке.
		/// </summary>
		/// <returns>Количество персон в списке.</returns>
		public int Count() => _people.Count;

		//TODO: XML
		public string GetInfo()
		{
			string infoPerson = default;
			foreach (Person persona in _people)
			{
				infoPerson += persona.GetInfo();
			}
			return infoPerson;
		}
	}
}
