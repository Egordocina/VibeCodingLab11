using Model;

namespace ConsoleLoader
{
	/// <summary>
	/// Класс параметров атрибутов для персон
	/// </summary>
	public class PropertyHandlerDTO
	{
		/// <summary>
		/// Делегат для выполнения ввода атрибутов
		/// </summary>
		public Action<IEmployee> PropertyHandlingAction { get; }

		/// <summary>
		/// Список исключений атрибутов
		/// </summary>
		public List<Type> ExceptionTypes { get; }

		/// <summary>
		/// Значение атрибута
		/// </summary>
		public string PropertyName { get; }

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="propertyName">Значение атрибута</param>
		/// <param name="exceptionTypes">Список исключений атрибутов</param>
		/// <param name="propertyHandlingAction"> Делегат для выполнения ввода атрибутов</param>
		public PropertyHandlerDTO(string propertyName,
			List<Type> exceptionTypes,
			Action<IEmployee> propertyHandlingAction)
		{
			PropertyName = propertyName;
			PropertyHandlingAction = propertyHandlingAction;
			ExceptionTypes = exceptionTypes;
		}
	}
}
