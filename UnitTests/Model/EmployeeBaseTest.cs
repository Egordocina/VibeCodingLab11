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
        /// Тестирование свойства Name.
        /// </summary>
        [Test]
        [TestCase("Иван", TestName = "Тестирование Name при присваивании корректного имени.")]
        [TestCase("А", TestName = "Тестирование Name при присваивании имени из 1 символа.")]
        [TestCase("Максимиллиан", TestName = "Тестирование Name при присваивании длинного имени.")]
        [TestCase("Иван-Петр", TestName = "Тестирование Name при присваивании имени с дефисом.")]
        [TestCase("Жан-Кристоф", TestName = "Тестирование Name при присваивании имени с дефисом и длинного.")]
        public void NameTest_ValidValues(string name)
        {
            var employee = new HourlyEmployee();
            employee.Name = name;
            Assert.That(employee.Name, Is.EqualTo(name));
        }

        [Test]
        [TestCase(null, TestName = "Тестирование Name при присваивании null.")]
        [TestCase("", TestName = "Тестирование Name при присваивании пустой строки.")]
        [TestCase("   ", TestName = "Тестирование Name при присваивании строки из пробелов.")]
        public void NameTest_InvalidValues_ThrowsException(string? name)
        {
            var employee = new HourlyEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.Name = name!);
        }

        /// <summary>
        /// Тестирование свойства LastName.
        /// </summary>
        [Test]
        [TestCase("Иванов", TestName = "Тестирование LastName при присваивании корректной фамилии.")]
        [TestCase("А", TestName = "Тестирование LastName при присваивании фамилии из 1 символа.")]
        [TestCase("Константинопольский", TestName = "Тестирование LastName при присваивании длинной фамилии.")]
        [TestCase("Иванов-Петров", TestName = "Тестирование LastName при присваивании фамилии с дефисом.")]
        [TestCase("де ла Фонтен", TestName = "Тестирование LastName при присваивании фамилии с пробелами.")]
        public void LastNameTest_ValidValues(string lastName)
        {
            var employee = new HourlyEmployee();
            employee.LastName = lastName;
            Assert.That(employee.LastName, Is.EqualTo(lastName));
        }

        [Test]
        [TestCase(null, TestName = "Тестирование LastName при присваивании null.")]
        [TestCase("", TestName = "Тестирование LastName при присваивании пустой строки.")]
        [TestCase("   ", TestName = "Тестирование LastName при присваивании строки из пробелов.")]
        public void LastNameTest_InvalidValues_ThrowsException(string? lastName)
        {
            var employee = new HourlyEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.LastName = lastName!);
        }

        /// <summary>
        /// Тестирование свойства Position.
        /// </summary>
        [Test]
        [TestCase("3 разряд", TestName = "Тестирование Position при присваивании корректного разряда.")]
        [TestCase("1 разряд", TestName = "Тестирование Position при присваивании 1 разряда.")]
        [TestCase("МСМК", TestName = "Тестирование Position при присваивании МСМК.")]
        [TestCase("КМС", TestName = "Тестирование Position при присваивании КМС.")]
        [TestCase("2 разряд", TestName = "Тестирование Position при присваивании 2 разряда.")]
        public void PositionTest_ValidValues(string position)
        {
            var employee = new HourlyEmployee();
            employee.Position = position;
            Assert.That(employee.Position, Is.EqualTo(position));
        }

        [Test]
        [TestCase(null, TestName = "Тестирование Position при присваивании null.")]
        [TestCase("", TestName = "Тестирование Position при присваивании пустой строки.")]
        [TestCase("   ", TestName = "Тестирование Position при присваивании строки из пробелов.")]
        public void PositionTest_InvalidValues_ThrowsException(string? position)
        {
            var employee = new HourlyEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.Position = position!);
        }

        /// <summary>
        /// Тестирование свойства Country.
        /// </summary>
        [Test]
        [TestCase("Россия", TestName = "Тестирование Country при присваивании корректной страны.")]
        [TestCase("США", TestName = "Тестирование Country при присваивании короткой страны.")]
        [TestCase("Великобритания", TestName = "Тестирование Country при присваивании длинной страны.")]
        [TestCase("Чехия", TestName = "Тестирование Country при присваивании Чехии.")]
        [TestCase("Норвегия", TestName = "Тестирование Country при присваивании Норвегии.")]
        public void CountryTest_ValidValues(string country)
        {
            var employee = new HourlyEmployee();
            employee.Country = country;
            Assert.That(employee.Country, Is.EqualTo(country));
        }

        [Test]
        [TestCase(null, TestName = "Тестирование Country при присваивании null.")]
        [TestCase("", TestName = "Тестирование Country при присваивании пустой строки.")]
        [TestCase("   ", TestName = "Тестирование Country при присваивании строки из пробелов.")]
        public void CountryTest_InvalidValues_ThrowsException(string? country)
        {
            var employee = new HourlyEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.Country = country!);
        }
    }
}
