using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Организация
    /// </summary>
    class Organization {

		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Organization()
        { 
            Name = String.Empty;
        }

		/// <summary>
		/// Конструктор 1
		/// </summary>
		/// <param name="name">Наименование организации</param>
		/// <param name="director">Директор организации</param>
		/// <param name="associateDirector">Зам. директора</param>
		/// <param name="departments">Департаменты в организации</param>
		public Organization(string name, Director director, AssociateDirector associateDirector, ObservableCollection<Department> departments) {
            this.Name = name;
            this.director = director;
            this.associateDirector = associateDirector;
            this.departments = departments;
        }

        /// <summary>
        /// Конструктор 2
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
        public Director director { get; set; }

        /// <summary>
        /// Заместитель директора
        /// </summary>
        public AssociateDirector associateDirector { get; set; }

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

		#endregion  // Properties


		#region Methods

		/// <summary>
		/// Информация об организации
		/// </summary>
		/// <returns>String: Name, CountEmployees, CountDirectors</returns>
		public override string ToString() {
            return $"Название организации: { Name } | " +
                    $"Имя директора: {director?.Name ?? String.Empty} {director?.LastName ?? String.Empty} | " +
                    $"Имя зама: {associateDirector?.Name ?? String.Empty} {associateDirector?.LastName ?? String.Empty} | " +
                    $"Количество департаментов верхнего уровня: {CountDepartments} | ";
        }

        #endregion  // Methods


        #region Fields

        private ObservableCollection<Department> departments;   // департаменты в организации

        #endregion  // Fields
    }
}
