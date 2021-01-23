using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Интерн
    /// </summary>
    class Intern : Worker, IPost, ISalary
    {
        #region Constructors

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Intern() { Id = ++countIntern; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="namePost"></param>
        /// <param name="salary"></param>
        public Intern(string name, string lastName, string namePost, int salary)
        {
            Name = name;
            LastName = lastName;
            NamePost = namePost;
            Salary = salary;
            Id = ++countIntern;
        }

        #endregion  // Constructors

        #region Properties

        /// <summary>
        /// Идентификатор интерна
        /// </summary>
        public override int Id { get; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string NamePost { get; set; }

        /// <summary>
        /// Зарплата интерна
        /// </summary>
        public int Salary
        {
            get; set;
        }

        #endregion  // Properties

        #region Methods

        /// <summary>
        /// Информация об интерне
        /// </summary>
        /// <returns>String: Id, Name, LastName, BirthDate, NamePost, Salary</returns>
        public override string ToString()
        {
            return $"| Идентификатор интерна: { Id } | " +
                    $"Имя интерна: { Name } | " +
                    $"Фамилия интерна: { LastName } | " +
                    $"Дата рождения интерна: { BirthDate } | " +
                    $"Должность интерна: { NamePost } | " +
                    $"Зарплата интерна: { Salary } |";
        }

        #endregion  // Methods


        private static int countIntern = 0;    // количество созданных интернов
    }
}
