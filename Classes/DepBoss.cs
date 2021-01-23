using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Начальник департамента
    /// </summary>
    class DepBoss : Worker, IPost, ISalary
    {
        #region Constructors

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DepBoss() { Id = ++countDepBoss; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="namePost"></param>
        /// <param name="salary"></param>
        public DepBoss(string name, string lastName, string namePost, int salary)
        {
            Name = name;
            LastName = lastName;
            NamePost = namePost;
            Salary = salary;
            Id = ++countDepBoss;
        }

        #endregion  // Constructors

        #region Properties

        /// <summary>
        /// Идентификатор рабочего
        /// </summary>
        public override int Id { get; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string NamePost { get; set; }

        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public int Salary 
        {
            get; set;
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
                    $"Должность рабочего: { NamePost } | " +
                    $"Зарплата рабочего: { Salary } |";
        }

        #endregion  // Methods


        private static int countDepBoss = 0;    // количество созданных рабочих
    }
}
