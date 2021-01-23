using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Департамент
	/// </summary>
	class Department 
    {
		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Department() 
        {
		    Id = ++Count_Dep;
            Name = String.Empty;
		}

		/// <summary>
		/// Конструктор 1
		/// </summary>
		/// <param name="name">Наименование департамента</param>
		public Department(string name)
        {
            Name = name;

            workers = new ObservableCollection<Worker>();
            departs = new ObservableCollection<Department>();

            Id = ++Count_Dep;
        }

        /// <summary>
        /// Конструктор 2.1
        /// </summary>
        /// <param name="name">Наименование департамента</param>
        /// <param name="workers">Работники департамента</param>
        public Department(string name, ObservableCollection<Worker> workers, ObservableCollection<Department> departs)
        {
            Name = name;
            this.workers = workers;
            this.departs = departs;

            Id = ++Count_Dep;
        }

        /// <summary>
        /// Конструктор 2.2
        /// </summary>
        /// <param name="name"></param>
        /// <param name="workers"></param>
        public Department(string name, ObservableCollection<Worker> workers)
            : this(name, workers, null) { }

        #endregion // Constructors


        #region Properties

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает коллекцию поддепартаментов
        /// </summary>
        public ObservableCollection<Department> Departs
		{
            get
			{
                return departs ?? new ObservableCollection<Department>();
			}
		}

        /// <summary>
        /// Количество рабочих в департаменте
        /// </summary>
        public int CountEmployees
        {
            get
            {
                int count = 0;
                foreach (var worker in workers)
                {
                    if (worker is Employee) ++count;    // подсчет рабочих
                }

                return count;
            }
        }

        /// <summary>
        /// Количество "поддепартаментов" в департаменте
        /// </summary>
        public static int CountDeparts
        {
            get
            {
                return Count_Dep;
            }
        }

        #endregion // Properties


        #region Methods

        //private int countDeparts()
        //{
        //    if (Departs != null)
        //    {
        //        foreach (var itemDep in Departs)
        //        {
        //            return Departs.Count 
        //                + itemDep.countDeparts();
        //        }
        //    }

        //    return 0;
        //}


        /// <summary>
        /// Возвращает сотрудника по его идентификатору
        /// </summary>
        /// <param name="idEmpl">Идентификатор сотрудника отдела</param>
        /// <returns></returns>
        //public Employee returnEmplAtId(int idEmpl)
        //{
        //    return this.employees_Dep.Find((item) => item.Id == idEmpl);
        //}


        /// <summary>
        /// Информация о департаменте
        /// </summary>
        /// <returns>String: Id, Name, CountEmployees, CountDirectors</returns>
        public override string ToString()
        {
            return  $"| Идентификатор отдела: { Id } | " +
                    $"Название отдела: { Name } | " +
                    $"Количество сотрудников: { CountEmployees } | " +
                    $"Количество поддепартаментов: { CountDeparts } |";
        }

        #endregion // Methods


        #region Fields

        private ObservableCollection<Worker> workers;           // работники департамента
        private ObservableCollection<Department> departs;    // "поддепартаменты"

        private static int Count_Dep = 0;                      // счетчик для идентификатора департамента

        #endregion // Fields

    }
}
