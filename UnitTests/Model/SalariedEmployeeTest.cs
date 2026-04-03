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
        /// Тестирование свойства Position (позитивные сценарии).
        /// </summary>
        [Test]
        [TestCase("3 разряд", TestName = "Тестирование Position при присваивании 3 разряда.")]
        [TestCase("2 разряд", TestName = "Тестирование Position при присваивании 2 разряда.")]
        [TestCase("1 разряд", TestName = "Тестирование Position при присваивании 1 разряда.")]
        [TestCase("КМС", TestName = "Тестирование Position при присваивании КМС.")]
        [TestCase("МС", TestName = "Тестирование Position при присваивании МС.")]
        [TestCase("МСМК", TestName = "Тестирование Position при присваивании МСМК.")]
        public void PositionTest_ValidValues(string position)
        {
            var employee = new SalariedEmployee();
            employee.Position = position;
            Assert.That(employee.Position, Is.EqualTo(position));
        }

        /// <summary>
        /// Тестирование валидации maxLength для свойства Position (max = 100).
        /// </summary>
        [Test]
        [TestCase(100, TestName = "Тестирование Position при длине ровно 100 символов.")]
        [TestCase(99, TestName = "Тестирование Position при длине 99 символов (max-1).")]
        public void PositionTest_MaxLength_ValidEdge(int length)
        {
            var employee = new SalariedEmployee();
            var position = new string('A', length);
            employee.Position = position;
            Assert.That(employee.Position, Is.EqualTo(position));
        }

        [Test]
        [TestCase(101, TestName = "Тестирование Position при длине 101 символ (max+1).")]
        [TestCase(200, TestName = "Тестирование Position при очень длинном разряде.")]
        public void PositionTest_MaxLength_Exceeds_ThrowsException(int length)
        {
            var employee = new SalariedEmployee();
            var position = new string('A', length);
            Assert.Throws<IncorrectArgumentException>(() => employee.Position = position);
        }

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
        [TestCase("Директор", TestName = "Тестирование CalculateSalary при несуществующей должности.")]
        [TestCase("6 разряд", TestName = "Тестирование CalculateSalary при несуществующем 6 разряде.")]
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

        /// <summary>
        /// Тестирование свойства TypeName.
        /// </summary>
        [Test]
        [TestCase("По окладу", TestName = "Тестирование TypeName для SalariedEmployee.")]
        public void TypeNameTest(string expected)
        {
            var employee = new SalariedEmployee();
            Assert.That(employee.TypeName, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тестирование свойства Salary (округление результата CalculateSalary).
        /// </summary>
        [Test]
        [TestCase("3 разряд", 60000, TestName = "Тестирование Salary для 3 разряда (целое).")]
        [TestCase("МСМК", 150000, TestName = "Тестирование Salary для МСМК (целое).")]
        public void SalaryTest_Rounding(string position, double expected)
        {
            var employee = new SalariedEmployee
            {
                Position = position
            };
            var result = employee.Salary;
            Assert.That(result, Is.EqualTo(Math.Round(expected, 2)).Within(0.01));
        }
    }
}
