using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Организация
    /// </summary>
    class Organization
    {

        #region Properties

        /// <summary>
        /// Директор
        /// </summary>
        public Director director { get; set; }

        /// <summary>
        /// Заместитель директора
        /// </summary>
        public AssociateDirector associateDirector { get; set; }

        #endregion  // Properties


        #region Fields

        private ObservableCollection<Department> departments;   // департаменты в организации

        #endregion  // Fields
    }
}
