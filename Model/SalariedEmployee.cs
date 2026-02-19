namespace Model
{
	/// <summary>
	/// Гонщик с оплатой по окладу.
	/// </summary>
	public class SalariedEmployee : EmployeeBase
	{
		//TODO: XML+
		/// <summary>
		/// Назначение оклада для гонщика согласно разряду.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="IncorrectArgumentException"></exception>
		public override double CalculateSalary()
		{
			foreach (var pos in PositionData)
			{
				if (pos.Value.Name == Position)
					return pos.Value.Salary;
			}
			throw new IncorrectArgumentException("Неизвестный разряд для " +
				"расчета оклада.");
		}

	}
}