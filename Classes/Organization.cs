using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OrganizationGUI.Classes
{
	/// <summary>
	/// Организация
	/// </summary>
	public class Organization
	{

		#region Constructors

		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Organization()
		{
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
		public void AddDepartament(Department dep)
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



		#region XML        
		/// <summary>
		/// Сериализует организацию (xml)
		/// </summary>
		/// /// <param name="path">Путь к файлу экспорта (xml)</param>
		public void xmlOrganizationSerializer(string path)
		{

			XElement xeORGANIZATION = new XElement("ORGANIZATION");
			XAttribute xaNAME_ORG = new XAttribute("orgname", this.Name);

			XAttribute xaNAME_DIR = new XAttribute("dirname", this.Dir.Name);
			XAttribute xaLASTNAME_DIR = new XAttribute("dirlastname", this.Dir.LastName);
			XAttribute xaBIRTHDATE_DIR = new XAttribute("dirbirth", this.Dir.BirthDate);

			XAttribute xaNAME_ASSDIR = new XAttribute("assdirname", this.AssociateDir.Name);
			XAttribute xaLASTNAME_ASSDIR = new XAttribute("assdirlastname", this.AssociateDir.LastName);
			XAttribute xaBIRTHDATE_ASSDIR = new XAttribute("assdirbirth", this.AssociateDir.BirthDate);

			// ДЕПАРТАМЕНТЫ ОРГАНИЗАЦИИ
			XElement xeDEPARTMENTS = new XElement("DEPARTMENTS");

			//////
			///TODO: ПРИКРУТИТЬ РЕКУРСИЮ ДЛЯ СЕРИАЛИЗАЦИИ ВСЕХ ДЕПАРТАМЕНТОВ И ПОДДЕПАРТАМЕНТОВ
			///

			foreach (Department dep in Departs)
			{
				XElement xeDEPARTMENT = serializerSubDeps(dep);

				xeDEPARTMENTS.Add(xeDEPARTMENT);
			}

			xeORGANIZATION.Add(xeDEPARTMENTS, xaBIRTHDATE_ASSDIR, xaLASTNAME_ASSDIR, xaNAME_ASSDIR, xaBIRTHDATE_DIR,
								xaLASTNAME_DIR, xaNAME_DIR, xaNAME_ORG);

			xeORGANIZATION.Save(path);
		}


		/// <summary>
		/// Вспомогательный рекурсивный метод для сереализации департамента и его поддепартаментов
		/// </summary>
		/// <param name="dep">Департамент</param>
		/// <returns>XML-узел</returns>
		private XElement serializerSubDeps(Department dep)
		{

			XElement xeDEPARTMENT = new XElement("DEPARTMENT");

			XAttribute xaNAME_DEP = new XAttribute("depname", dep.Name);
			XAttribute xaNAME_DEPBOSS = new XAttribute("depbossname", dep.LocalBoss.Name);
			XAttribute xaLASTNAME_DEPBOSS = new XAttribute("depbosslastname", dep.LocalBoss.LastName);
			XAttribute xaBIRTHDATE_DEPBOSS = new XAttribute("depbossbirth", dep.LocalBoss.BirthDate);

			// СОТРУДНИКИ ОРГАНИЗАЦИИ
			XElement xeEMPLOYEES = new XElement("EMPLOYEES");

			foreach (Employee emp in dep.Employees)
			{
				XElement xeEMPLOYEE = new XElement("EMPLOYEE");

				XAttribute xaNAME_EMP = new XAttribute("empname", emp.Name);
				XAttribute xaLASTNAME_EMP = new XAttribute("emplastname", emp.LastName);
				XAttribute xaBIRTHDATE_EMP = new XAttribute("empbirthdate", emp.BirthDate);
				XAttribute xaPOST_EMP = new XAttribute("empnamepost", emp.NamePost);
				XAttribute xaSALARY_EMP = new XAttribute("empsalary", emp.Salary / 168);

				xeEMPLOYEE.Add(xaSALARY_EMP, xaPOST_EMP, xaBIRTHDATE_EMP, xaLASTNAME_EMP, xaNAME_EMP);

				xeEMPLOYEES.Add(xeEMPLOYEE);
			}

			// ИНТЕРНЫ ОРГАНИЗАЦИИ
			XElement xeINTERNS = new XElement("INTERNS");

			foreach (Intern intern in dep.Interns)
			{
				XElement xeINTERN = new XElement("INTERN");

				XAttribute xaNAME_INTERN = new XAttribute("internname", intern.Name);
				XAttribute xaLASTNAME_INTERN = new XAttribute("internlastname", intern.LastName);
				XAttribute xaBIRTHDATE_INTERN = new XAttribute("internbirthdate", intern.BirthDate);
				XAttribute xaSALARY_INTERN = new XAttribute("internsalary", intern.Salary);

				xeINTERN.Add(xaSALARY_INTERN, xaBIRTHDATE_INTERN, xaLASTNAME_INTERN, xaNAME_INTERN);

				xeINTERNS.Add(xeINTERN);
			}

			xeDEPARTMENT.Add(xaBIRTHDATE_DEPBOSS, xaLASTNAME_DEPBOSS, xaNAME_DEPBOSS, xaNAME_DEP);
			xeDEPARTMENT.Add(xeEMPLOYEES);
			xeDEPARTMENT.Add(xeINTERNS);

			if (dep.CountDeparts > 0)
			{
				// ПОДДЕПАРТАМЕНТЫ ДЕПАРТАМЕНТА
				XElement xeSUBDEPARTMENTS = new XElement("DEPARTMENTS");

				foreach (Department department in dep.Departs)
				{
					XElement xeDEP = serializerSubDeps(department);

					xeSUBDEPARTMENTS.Add(xeDEP);
				}

				xeDEPARTMENT.Add(xeSUBDEPARTMENTS);

			}

			return xeDEPARTMENT;

		}


		/// <summary>
		/// Десериализует организацию (xml)
		/// </summary>
		/// <param name="path">Путь к файлу импорта (xml)</param>
		//public static Organization xmlOrganizationDeserializer(string path)
		//{

		//	// ЗАГЛУШКА!
		//	return new Organization();

		//}



		/// <summary>
		/// Десериализует организацию (xml)
		/// </summary>
		/// <param name="path">Путь к файлу импорта (xml)</param>
		//public static Organization xmlOrganizationDeserializer(string path)
		//{

		//	string xml = File.ReadAllText(path);

		//	Director dir = Director.getInstance();
		//	AssociateDirector assDir = new AssociateDirector();

		//	Organization org = new Organization(XDocument.Parse(xml).Element("ORGANIZATION").Attribute("orgname").Value, dir, assDir);



		//	tmpOrganization.Name = XDocument.Parse(xml)
		//							.Element("ORGANIZATION")
		//							.Attribute("orgname").Value;

		//	tmpOrganization.Dir.Name = XDocument.Parse(xml)
		//								.Element("ORGANIZATION")
		//								.Attribute("dirname").Value

		//	var colDepsXml = XDocument.Parse(xml)
		//						.Descendants("ORGANIZATION")
		//						.Descendants("DEPARTMENTS")
		//						.Descendants("DEPARTMENT")
		//						.ToList();

		//	// Цикл по департаментам (отделам) в организации
		//	foreach (var itemDepXml in colDepsXml)
		//	{
		//		Department dep = new Department(itemDepXml.Attribute("name").Value);

		//		dep.CreateDate = DateTime.Parse(itemDepXml.Attribute("createdate").Value);

		//		// Цикл по должностям в отделе
		//		foreach (var itemPosXml in itemDepXml.Element("POSITIONS").Elements())
		//		{
		//			Position pos = new Position(itemPosXml.Attribute("name").Value,
		//											uint.Parse(itemPosXml.Attribute("salary").Value));
		//			dep.addPost(pos);
		//		}

		//		// Цикл по сотрудникам в отделе
		//		foreach (var itemEmpXml in itemDepXml.Element("EMPLOYEES").Elements())
		//		{
		//			// Создание нового сотрудника
		//			Employee emp = new Employee(itemEmpXml.Attribute("name").Value,
		//										itemEmpXml.Attribute("family").Value,
		//										itemEmpXml.Attribute("sirname").Value,
		//										DateTime.Parse(itemEmpXml.Attribute("birthdate").Value),
		//										dep.returnPosts().Find((item) => item.Name == itemEmpXml.Element("POSITION").Attribute("name").Value
		//																			&& item.Salary == uint.Parse(itemEmpXml.Element("POSITION").Attribute("salary").Value)));

		//			// Цикл по проектам сотрудника
		//			foreach (var itemEmpProjXml in itemEmpXml.Element("PROJECTS").Elements())
		//			{
		//				emp.addProject(new Project(itemEmpProjXml.Attribute("name").Value,
		//											DateTime.Parse(itemEmpProjXml.Attribute("datebegin").Value),
		//											DateTime.Parse(itemEmpProjXml.Attribute("dateend").Value),
		//											itemEmpProjXml.Attribute("description").Value));
		//			}


		//			dep.addEmpl(emp);   // добавляем созданного сотрудника в отдел
		//		}

		//		tmpOrganization.addDepartment(dep); // добавляем созданный отдел в организацию
		//	}





		//	//org.AddDepartament();

		//	return org;
		//}



		#endregion  // XML


		#endregion  // Methods


		#region Fields

		private ObservableCollection<Department> departments;   // департаменты в организации

		#endregion  // Fields
	}
}
