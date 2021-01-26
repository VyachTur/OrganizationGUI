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


			Director director = Director.getInstance("Олег", "Важный", new DateTime(1961, 1, 1));
			AssociateDirector assDirector = AssociateDirector.getInstance("Игорь", "Чутьменееважный", new DateTime(1962, 2, 2));


			#region Департамент 1

			DepBoss depBoss1 = new DepBoss("Михаил", "Руководящий", new DateTime(1959, 7, 8));

			ObservableCollection<Worker> workers1 = new ObservableCollection<Worker>();

			workers1.Add(depBoss1);
			workers1.Add(new Employee("Шарап", "Сишарпов", new DateTime(1974, 6, 17), "Главный программист", 160_000));
			workers1.Add(new Employee("Иван", "Иванов", new DateTime(1975, 7, 18), "Программист", 110_000));
			workers1.Add(new Employee("Василий", "Васильев", new DateTime(1976, 8, 19), "Программист", 110_000));
			workers1.Add(new Employee("Петр", "Петров", new DateTime(1977, 9, 22), "Программист", 110_000));
			workers1.Add(new Employee("Игорь", "Федоров", new DateTime(1978, 10, 24), "Системный администратор", 90_000));
			workers1.Add(new Employee("Матвей", "Павлов", new DateTime(1979, 11, 26), "Инженер", 95_000));
			workers1.Add(new Employee("Марина", "Маринина", new DateTime(1980, 12, 27), "Инженер", 95_000));

			// Создание департамента 1
			Department departament1 = new Department("Департамент 12", depBoss1, workers1);

			#region Департамент 11

			DepBoss depBoss11 = new DepBoss("Августина", "Анитсугва", new DateTime(1977, 7, 7));

			ObservableCollection<Worker> workers11 = new ObservableCollection<Worker>();

			workers11.Add(depBoss11);
			workers11.Add(new Employee("Иван", "Иванов", new DateTime(1973, 5, 6), "Программист", 100_000));
			workers11.Add(new Employee("Вячеслав", "Васильев", new DateTime(1974, 5, 7), "Системный администратор", 100_000));
			workers11.Add(new Employee("Федор", "Федоров", new DateTime(1975, 5, 8), "Инженер", 90_000));

			// Создание департамента 11
			Department departament11 = new Department("Департамент 11", depBoss11, workers11);

			#endregion // Департамент 11


			#region Департамент 12

			DepBoss depBoss12 = new DepBoss("Сократ", "Платонов", new DateTime(1988, 8, 7));

			ObservableCollection<Worker> workers12 = new ObservableCollection<Worker>();

			workers12.Add(depBoss12);
			workers12.Add(new Employee("Павел", "Плюсплюсов", new DateTime(1971, 1, 3), "Главный программист", 150_000));
			workers12.Add(new Employee("Иван", "Иванов", new DateTime(1971, 1, 3), "Программист", 100_000));
			workers12.Add(new Employee("Василий", "Васильев", new DateTime(1972, 4, 3), "Программист", 100_000));
			workers12.Add(new Employee("Петр", "Петров", new DateTime(1973, 2, 3), "Системный администратор", 100_000));
			workers12.Add(new Employee("Федор", "Федоров", new DateTime(1974, 3, 3), "Инженер", 90_000));

			// Создание департамента 12
			Department departament12 = new Department("Департамент 12", depBoss12, workers12);

			#region Департамент 121

			DepBoss depBoss121 = new DepBoss("Платон", "Сократов", new DateTime(1980, 3, 15));

			ObservableCollection<Worker> workers121 = new ObservableCollection<Worker>();

			workers121.Add(depBoss121);
			workers121.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 2, 25), "Программист", 100_000));
			workers121.Add(new Employee("Павел", "Петров", new DateTime(1972, 4, 28), "Системный администратор", 100_000));
			workers121.Add(new Employee("Евгений", "Федоров", new DateTime(1972, 3, 30), "Инженер", 90_000));

			// Создание департамента 121
			Department departament121 = new Department("Департамент 121", depBoss121, workers121);


			#endregion // Департамент 121


			#endregion // Департамент 12


			// Добавление поддепартаментов в департаменты
			departament12.AddDepartament(departament121);
			departament1.AddDepartament(departament12);
			departament1.AddDepartament(departament11);


			#endregion   // Департамент 1



			#region Департамент 2

			DepBoss depBoss2 = new DepBoss("Юрий", "Возглавляющий", new DateTime(1959, 7, 8));

			ObservableCollection<Worker> workers2 = new ObservableCollection<Worker>();

			workers2.Add(depBoss2);
			workers2.Add(new Employee("Платон", "Питонов", new DateTime(1977, 09, 09), "Главный программист", 160_000));
			workers2.Add(new Employee("Сергей", "Иванов", new DateTime(1978, 10, 09), "Программист", 110_000));
			workers2.Add(new Employee("Евлампий", "Васильев", new DateTime(1979, 11, 09), "Программист", 110_000));
			workers2.Add(new Employee("Галина", "Петрова", new DateTime(1980, 12, 15), "Программист", 110_000));
			workers2.Add(new Employee("Юлия", "Юлина", new DateTime(1981, 09, 10), "Программист", 110_000));
			workers2.Add(new Employee("Евгений", "Евгеньев", new DateTime(1982, 09, 18), "Программист", 110_000));
			workers2.Add(new Employee("Федор", "Федоров", new DateTime(1983, 05, 12), "Системный администратор", 95_000));
			workers2.Add(new Employee("Иван", "Сисадминский", new DateTime(1984, 06, 30), "Системный администратор", 95_000));
			workers2.Add(new Employee("Владимир", "Владимиров", new DateTime(1985, 11, 21), "Инженер", 100_000));
			workers2.Add(new Employee("Галина", "Галинина", new DateTime(1986, 10, 15), "Инженер", 100_000));

			// Создание департамента 2
			Department departament2 = new Department("Департамент 2", depBoss2, workers2);

			#region Департамент 21

			DepBoss depBoss21 = new DepBoss("Павел", "Павлов", new DateTime(1991, 2, 14));

			ObservableCollection<Worker> workers21 = new ObservableCollection<Worker>();

			workers21.Add(depBoss21);
			workers21.Add(new Employee("Джон", "Джавин", new DateTime(1971, 01, 03), "Главный программист", 150_000));
			workers21.Add(new Employee("Константин", "Иванов", new DateTime(1975, 07, 07), "Программист", 100_000));
			workers21.Add(new Employee("Алексей", "Васильев", new DateTime(1976, 07, 08), "Программист", 100_000));
			workers21.Add(new Employee("Петр", "Петров", new DateTime(1977, 07, 09), "Программист", 100_000));
			workers21.Add(new Employee("Федор", "Федоров", new DateTime(1978, 07, 10), "Системный администратор", 90_000));
			workers21.Add(new Employee("Евгения", "Евгенина", new DateTime(1968, 07, 11), "Инженер", 90_000));
			workers21.Add(new Employee("Илона", "Давыдная", new DateTime(1975, 01, 16), "Инженер", 90_000));

			// Создание департамента 21
			Department departament21 = new Department("Департамент 21", depBoss21, workers21);

			#region Департамент 211

			DepBoss depBoss211 = new DepBoss("Иван", "Иванов", new DateTime(1995, 8, 11));

			ObservableCollection<Worker> workers211 = new ObservableCollection<Worker>();

			workers211.Add(depBoss211);
			workers211.Add(new Employee("Иван", "Иванов", new DateTime(1975, 01, 02), "Главный программист", 140_000));
			workers211.Add(new Employee("Иван", "Иванов", new DateTime(1979, 08, 10), "Программист", 100_000));
			workers211.Add(new Employee("Василий", "Васильев", new DateTime(1976, 02, 11), "Программист", 100_000));
			workers211.Add(new Employee("Федор", "Петров", new DateTime(1977, 08, 12), "Системный администратор", 100_000));
			workers211.Add(new Employee("Федор", "Федоров", new DateTime(1978, 09, 13), "Инженер", 90_000));
			workers211.Add(new Employee("Петр", "Петров", new DateTime(1985, 12, 20), "Инженер", 90_000));

			// Создание департамента 211
			Department departament211 = new Department("Департамент 211", depBoss211, workers211);

			#region Департамент 2111

			DepBoss depBoss2111 = new DepBoss("Сергей", "Сергеев", new DateTime(1986, 1, 2));

			ObservableCollection<Worker> workers2111 = new ObservableCollection<Worker>();

			workers2111.Add(depBoss2111);
			workers2111.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 02, 25), "Программист", 75_000));
			workers2111.Add(new Employee("Павел", "Петров", new DateTime(1972, 04, 28), "Системный администратор", 65_000));

			// Создание департамента 2111
			Department departament2111 = new Department("Департамент 2111", depBoss2111, workers2111);

			#endregion   // Департамент 2111

			#endregion    // Департамент 211


			#region Департамент 212

			DepBoss depBoss212 = new DepBoss("Артем", "Артемов", new DateTime(1993, 4, 15));

			ObservableCollection<Worker> workers212 = new ObservableCollection<Worker>();

			workers212.Add(depBoss212);
			workers212.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 02, 25), "Программист", 100_000));
			workers212.Add(new Employee("Павел", "Петров", new DateTime(1972, 04, 28), "Системный администратор", 100_000));
			workers212.Add(new Employee("Евгений", "Федоров", new DateTime(1972, 03, 30), "Инженер", 90_000));

			// Создание департамента 212
			Department departament212 = new Department("Департамент 212", depBoss212, workers212);

			#endregion    // Департамент 212


			#endregion // Департамент 21


			#region Департамент 22

			DepBoss depBoss22 = new DepBoss("Ада", "Байрон", new DateTime(1972, 12, 10));

			ObservableCollection<Worker> workers22 = new ObservableCollection<Worker>();

			workers22.Add(depBoss22);
			workers22.Add(new Employee("Иван", "Иванов", new DateTime(1979, 08, 10), "Программист", 100_000));
			workers22.Add(new Employee("Василий", "Васильев", new DateTime(1976, 02, 11), "Программист", 100_000));
			workers22.Add(new Employee("Федор", "Петров", new DateTime(1977, 08, 12), "Системный администратор", 100_000));
			workers22.Add(new Employee("Федор", "Федоров", new DateTime(1978, 09, 13), "Инженер", 90_000));

			// Создание департамента 22
			Department departament22 = new Department("Департамент 22", depBoss22, workers22);

			#endregion    //	Департамент 22


			#region Департамент 23

			DepBoss depBoss23 = new DepBoss("Людмила", "Нелюдимая", new DateTime(1989, 5, 24));

			ObservableCollection<Worker> workers23 = new ObservableCollection<Worker>();

			workers23.Add(depBoss23);
			workers23.Add(new Employee("Иван", "Иванов", new DateTime(1971, 01, 03), "Программист", 100_000));

			// Создание департамента 23
			Department departament23 = new Department("Департамент 23", depBoss23, workers23);

			#region Департамента 231

			DepBoss depBoss231 = new DepBoss("Ираклий", "Икаров", new DateTime(1995, 8, 11));

			ObservableCollection<Worker> workers231 = new ObservableCollection<Worker>();

			workers231.Add(depBoss231);
			workers231.Add(new Employee("Евстигней", "Старорусский", new DateTime(1958, 01, 01), "Программист", 75_000));
			workers231.Add(new Employee("Артур", "Молодой", new DateTime(1957, 12, 31), "Системный администратор", 74_000));

			// Создание департамента 231
			Department departament231 = new Department("Департамент 231", depBoss231, workers231);

			#endregion // Департамента 231


			#region Департамент 232

			DepBoss depBoss232 = new DepBoss("Аида", "Шестьдесятчетырная", new DateTime(1979, 10, 6));

			ObservableCollection<Worker> workers232 = new ObservableCollection<Worker>();

			workers232.Add(depBoss232);
			workers232.Add(new Employee("Анатолий", "Шарящий", new DateTime(1975, 01, 01), "Программист", 75_000));
			workers232.Add(new Employee("Петр", "Вопрошающий", new DateTime(1969, 02, 02), "Программист", 70_000));
			workers232.Add(new Employee("Иван", "Иванов", new DateTime(1995, 10, 19), "Системный администратор", 65_000));

			// Создание департамента 232
			Department departament232 = new Department("Департамент 232", depBoss232, workers232);

			#endregion


			#endregion    // Департамент 23


			// Добавление поддепартаментов в департаменты
			departament211.AddDepartament(departament2111);
			departament21.AddDepartament(departament211);
			departament21.AddDepartament(departament212);
			departament23.AddDepartament(departament231);
			departament23.AddDepartament(departament232);
			departament2.AddDepartament(departament21);
			departament2.AddDepartament(departament22);
			departament2.AddDepartament(departament23);


			#endregion  // Департамент 2


			//ObservableCollection<Worker> workers1 = new ObservableCollection<Worker>();

			//foreach (var emp in emps1)
			//{
			//	workers1.Add(emp);
			//}

			//workers1.Add(director);
			//workers1.Add(assDirector);

			#region Проверка синглтона

			// Проверка синглтонов Director и AssociateDirector
			//Director director1 = Director.getInstance("Олег1", "Важный1", 1_111_111);
			//AssociateDirector assDirector1 = AssociateDirector.getInstance("Игорь1", "Секонд1", 555_555);
			//Debug.WriteLine(director1);     // выведет инфу по director
			//Debug.WriteLine(assDirector1);  // выведет инфу по assDirector

			#endregion    // Проверка синглтона


			// Создание организации
			Organization organization = new Organization("Организация", director, assDirector);
			organization.AddDepatament(departament1);
			organization.AddDepatament(departament2);

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
