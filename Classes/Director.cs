﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Класс директора (синглтон, т.к. директор в организации один)
	/// </summary>
	class Director : Worker, ISalary
	{
		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		protected Director() { }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="lastName">Фамилия</param>
		/// <param name="birthDate">Дата рождения</param>
		/// <param name="salary">Зарплата</param>
		protected Director(string name, string lastName, DateTime birthDate)
		{
			Name = name;
			LastName = lastName;
			BirthDate = birthDate;

			Id = 1;
		}

		#endregion  // Constructors

		#region Properties

		/// <summary>
		/// Идентификатор директора
		/// </summary>
		public override int Id { get; }

		/// <summary>
		/// Зарплата директора
		/// </summary>
		public int Salary
		{
			get;
			set;
		}

		#endregion  // Properties

		#region Methods

		public static Director getInstance(string name, string lastName, DateTime birthDate)
		{
			if (instance == null)
				instance = new Director(name, lastName, birthDate);
			return instance;
		}

		/// <summary>
		/// Информация о директоре
		/// </summary>
		/// <returns>String: Id, Name, LastName, BirthDate, Salary</returns>
		public override string ToString()
		{
			return $"| Идентификатор директора: { Id } | " +
					$"Имя директора: { Name } | " +
					$"Фамилия директора: { LastName } | " +
					$"Дата рождения директора: { BirthDate } | " +
					$"Зарплата директора: { Salary } |";
		}

		#endregion  // Methods

		private static Director instance;   // поле (инстанс) для синглтона

	}
}
