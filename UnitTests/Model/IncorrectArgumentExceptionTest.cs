using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
	/// <summary>
	/// Набор тестов для класса
	/// IncorrectArgumentException.
	/// </summary>
	[TestFixture]
	public class IncorrectArgumentExceptionTest
	{
		/// <summary>
		/// Тестирование конструктора с сообщением.
		/// </summary>
		[Test]
		[TestCase(
			"Некорректное значение.",
			TestName =
				"Тестирование конструктора " +
				"с обычным сообщением."
		)]
		[TestCase(
			"Имя не может быть пустым.",
			TestName =
				"Тестирование конструктора " +
				"с сообщением об имени."
		)]
		[TestCase(
			"Значение должно быть положительным.",
			TestName =
				"Тестирование конструктора " +
				"с сообщением о значении."
		)]
		[TestCase(
			"Длина строки превышает допустимую.",
			TestName =
				"Тестирование конструктора " +
				"с длинным сообщением."
		)]
		[TestCase(
			"Ошибка валидации данных.",
			TestName =
				"Тестирование конструктора " +
				"с общим сообщением."
		)]
		public void ConstructorTest_ValidMessage(string message)
		{
			var exception =
				new IncorrectArgumentException(message);
			Assert.That(
				exception.Message,
				Is.EqualTo(message));
		}

		[Test]
		[TestCase(
			"",
			TestName =
				"Тестирование конструктора " +
				"с пустым сообщением."
		)]
		[TestCase(
			"   ",
			TestName =
				"Тестирование конструктора " +
				"с сообщением из пробелов."
		)]
		public void ConstructorTest_EdgeCases(string message)
		{
			var exception =
				new IncorrectArgumentException(message);
			Assert.That(
				exception.Message,
				Is.EqualTo(message));
		}
	}
}
