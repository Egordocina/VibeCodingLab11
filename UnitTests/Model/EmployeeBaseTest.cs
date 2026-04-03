using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
	/// <summary>
	/// Набор тестов для класса EmployeeBase.
	/// </summary>
	[TestFixture]
	public class EmployeeBaseTest
	{
		/// <summary>
		/// Допустимое отклонение для сравнения double.
		/// </summary>
		private const double Tolerance = 0.01;

		/// <summary>
		/// Тестирование свойства Name.
		/// </summary>
		[Test]
		[TestCase(
			"Иван",
			TestName =
				"Тестирование Name " +
				"при присваивании корректного имени."
		)]
		[TestCase(
			"А",
			TestName =
				"Тестирование Name " +
				"при присваивании имени из 1 символа."
		)]
		[TestCase(
			"Максимиллиан",
			TestName =
				"Тестирование Name " +
				"при присваивании длинного имени."
		)]
		[TestCase(
			"Иван-Петр",
			TestName =
				"Тестирование Name " +
				"при присваивании имени с дефисом."
		)]
		[TestCase(
			"Жан-Кристоф",
			TestName =
				"Тестирование Name " +
				"при присваивании имени с дефисом " +
				"и длинного."
		)]
		public void NameTest_ValidValues(string name)
		{
			var employee = new HourlyEmployee();
			employee.Name = name;
			Assert.That(employee.Name, Is.EqualTo(name));
		}

		[Test]
		[TestCase(
			null,
			TestName =
				"Тестирование Name при присваивании null."
		)]
		[TestCase(
			"",
			TestName =
				"Тестирование Name " +
				"при присваивании пустой строки."
		)]
		[TestCase(
			"   ",
			TestName =
				"Тестирование Name " +
				"при присваивании строки из пробелов."
		)]
		public void NameTest_InvalidValues_ThrowsException(
			string? name)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Name = name!);
		}

		/// <summary>
		/// Тестирование свойства LastName.
		/// </summary>
		[Test]
		[TestCase(
			"Иванов",
			TestName =
				"Тестирование LastName " +
				"при присваивании корректной фамилии."
		)]
		[TestCase(
			"А",
			TestName =
				"Тестирование LastName " +
				"при присваивании фамилии из 1 символа."
		)]
		[TestCase(
			"Константинопольский",
			TestName =
				"Тестирование LastName " +
				"при присваивании длинной фамилии."
		)]
		[TestCase(
			"Иванов-Петров",
			TestName =
				"Тестирование LastName " +
				"при присваивании фамилии с дефисом."
		)]
		[TestCase(
			"де ла Фонтен",
			TestName =
				"Тестирование LastName " +
				"при присваивании фамилии с пробелами."
		)]
		public void LastNameTest_ValidValues(string lastName)
		{
			var employee = new HourlyEmployee();
			employee.LastName = lastName;
			Assert.That(
				employee.LastName,
				Is.EqualTo(lastName));
		}

		[Test]
		[TestCase(
			null,
			TestName =
				"Тестирование LastName при присваивании null."
		)]
		[TestCase(
			"",
			TestName =
				"Тестирование LastName " +
				"при присваивании пустой строки."
		)]
		[TestCase(
			"   ",
			TestName =
				"Тестирование LastName " +
				"при присваивании строки из пробелов."
		)]
		public void LastNameTest_InvalidValues_ThrowsException(
			string? lastName)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.LastName = lastName!);
		}

		/// <summary>
		/// Тестирование свойства Position.
		/// </summary>
		[Test]
		[TestCase(
			"3 разряд",
			TestName =
				"Тестирование Position " +
				"при присваивании корректного разряда."
		)]
		[TestCase(
			"1 разряд",
			TestName =
				"Тестирование Position " +
				"при присваивании 1 разряда."
		)]
		[TestCase(
			"МСМК",
			TestName =
				"Тестирование Position " +
				"при присваивании МСМК."
		)]
		[TestCase(
			"КМС",
			TestName =
				"Тестирование Position " +
				"при присваивании КМС."
		)]
		[TestCase(
			"2 разряд",
			TestName =
				"Тестирование Position " +
				"при присваивании 2 разряда."
		)]
		public void PositionTest_ValidValues(string position)
		{
			var employee = new HourlyEmployee();
			employee.Position = position;
			Assert.That(
				employee.Position,
				Is.EqualTo(position));
		}

		[Test]
		[TestCase(
			null,
			TestName =
				"Тестирование Position при присваивании null."
		)]
		[TestCase(
			"",
			TestName =
				"Тестирование Position " +
				"при присваивании пустой строки."
		)]
		[TestCase(
			"   ",
			TestName =
				"Тестирование Position " +
				"при присваивании строки из пробелов."
		)]
		public void
			PositionTest_InvalidValues_ThrowsException(
				string? position)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Position = position!);
		}

		/// <summary>
		/// Тестирование свойства Country.
		/// </summary>
		[Test]
		[TestCase(
			"Россия",
			TestName =
				"Тестирование Country " +
				"при присваивании корректной страны."
		)]
		[TestCase(
			"США",
			TestName =
				"Тестирование Country " +
				"при присваивании короткой страны."
		)]
		[TestCase(
			"Великобритания",
			TestName =
				"Тестирование Country " +
				"при присваивании длинной страны."
		)]
		[TestCase(
			"Чехия",
			TestName =
				"Тестирование Country " +
				"при присваивании Чехии."
		)]
		[TestCase(
			"Норвегия",
			TestName =
				"Тестирование Country " +
				"при присваивании Норвегии."
		)]
		public void CountryTest_ValidValues(string country)
		{
			var employee = new HourlyEmployee();
			employee.Country = country;
			Assert.That(
				employee.Country,
				Is.EqualTo(country));
		}

		[Test]
		[TestCase(
			null,
			TestName =
				"Тестирование Country при присваивании null."
		)]
		[TestCase(
			"",
			TestName =
				"Тестирование Country " +
				"при присваивании пустой строки."
		)]
		[TestCase(
			"   ",
			TestName =
				"Тестирование Country " +
				"при присваивании строки из пробелов."
		)]
		public void CountryTest_InvalidValues_ThrowsException(
			string? country)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Country = country!);
		}

		/// <summary>
		/// Тестирование валидации maxLength для
		/// свойства Name (max = 50).
		/// </summary>
		[Test]
		[TestCase(
			50,
			TestName =
				"Тестирование Name " +
				"при длине ровно 50 символов."
		)]
		[TestCase(
			49,
			TestName =
				"Тестирование Name " +
				"при длине 49 символов (max-1)."
		)]
		public void NameTest_MaxLength_ValidEdge(int length)
		{
			var employee = new HourlyEmployee();
			var name = new string('A', length);
			employee.Name = name;
			Assert.That(employee.Name, Is.EqualTo(name));
		}

		[Test]
		[TestCase(
			51,
			TestName =
				"Тестирование Name " +
				"при длине 51 символ (max+1)."
		)]
		[TestCase(
			100,
			TestName =
				"Тестирование Name " +
				"при длине 100 символов."
		)]
		[TestCase(
			1000,
			TestName =
				"Тестирование Name " +
				"при очень длинном имени."
		)]
		public void
			NameTest_MaxLength_Exceeds_ThrowsException(
				int length)
		{
			var employee = new HourlyEmployee();
			var name = new string('A', length);
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Name = name);
		}

		/// <summary>
		/// Тестирование валидации maxLength для
		/// свойства LastName (max = 50).
		/// </summary>
		[Test]
		[TestCase(
			50,
			TestName =
				"Тестирование LastName " +
				"при длине ровно 50 символов."
		)]
		[TestCase(
			49,
			TestName =
				"Тестирование LastName " +
				"при длине 49 символов (max-1)."
		)]
		public void LastNameTest_MaxLength_ValidEdge(
			int length)
		{
			var employee = new HourlyEmployee();
			var lastName = new string('A', length);
			employee.LastName = lastName;
			Assert.That(
				employee.LastName,
				Is.EqualTo(lastName));
		}

		[Test]
		[TestCase(
			51,
			TestName =
				"Тестирование LastName " +
				"при длине 51 символ (max+1)."
		)]
		[TestCase(
			100,
			TestName =
				"Тестирование LastName " +
				"при длине 100 символов."
		)]
		public void
			LastNameTest_MaxLength_Exceeds_ThrowsException(
				int length)
		{
			var employee = new HourlyEmployee();
			var lastName = new string('A', length);
			Assert.Throws<IncorrectArgumentException>(
				() => employee.LastName = lastName);
		}

		/// <summary>
		/// Тестирование валидации maxLength для
		/// свойства Position (max = 100).
		/// </summary>
		[Test]
		[TestCase(
			100,
			TestName =
				"Тестирование Position " +
				"при длине ровно 100 символов."
		)]
		[TestCase(
			99,
			TestName =
				"Тестирование Position " +
				"при длине 99 символов (max-1)."
		)]
		public void PositionTest_MaxLength_ValidEdge(
			int length)
		{
			var employee = new HourlyEmployee();
			var position = new string('A', length);
			employee.Position = position;
			Assert.That(
				employee.Position,
				Is.EqualTo(position));
		}

		[Test]
		[TestCase(
			101,
			TestName =
				"Тестирование Position " +
				"при длине 101 символ (max+1)."
		)]
		[TestCase(
			200,
			TestName =
				"Тестирование Position " +
				"при очень длинном разряде."
		)]
		public void
			PositionTest_MaxLength_Exceeds_ThrowsException(
				int length)
		{
			var employee = new HourlyEmployee();
			var position = new string('A', length);
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Position = position);
		}

		/// <summary>
		/// Тестирование валидации maxLength для
		/// свойства Country (max = 63).
		/// </summary>
		[Test]
		[TestCase(
			63,
			TestName =
				"Тестирование Country " +
				"при длине ровно 63 символа."
		)]
		[TestCase(
			62,
			TestName =
				"Тестирование Country " +
				"при длине 62 символа (max-1)."
		)]
		public void CountryTest_MaxLength_ValidEdge(
			int length)
		{
			var employee = new HourlyEmployee();
			var country = new string('A', length);
			employee.Country = country;
			Assert.That(
				employee.Country,
				Is.EqualTo(country));
		}

		[Test]
		[TestCase(
			64,
			TestName =
				"Тестирование Country " +
				"при длине 64 символа (max+1)."
		)]
		[TestCase(
			100,
			TestName =
				"Тестирование Country " +
				"при очень длинной стране."
		)]
		public void
			CountryTest_MaxLength_Exceeds_ThrowsException(
				int length)
		{
			var employee = new HourlyEmployee();
			var country = new string('A', length);
			Assert.Throws<IncorrectArgumentException>(
				() => employee.Country = country);
		}

		/// <summary>
		/// Тестирование свойства Salary
		/// (округление результата CalculateSalary).
		/// </summary>
		[Test]
		[TestCase(
			100.0, 10, 1000.0,
			TestName =
				"Тестирование Salary " +
				"при стандартных значениях (целое)."
		)]
		[TestCase(
			100.0, 3, 300.0,
			TestName =
				"Тестирование Salary при 100 * 3."
		)]
		[TestCase(
			33.333333, 3, 99.999999,
			TestName =
				"Тестирование Salary " +
				"с дробным округлением."
		)]
		[TestCase(
			0.005, 1, 0.01,
			TestName =
				"Тестирование Salary " +
				"с округлением до копеек."
		)]
		[TestCase(
			0.004, 1, 0.0,
			TestName =
				"Тестирование Salary " +
				"с округлением вниз."
		)]
		public void SalaryTest_Rounding(
			double rate, double hours, double expected)
		{
			var employee = new HourlyEmployee
			{
				HourlyRate = rate,
				HoursWorked = hours
			};
			var result = employee.Salary;
			Assert.That(
				result,
				Is.EqualTo(Math.Round(expected, 2))
					.Within(Tolerance));
		}

		/// <summary>
		/// Тестирование свойства TypeName
		/// для всех наследников.
		/// </summary>
		[Test]
		[TestCase(
			"Почасовая",
			TestName =
				"Тестирование TypeName " +
				"для HourlyEmployee."
		)]
		public void TypeNameTest_HourlyEmployee(
			string expected)
		{
			var employee = new HourlyEmployee();
			Assert.That(
				employee.TypeName,
				Is.EqualTo(expected));
		}

		[Test]
		[TestCase(
			"С комиссией",
			TestName =
				"Тестирование TypeName " +
				"для CommissionEmployee."
		)]
		public void TypeNameTest_CommissionEmployee(
			string expected)
		{
			var employee = new CommissionEmployee();
			Assert.That(
				employee.TypeName,
				Is.EqualTo(expected));
		}

		[Test]
		[TestCase(
			"По окладу",
			TestName =
				"Тестирование TypeName " +
				"для SalariedEmployee."
		)]
		public void TypeNameTest_SalariedEmployee(
			string expected)
		{
			var employee = new SalariedEmployee();
			Assert.That(
				employee.TypeName,
				Is.EqualTo(expected));
		}
	}
}
