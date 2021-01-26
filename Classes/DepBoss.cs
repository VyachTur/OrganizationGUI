using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Начальник департамента
	/// </summary>
	class DepBoss : Worker, ISalary
	{
		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public DepBoss() { Id = ++countDepBoss; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="lastName">Фамилия</param>
		/// <param name="birthDate">Дата рождения</param>
		public DepBoss(string name, string lastName, DateTime birthDate)
		{
			Name = name;
			LastName = lastName;
			BirthDate = birthDate;

			Id = ++countDepBoss;
		}

		#endregion  // Constructors

		#region Properties

		/// <summary>
		/// Идентификатор рабочего
		/// </summary>
		public override int Id { get; }


		/// <summary>
		/// Зарплата начальника департамента
		/// </summary>
		public int Salary
		{
			get { return 500_000; }
			set { Salary = value; }
		}

		#endregion  // Properties

		#region Methods

		/// <summary>
		/// Информация о рабочем
		/// </summary>
		/// <returns>String: Id, Name, CountPositions</returns>
		public override string ToString()
		{
			return $"| Идентификатор рабочего: { Id } | " +
					$"Имя рабочего: { Name } | " +
					$"Фамилия рабочего: { LastName } | " +
					$"Дата рождения рабочего: { BirthDate } | " +
					$"Должность сотрудника: начальник департамента | " +
					$"Зарплата сотрудника: { Salary } |";
		}

		#endregion  // Methods


		private static int countDepBoss = 0;    // количество созданных рабочих
	}
}
