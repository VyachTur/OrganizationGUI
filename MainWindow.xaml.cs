using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrganizationGUI.Classes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace OrganizationGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			ObservableCollection<Organization> orgs;
			orgs = returnAnyOrganization();
			organizationTree.ItemsSource = orgs;
		}






		/// <summary>
		/// Наполнение структуры организации (департаментами и сотрудниками)
		/// </summary>
		private ObservableCollection<Organization> returnAnyOrganization()
		{

			ObservableCollection<Employee> emps1 = new ObservableCollection<Employee>();

			emps1.Add(new Employee("Иван", "Иванов", "Программист", 100_000));
			emps1.Add(new Employee("Василий", "Васильев", "Программист", 100_000));
			emps1.Add(new Employee("Петр", "Петров", "Программист", 100_000));
			emps1.Add(new Employee("Федор", "Федоров", "Инженер", 90_000));

			ObservableCollection<Employee> emps2 = new ObservableCollection<Employee>();
			emps1.Add(new Employee("Иван2", "Иванов1", "Программист", 100_000));
			emps1.Add(new Employee("Василий1", "Васильев", "Программист", 100_000));
			emps1.Add(new Employee("Петр", "Петров", "Программист", 100_000));

			//Debug.WriteLine(emps1[0].Name);

			//employeesList.ItemsSource = emps1;

			Director director = Director.getInstance("Олег", "Важный", 1_000_000);
			AssociateDirector assDirector = AssociateDirector.getInstance("Игорь", "Секонд", 500_000);

			ObservableCollection<Worker> workers1 = new ObservableCollection<Worker>();

			foreach (var emp in emps1)
			{
				workers1.Add(emp);
			}

			workers1.Add(director);
			workers1.Add(assDirector);

			#region Проверка синглтона

			// Проверка синглтонов Director и AssociateDirector
			//Director director1 = Director.getInstance("Олег1", "Важный1", 1_111_111);
			//AssociateDirector assDirector1 = AssociateDirector.getInstance("Игорь1", "Секонд1", 555_555);
			//Debug.WriteLine(director1);     // выведет инфу по director
			//Debug.WriteLine(assDirector1);  // выведет инфу по assDirector

			#endregion    // Проверка синглтона

			Department dep111 = new Department("Департамент 111", workers1);
			Department dep121 = new Department("Департамент 121");
			Department dep211 = new Department("Департамент 211");
			Department dep221 = new Department("Департамент 221");

			ObservableCollection<Department> deps211 = new ObservableCollection<Department>();
			ObservableCollection<Department> deps221 = new ObservableCollection<Department>();

			deps211.Add(dep111);
			deps211.Add(dep121);
			deps221.Add(dep211);
			deps221.Add(dep221);

			Department dep11 = new Department("Департамент 11", deps211);
			Department dep12 = new Department("Департамент 12");
			Department dep21 = new Department("Департамент 21");
			Department dep22 = new Department("Департамент 22", deps221);

			ObservableCollection<Department> deps21 = new ObservableCollection<Department>();
			ObservableCollection<Department> deps22 = new ObservableCollection<Department>();
			deps21.Add(dep11);
			deps21.Add(dep12);
			deps22.Add(dep21);
			deps22.Add(dep22);

			Department dep1 = new Department("Департамент 1", deps21);
			Department dep2 = new Department("Департамент 2", deps22);

			ObservableCollection<Department> deps1 = new ObservableCollection<Department>();
			deps1.Add(dep1);
			deps1.Add(dep2);


			// Вывод пробных департаментов
			Department depMain = new Department("Главный департамент", deps1);

			Organization organization = new Organization("Организация", director, assDirector, deps1);

			ObservableCollection<Organization> orgs = new ObservableCollection<Organization>();
			orgs.Add(organization);


			return orgs;


			//MessageBox.Show(organization.ToString());
			//MessageBox.Show(depMain.ToString());

			//MessageBox.Show($"Всех сотрудников: { workers1.Count }");

			//MessageBox.Show(director1.Name);
			//MessageBox.Show(assDirector1.Name);

		}
	}
}
