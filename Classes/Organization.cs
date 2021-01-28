using System;
using System.Collections.ObjectModel;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Организация
	/// </summary>
	class Organization
	{

		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Organization()
		{
			Name = String.Empty;
			departments = new ObservableCollection<Department>();
		}

		/// <summary>
		/// Конструктор 1.1
		/// </summary>
		/// <param name="name">Наименование организации</param>
		/// <param name="director">Директор организации</param>
		/// <param name="associateDirector">Зам. директора</param>
		/// <param name="departments">Департаменты в организации</param>
		public Organization(string name, Director director, AssociateDirector associateDirector, ObservableCollection<Department> departments)
		{
			this.Name = name;
			this.Dir = director;
			this.AssociateDir = associateDirector;
			this.departments = departments;
		}

		/// <summary>
		/// Конструктор 1.2
		/// </summary>
		/// <param name="name">Наименование организации</param>
		/// <param name="director">Директор организации</param>
		/// <param name="associateDirector">Зам. директора</param>
		public Organization(string name, Director director, AssociateDirector associateDirector)
			: this(name, director, associateDirector, new ObservableCollection<Department>()) { }

		#endregion


		#region Properties

		/// <summary>
		/// Название организации
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Директор
		/// </summary>
		public Director Dir { get; set; }

		/// <summary>
		/// Заместитель директора
		/// </summary>
		public AssociateDirector AssociateDir { get; set; }

		/// <summary>
		/// Возвращает коллекцию департаментов в организации
		/// </summary>
		public ObservableCollection<Department> Departs
		{
			get
			{
				return departments ?? new ObservableCollection<Department>();
			}
		}

		/// <summary>
		/// Количество департаментов верхнего уровня
		/// </summary>
		public int CountDepartments
		{
			get
			{
				return departments?.Count ?? 0; // если департаментов в организации нет (null), то возвр. 0
			}
		}


		/// <summary>
		/// Зарплата начальника организации (15% от суммы зарплат всех подчиненных,
		/// но не менее 2000000 р.)
		/// </summary>
		public double DirSalary
		{
			get
			{
				// Зарплата начальника = (Зарплата всех сотрудников + Зарплата зам. начальника) * 0,15,
				double sum = (sumSalaryAllWorkers() + AssociateDirSalary) * 0.15;
				sum = Math.Round(sum); // округляем до целых

				return (sum < 2_000_000) ? 2_000_000 : sum;
			}
			
		}


		/// <summary>
		/// Зарплата зам. начальника организации (15% от суммы зарплат всех подчиненных, 
		/// но не менее 1000000 р.)
		/// </summary>
		public double AssociateDirSalary
		{
			get
			{
				double sum = sumSalaryAllWorkers() * 0.15;
				sum = Math.Round(sum); // округляем до целых

				return (sum < 1_000_000) ? 1_000_000 : sum;
			}
		}

		#endregion  // Properties

		/// <summary>
		/// Сумма зарплат всех работников (включая начальников департаментов)
		/// </summary>
		/// <returns>Сумма зарплат</returns>
		private double sumSalaryAllWorkers()
		{
			double sum = 0;

			foreach (var dep in Departs)
			{
				sum += dep.salaryDepWorkers() + dep.LocalBossSalary;
			}

			return sum;
		}


		#region Methods

		/// <summary>
		/// Добавление департамента в коллекцию департаментов
		/// </summary>
		/// <param name="dep">Департамент</param>
		public void AddDepatament(Department dep)
		{
			departments.Add(dep);
		}


		/// <summary>
		/// Информация об организации
		/// </summary>
		/// <returns>String: Name, CountEmployees, CountDirectors</returns>
		public override string ToString()
		{
			return $"Название организации: { Name } | " +
					$"Имя директора: {Dir?.Name ?? String.Empty} {Dir?.LastName ?? String.Empty} | " +
					$"Имя зама: {AssociateDir?.Name ?? String.Empty} {AssociateDir?.LastName ?? String.Empty} | " +
					$"Количество департаментов верхнего уровня: {CountDepartments} | ";
		}

		#endregion  // Methods


		#region Fields

		private ObservableCollection<Department> departments;   // департаменты в организации

		#endregion  // Fields
	}
}
