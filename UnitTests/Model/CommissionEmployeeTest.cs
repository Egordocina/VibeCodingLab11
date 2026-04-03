using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса CommissionEmployee.
    /// </summary>
    [TestFixture]
    public class CommissionEmployeeTest
    {
        /// <summary>
        /// Тестирование свойства BaseSalary.
        /// </summary>
        [Test]
        [TestCase(10000.0, TestName = "Тестирование BaseSalary при присваивании корректной зарплаты.")]
        [TestCase(1.0, TestName = "Тестирование BaseSalary при присваивании минимальной зарплаты.")]
        [TestCase(50000.0, TestName = "Тестирование BaseSalary при присваивании большой зарплаты.")]
        [TestCase(100.5, TestName = "Тестирование BaseSalary при присваивании дробной зарплаты.")]
        [TestCase(99999.99, TestName = "Тестирование BaseSalary при присваивании максимальной дробной зарплаты.")]
        public void BaseSalaryTest_ValidValues(double salary)
        {
            var employee = new CommissionEmployee();
            employee.BaseSalary = salary;
            Assert.That(employee.BaseSalary, Is.EqualTo(salary));
        }

        [Test]
        [TestCase(0, TestName = "Тестирование BaseSalary при присваивании 0.")]
        [TestCase(-1, TestName = "Тестирование BaseSalary при присваивании -1.")]
        [TestCase(-1000, TestName = "Тестирование BaseSalary при присваивании отрицательного значения.")]
        [TestCase(double.MinValue, TestName = "Тестирование BaseSalary при присваивании MinValue.")]
        public void BaseSalaryTest_InvalidValues_ThrowsException(double salary)
        {
            var employee = new CommissionEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.BaseSalary = salary);
        }

        /// <summary>
        /// Тестирование свойства CommissionRate.
        /// </summary>
        [Test]
        [TestCase(1.0, TestName = "Тестирование CommissionRate при присваивании минимальной ставки.")]
        [TestCase(10.0, TestName = "Тестирование CommissionRate при присваивании 10%.")]
        [TestCase(50.0, TestName = "Тестирование CommissionRate при присваивании 50%.")]
        [TestCase(99.0, TestName = "Тестирование CommissionRate при присваивании 99%.")]
        [TestCase(100.0, TestName = "Тестирование CommissionRate при присваивании 100%.")]
        public void CommissionRateTest_ValidValues(double rate)
        {
            var employee = new CommissionEmployee();
            employee.CommissionRate = rate;
            Assert.That(employee.CommissionRate, Is.EqualTo(rate));
        }

        [Test]
        [TestCase(0, TestName = "Тестирование CommissionRate при присваивании 0.")]
        [TestCase(-1, TestName = "Тестирование CommissionRate при присваивании -1.")]
        [TestCase(-50, TestName = "Тестирование CommissionRate при присваивании отрицательного значения.")]
        [TestCase(101, TestName = "Тестирование CommissionRate при присваивании больше 100%.")]
        public void CommissionRateTest_InvalidValues_ThrowsException(double rate)
        {
            var employee = new CommissionEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.CommissionRate = rate);
        }

        /// <summary>
        /// Тестирование свойства BonusAmount.
        /// </summary>
        [Test]
        [TestCase(1000.0, TestName = "Тестирование BonusAmount при присваивании корректного бонуса.")]
        [TestCase(1.0, TestName = "Тестирование BonusAmount при присваивании минимального бонуса.")]
        [TestCase(50000.0, TestName = "Тестирование BonusAmount при присваивании большого бонуса.")]
        [TestCase(100.5, TestName = "Тестирование BonusAmount при присваивании дробного бонуса.")]
        [TestCase(99999.99, TestName = "Тестирование BonusAmount при присваивании максимального дробного бонуса.")]
        public void BonusAmountTest_ValidValues(double bonus)
        {
            var employee = new CommissionEmployee();
            employee.BonusAmount = bonus;
            Assert.That(employee.BonusAmount, Is.EqualTo(bonus));
        }

        [Test]
        [TestCase(0, TestName = "Тестирование BonusAmount при присваивании 0.")]
        [TestCase(-1, TestName = "Тестирование BonusAmount при присваивании -1.")]
        [TestCase(-1000, TestName = "Тестирование BonusAmount при присваивании отрицательного значения.")]
        [TestCase(double.MinValue, TestName = "Тестирование BonusAmount при присваивании MinValue.")]
        public void BonusAmountTest_InvalidValues_ThrowsException(double bonus)
        {
            var employee = new CommissionEmployee();
            Assert.Throws<IncorrectArgumentException>(() => employee.BonusAmount = bonus);
        }

        /// <summary>
        /// Тестирование метода CalculateSalary.
        /// Формула: BaseSalary + (CommissionRate * BonusAmount / 100)
        /// </summary>
        [Test]
        [TestCase(10000.0, 10.0, 5000.0, 10500.0, TestName = "Тестирование CalculateSalary при стандартных значениях.")]
        [TestCase(1000.0, 1.0, 1000.0, 1010.0, TestName = "Тестирование CalculateSalary при минимальных значениях.")]
        [TestCase(50000.0, 100.0, 50000.0, 100000.0, TestName = "Тестирование CalculateSalary при максимальных значениях.")]
        [TestCase(20000.0, 25.0, 8000.0, 22000.0, TestName = "Тестирование CalculateSalary при 25% комиссии.")]
        [TestCase(30000.0, 50.0, 10000.0, 35000.0, TestName = "Тестирование CalculateSalary при 50% комиссии.")]
        public void CalculateSalaryTest_ValidValues(double baseSalary, double commissionRate, double bonusAmount, double expected)
        {
            var employee = new CommissionEmployee
            {
                BaseSalary = baseSalary,
                CommissionRate = commissionRate,
                BonusAmount = bonusAmount
            };
            var result = employee.CalculateSalary();
            Assert.That(result, Is.EqualTo(expected).Within(0.01));
        }
    }
}
