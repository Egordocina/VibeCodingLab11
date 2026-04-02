using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса SalariedEmployee.
    /// </summary>
    [TestFixture]
    public class SalariedEmployeeTest
    {
        /// <summary>
        /// Тестирование метода CalculateSalary для различных разрядов.
        /// </summary>
        [Test]
        [TestCase("3 разряд", 60000, TestName = "Тестирование CalculateSalary для 3 разряда.")]
        [TestCase("2 разряд", 75000, TestName = "Тестирование CalculateSalary для 2 разряда.")]
        [TestCase("1 разряд", 90000, TestName = "Тестирование CalculateSalary для 1 разряда.")]
        [TestCase("КМС", 110000, TestName = "Тестирование CalculateSalary для КМС.")]
        [TestCase("МС", 130000, TestName = "Тестирование CalculateSalary для МС.")]
        [TestCase("МСМК", 150000, TestName = "Тестирование CalculateSalary для МСМК.")]
        public void CalculateSalaryTest_ValidPositions(string position, double expectedSalary)
        {
            var employee = new SalariedEmployee
            {
                Position = position
            };
            var result = employee.CalculateSalary();
            Assert.That(result, Is.EqualTo(expectedSalary).Within(0.01));
        }

        [Test]
        [TestCase("Неизвестный разряд", TestName = "Тестирование CalculateSalary при неизвестном разряде.")]
        [TestCase("Стажер", TestName = "Тестирование CalculateSalary при несуществующем разряде.")]
        public void CalculateSalaryTest_InvalidPositions_ThrowsException(string position)
        {
            var employee = new SalariedEmployee
            {
                Position = position
            };
            Assert.Throws<IncorrectArgumentException>(() => employee.CalculateSalary());
        }

        [Test]
        [TestCase(null, TestName = "Тестирование Position при null.")]
        [TestCase("", TestName = "Тестирование Position при пустой строке.")]
        [TestCase("   ", TestName = "Тестирование Position при строке из пробелов.")]
        public void PositionTest_InvalidValues_ThrowsException(string? position)
        {
            var employee = new SalariedEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.Position = position!);
        }
    }
}
