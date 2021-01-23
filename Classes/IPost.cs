using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Должность
    /// </summary>
    interface IPost
    {
        /// <summary>
        /// Наименование должности
        /// </summary>
        public string NamePost { get; set; }
    }
}
