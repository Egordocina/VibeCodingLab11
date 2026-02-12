namespace Model
{
	/// <summary>
	/// Исключение для некорректных аргументов.
	/// </summary>
	public class IncorrectArgumentException : Exception
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		public IncorrectArgumentException(string message) : base(message) { }
	}
}