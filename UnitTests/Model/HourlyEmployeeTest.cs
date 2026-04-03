using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
	/// <summary>
	/// Набор тестов для класса HourlyEmployee.
	/// </summary>
	[TestFixture]
	public class HourlyEmployeeTest
	{
		/// <summary>
		/// Допустимое отклонение для сравнения double.
		/// </summary>
		private const double Tolerance = 0.01;

		/// <summary>
		/// Тестирование свойства HourlyRate.
		/// </summary>
		[Test]
		[TestCase(
			100.0,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании корректной ставки."
		)]
		[TestCase(
			1.0,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании минимальной ставки."
		)]
		[TestCase(
			1000.0,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании большой ставки."
		)]
		[TestCase(
			50.5,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании дробной ставки."
		)]
		[TestCase(
			999.99,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании максимальной дробной ставки."
		)]
		public void HourlyRateTest_ValidValues(double rate)
		{
			var employee = new HourlyEmployee();
			employee.HourlyRate = rate;
			Assert.That(employee.HourlyRate, Is.EqualTo(rate));
		}

		[Test]
		[TestCase(
			0,
			TestName =
				"Тестирование HourlyRate при присваивании 0."
		)]
		[TestCase(
			-1,
			TestName =
				"Тестирование HourlyRate при присваивании -1."
		)]
		[TestCase(
			-100,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании отрицательного значения."
		)]
		[TestCase(
			double.MinValue,
			TestName =
				"Тестирование HourlyRate " +
				"при присваивании MinValue."
		)]
		public void HourlyRateTest_InvalidValues_ThrowsException(
			double rate)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.HourlyRate = rate);
		}

		/// <summary>
		/// Тестирование свойства HoursWorked.
		/// </summary>
		[Test]
		[TestCase(
			1,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании минимального значения."
		)]
		[TestCase(
			2,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании 2 часов."
		)]
		[TestCase(
			168,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании 168 часов."
		)]
		[TestCase(
			744,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании максимального значения."
		)]
		[TestCase(
			743,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании MaxValue-1."
		)]
		public void HoursWorkedTest_ValidValues(double hours)
		{
			var employee = new HourlyEmployee();
			employee.HoursWorked = hours;
			Assert.That(employee.HoursWorked, Is.EqualTo(hours));
		}

		[Test]
		[TestCase(
			0,
			TestName =
				"Тестирование HoursWorked при присваивании 0."
		)]
		[TestCase(
			-1,
			TestName =
				"Тестирование HoursWorked при присваивании -1."
		)]
		[TestCase(
			745,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании больше максимума."
		)]
		[TestCase(
			double.MinValue,
			TestName =
				"Тестирование HoursWorked " +
				"при присваивании MinValue."
		)]
		public void
			HoursWorkedTest_InvalidValues_ThrowsException(
				double hours)
		{
			var employee = new HourlyEmployee();
			Assert.Throws<IncorrectArgumentException>(
				() => employee.HoursWorked = hours);
		}

		/// <summary>
		/// Тестирование метода CalculateSalary.
		/// </summary>
		[Test]
		[TestCase(
			100.0, 10, 1000.0,
			TestName =
				"Тестирование CalculateSalary " +
				"при стандартных значениях."
		)]
		[TestCase(
			1.0, 1, 1.0,
			TestName =
				"Тестирование CalculateSalary " +
				"при минимальных значениях."
		)]
		[TestCase(
			1000.0, 744, 744000.0,
			TestName =
				"Тестирование CalculateSalary " +
				"при максимальных значениях."
		)]
		[TestCase(
			50.5, 100, 5050.0,
			TestName =
				"Тестирование CalculateSalary " +
				"при дробной ставке."
		)]
		[TestCase(
			150.75, 40, 6030.0,
			TestName =
				"Тестирование CalculateSalary " +
				"при дробных значениях."
		)]
		public void CalculateSalaryTest_ValidValues(
			double rate, double hours, double expected)
		{
			var employee = new HourlyEmployee
			{
				HourlyRate = rate,
				HoursWorked = hours
			};
			var result = employee.CalculateSalary();
			Assert.That(
				result,
				Is.EqualTo(expected).Within(Tolerance));
		}

		/// <summary>
		/// Тестирование свойства TypeName.
		/// </summary>
		[Test]
		[TestCase(
			"Почасовая",
			TestName =
				"Тестирование TypeName " +
				"для HourlyEmployee."
		)]
		public void TypeNameTest(string expected)
		{
			var employee = new HourlyEmployee();
			Assert.That(
				employee.TypeName,
				Is.EqualTo(expected));
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
				"при стандартных значениях."
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
	}
}
