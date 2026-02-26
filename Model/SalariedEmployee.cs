namespace Model
{
	/// <summary>
	/// Гонщик с оплатой по окладу.
	/// </summary>
	public class SalariedEmployee : EmployeeBase
	{
		/// <summary>
		/// Русское название типа сотрудника.
		/// </summary>
		public override string TypeName => "По окладу";

		/// <summary>
		/// Назначение оклада для гонщика согласно разряду.
		/// </summary>
		/// <returns>Оклад в рублях.</returns>
		/// <exception cref="IncorrectArgumentException">
		/// Если разряд неизвестен.
		/// </exception>
		public override double CalculateSalary()
		{
			foreach (var pos in PositionData)
			{
				if (pos.Value.Name == Position)
					return pos.Value.Salary;
			}
			throw new IncorrectArgumentException(
				"Неизвестный разряд для расчета оклада.");
		}

	}
}