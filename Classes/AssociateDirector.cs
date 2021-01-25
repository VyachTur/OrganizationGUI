using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Заместитель директора организации (синглтон, т.к. зам один в организации)
	/// </summary>
	class AssociateDirector : Worker, ISalary
	{
		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		protected AssociateDirector() { }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name"></param>
		/// <param name="lastName"></param>
		/// <param name="namePost"></param>
		/// <param name="salary"></param>
		protected AssociateDirector(string name, string lastName, DateTime birthDate, int salary)
		{
			Name = name;
			LastName = lastName;
			BirthDate = birthDate;
			Salary = salary;
			Id = 1;
		}

		#endregion  // Constructors

		#region Properties

		/// <summary>
		/// Идентификатор заместителя директора
		/// </summary>
		public override int Id { get; }

		/// <summary>
		/// Зарплата заместителя директора
		/// </summary>
		public int Salary
		{
			get;
			set;
		}

		#endregion  // Properties

		#region Methods

		/// <summary>
		/// Возвращает инстанс зам. директора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="lastName"></param>
		/// <param name="salary"></param>
		/// <returns></returns>
		public static AssociateDirector getInstance(string name, string lastName, DateTime birthDate, int salary)
		{
			if (instance == null)
				instance = new AssociateDirector(name, lastName, birthDate, salary);
			return instance;
		}

		/// <summary>
		/// Информация о заместителе директора
		/// </summary>
		/// <returns>String: Id, Name, LastName, BirthDate, Salary</returns>
		public override string ToString()
		{
			return $"| Идентификатор заместителя директора: { Id } | " +
					$"Имя заместителя директора: { Name } | " +
					$"Фамилия заместителя директора: { LastName } | " +
					$"Дата рождения заместителя директора: { BirthDate } | " +
					$"Зарплата заместителя директора: { Salary } |";
		}

		#endregion  // Methods

		private static AssociateDirector instance;   // поле (инстанс) для синглтона

	}
}
