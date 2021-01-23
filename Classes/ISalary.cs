﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationGUI.Classes
{
    /// <summary>
    /// Зарплата
    /// </summary>
    interface ISalary
    {
        /// <summary>
        /// Размер зарплаты
        /// </summary>
        int Salary { get; set; }
    }
}