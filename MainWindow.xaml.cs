﻿using System;
using System.Windows;
using OrganizationGUI.Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Win32;

namespace OrganizationGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// 
	/// Программа реализует структуру Организации и представляет ее
	/// в графическом интерфейсе с использованием WPF.
	/// В директории с программой находится файл organization.xml с данными об
	/// организации "Организация", который можно загрузить,
	/// выполнив Файл -> Загрузить, и выбрав данный xml-файл.
	/// Также можно произвести выгрузку данных организации в xml-файл, выполнив
	/// Файл -> Выгрузить.
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			#region Наполнение структуры организации из кода

			//ObservableCollection<Organization> orgs;
			//orgs = returnAnyOrganization();

			//organizationTree.ItemsSource = orgs;
			//DataContext = orgs[0];

			#endregion    // Наполнение структуры организации из кода
		}



		/// <summary>
		/// Выгрузка (сериализация) структуры организации (обработчик на нажатие меню "Выгрузить")
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItemUnload_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Xml file (*.xml)|*.xml";
			saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

			if (saveFileDialog.ShowDialog() == true)
			{
				// Если организация существует, то выгружаем данные
				if (organizationTree.ItemsSource != null)
				{
					(organizationTree.ItemsSource as ObservableCollection<Organization>)[0]
																	.xmlOrganizationSerializer(saveFileDialog.FileName);
				}
			}

		}

		/// <summary>
		/// Загрузка (десериализация) структуры организации (обработчик на нажатие меню "Загрузить")
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Xml file (*.xml)|*.xml";
			openFileDialog.InitialDirectory = @"c:\temp\";

			if (openFileDialog.ShowDialog() == true)
			{
				// Если организация существует, то спрашиваем о дальнейшей загрузке новой
				if (!organizationTree.Items.IsEmpty)
				{
					var answer = MessageBox.Show("Структура организации не пуста! Вы уверены, что хотите перезаписать данные?",
																"Загрузка", MessageBoxButton.YesNo, MessageBoxImage.Warning);

					if (answer == MessageBoxResult.No)
					{
						return;
					}
					else if (answer == MessageBoxResult.Yes)
					{
						Debug.WriteLine("ПЕРЕЗАПИСЬ ТЕКУЩЕЙ СТРУКТУРЫ!");

						// Очищаем структуру
						(organizationTree.ItemsSource as ObservableCollection<Organization>).Clear();
					}

				}

				Organization org = Organization.xmlOrganizationDeserializer(openFileDialog.FileName);

				ObservableCollection<Organization> orgs = new ObservableCollection<Organization>();
				orgs.Add(org);

				organizationTree.ItemsSource = orgs;
				DataContext = orgs[0];
			}

		}


		/// <summary>
		/// Выход из программы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
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
			workers1.Add(new Employee("Шарап", "Сишарпов", new DateTime(1974, 6, 17), "Главный программист", 1_000));
			workers1.Add(new Employee("Иван", "Иванов", new DateTime(1975, 7, 18), "Программист", 800));
			workers1.Add(new Employee("Василий", "Васильев", new DateTime(1976, 8, 19), "Программист", 800));
			workers1.Add(new Employee("Петр", "Петров", new DateTime(1977, 9, 22), "Программист", 800));
			workers1.Add(new Employee("Игорь", "Федоров", new DateTime(1978, 10, 24), "Системный администратор", 600));
			workers1.Add(new Employee("Матвей", "Павлов", new DateTime(1979, 11, 26), "Инженер", 650));
			workers1.Add(new Employee("Марина", "Маринина", new DateTime(1980, 12, 27), "Инженер", 650));
			workers1.Add(new Intern("Игорь", "Новичков", new DateTime(1999, 10, 12), 50_000));
			workers1.Add(new Intern("Иван", "Непонимающий", new DateTime(1996, 8, 16), 50_000));

			// Создание департамента 1
			Department departament1 = new Department("Департамент 1", depBoss1, workers1);

			#region Департамент 11

			DepBoss depBoss11 = new DepBoss("Августина", "Анитсугва", new DateTime(1977, 7, 7));

			ObservableCollection<Worker> workers11 = new ObservableCollection<Worker>();

			workers11.Add(depBoss11);
			workers11.Add(new Employee("Иван", "Иванов", new DateTime(1973, 5, 6), "Программист", 750));
			workers11.Add(new Employee("Вячеслав", "Васильев", new DateTime(1974, 5, 7), "Системный администратор", 550));
			workers11.Add(new Employee("Федор", "Федоров", new DateTime(1975, 5, 8), "Инженер", 600));

			// Создание департамента 11
			Department departament11 = new Department("Департамент 11", depBoss11, workers11);

			#endregion // Департамент 11


			#region Департамент 12

			DepBoss depBoss12 = new DepBoss("Сократ", "Платонов", new DateTime(1988, 8, 7));

			ObservableCollection<Worker> workers12 = new ObservableCollection<Worker>();

			workers12.Add(depBoss12);
			workers12.Add(new Employee("Павел", "Плюсплюсов", new DateTime(1971, 1, 3), "Главный программист", 900));
			workers12.Add(new Employee("Иван", "Иванов", new DateTime(1971, 1, 3), "Программист", 750));
			workers12.Add(new Employee("Василий", "Васильев", new DateTime(1972, 4, 3), "Программист", 750));
			workers12.Add(new Employee("Петр", "Петров", new DateTime(1973, 2, 3), "Системный администратор", 550));
			workers12.Add(new Employee("Федор", "Федоров", new DateTime(1974, 3, 3), "Инженер", 600));
			workers12.Add(new Intern("Василий", "Ябсделал", new DateTime(2000, 2, 26), 40_000));

			// Создание департамента 12
			Department departament12 = new Department("Департамент 12", depBoss12, workers12);

			#region Департамент 121

			DepBoss depBoss121 = new DepBoss("Платон", "Сократов", new DateTime(1980, 3, 15));

			ObservableCollection<Worker> workers121 = new ObservableCollection<Worker>();

			workers121.Add(depBoss121);
			workers121.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 2, 25), "Программист", 750));
			workers121.Add(new Employee("Павел", "Петров", new DateTime(1972, 4, 28), "Системный администратор", 550));
			workers121.Add(new Employee("Евгений", "Федоров", new DateTime(1972, 3, 30), "Инженер", 600));

			// Создание департамента 121
			Department departament121 = new Department("Департамент 121", depBoss121, workers121);


			#endregion // Департамент 121


			#endregion // Департамент 12


			// Добавление поддепартаментов в департаменты
			departament12.addDepartament(departament121);
			departament1.addDepartament(departament11);
			departament1.addDepartament(departament12);


			#endregion   // Департамент 1


			#region Департамент 2

			DepBoss depBoss2 = new DepBoss("Юрий", "Возглавляющий", new DateTime(1959, 7, 8));

			ObservableCollection<Worker> workers2 = new ObservableCollection<Worker>();

			workers2.Add(depBoss2);
			workers2.Add(new Employee("Платон", "Питонов", new DateTime(1977, 09, 09), "Главный программист", 1_000));
			workers2.Add(new Employee("Сергей", "Иванов", new DateTime(1978, 10, 09), "Программист", 800));
			workers2.Add(new Employee("Евлампий", "Васильев", new DateTime(1979, 11, 09), "Программист", 800));
			workers2.Add(new Employee("Галина", "Петрова", new DateTime(1980, 12, 15), "Программист", 800));
			workers2.Add(new Employee("Юлия", "Юлина", new DateTime(1981, 09, 10), "Программист", 800));
			workers2.Add(new Employee("Евгений", "Евгеньев", new DateTime(1982, 09, 18), "Программист", 800));
			workers2.Add(new Employee("Федор", "Федоров", new DateTime(1983, 05, 12), "Системный администратор", 600));
			workers2.Add(new Employee("Иван", "Сисадминский", new DateTime(1984, 06, 30), "Системный администратор", 600));
			workers2.Add(new Employee("Владимир", "Владимиров", new DateTime(1985, 11, 21), "Инженер", 650));
			workers2.Add(new Employee("Галина", "Галинина", new DateTime(1986, 10, 15), "Инженер", 650));
			workers2.Add(new Intern("Егор", "Этокаковый", new DateTime(1995, 6, 5), 50_000));
			workers2.Add(new Intern("Анна", "Немогущая", new DateTime(1994, 11, 2), 50_000));
			workers2.Add(new Intern("Платон", "Почемучин", new DateTime(1994, 11, 2), 50_000));

			// Создание департамента 2
			Department departament2 = new Department("Департамент 2", depBoss2, workers2);

			#region Департамент 21

			DepBoss depBoss21 = new DepBoss("Павел", "Павлов", new DateTime(1991, 2, 14));

			ObservableCollection<Worker> workers21 = new ObservableCollection<Worker>();

			workers21.Add(depBoss21);
			workers21.Add(new Employee("Джон", "Джавин", new DateTime(1971, 01, 03), "Главный программист", 900));
			workers21.Add(new Employee("Константин", "Иванов", new DateTime(1975, 07, 07), "Программист", 750));
			workers21.Add(new Employee("Алексей", "Васильев", new DateTime(1976, 07, 08), "Программист", 750));
			workers21.Add(new Employee("Петр", "Петров", new DateTime(1977, 07, 09), "Программист", 750));
			workers21.Add(new Employee("Федор", "Федоров", new DateTime(1978, 07, 10), "Системный администратор", 550));
			workers21.Add(new Employee("Евгения", "Евгенина", new DateTime(1968, 07, 11), "Инженер", 600));
			workers21.Add(new Employee("Илона", "Давыдная", new DateTime(1975, 01, 16), "Инженер", 600));
			workers21.Add(new Intern("Василиса", "Немудрая", new DateTime(1997, 09, 12), 40_000));

			// Создание департамента 21
			Department departament21 = new Department("Департамент 21", depBoss21, workers21);

			#region Департамент 211

			DepBoss depBoss211 = new DepBoss("Иван", "Иванов", new DateTime(1995, 8, 11));

			ObservableCollection<Worker> workers211 = new ObservableCollection<Worker>();

			workers211.Add(depBoss211);
			workers211.Add(new Employee("Иван", "Иванов", new DateTime(1975, 01, 02), "Главный программист", 900));
			workers211.Add(new Employee("Иван", "Иванов", new DateTime(1979, 08, 10), "Программист", 750));
			workers211.Add(new Employee("Василий", "Васильев", new DateTime(1976, 02, 11), "Программист", 750));
			workers211.Add(new Employee("Федор", "Петров", new DateTime(1977, 08, 12), "Системный администратор", 550));
			workers211.Add(new Employee("Федор", "Федоров", new DateTime(1978, 09, 13), "Инженер", 600));
			workers211.Add(new Employee("Петр", "Петров", new DateTime(1985, 12, 20), "Инженер", 600));
			workers211.Add(new Intern("Акакий", "Акаконов", new DateTime(1993, 11, 07), 40_000));

			// Создание департамента 211
			Department departament211 = new Department("Департамент 211", depBoss211, workers211);

			#region Департамент 2111

			DepBoss depBoss2111 = new DepBoss("Сергей", "Сергеев", new DateTime(1986, 1, 2));

			ObservableCollection<Worker> workers2111 = new ObservableCollection<Worker>();

			workers2111.Add(depBoss2111);
			workers2111.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 02, 25), "Программист", 750));
			workers2111.Add(new Employee("Павел", "Петров", new DateTime(1972, 04, 28), "Системный администратор", 550));
			workers2111.Add(new Intern("Юлия", "Июльская", new DateTime(1995, 11, 17), 40_000));

			// Создание департамента 2111
			Department departament2111 = new Department("Департамент 2111", depBoss2111, workers2111);

			#endregion   // Департамент 2111

			#endregion    // Департамент 211


			#region Департамент 212

			DepBoss depBoss212 = new DepBoss("Артем", "Артемов", new DateTime(1993, 4, 15));

			ObservableCollection<Worker> workers212 = new ObservableCollection<Worker>();

			workers212.Add(depBoss212);
			workers212.Add(new Employee("Кирилл", "Иванов", new DateTime(1972, 02, 25), "Программист", 750));
			workers212.Add(new Employee("Павел", "Петров", new DateTime(1972, 04, 28), "Системный администратор", 550));
			workers212.Add(new Employee("Евгений", "Федоров", new DateTime(1972, 03, 30), "Инженер", 600));

			// Создание департамента 212
			Department departament212 = new Department("Департамент 212", depBoss212, workers212);

			#endregion    // Департамент 212


			#endregion // Департамент 21


			#region Департамент 22

			DepBoss depBoss22 = new DepBoss("Ада", "Байрон", new DateTime(1972, 12, 10));

			ObservableCollection<Worker> workers22 = new ObservableCollection<Worker>();

			workers22.Add(depBoss22);
			workers22.Add(new Employee("Иван", "Иванов", new DateTime(1979, 08, 10), "Программист", 750));
			workers22.Add(new Employee("Василий", "Васильев", new DateTime(1976, 02, 11), "Программист", 750));
			workers22.Add(new Employee("Федор", "Петров", new DateTime(1977, 08, 12), "Системный администратор", 550));
			workers22.Add(new Employee("Федор", "Федоров", new DateTime(1978, 09, 13), "Инженер", 600));
			workers22.Add(new Intern("Николай", "Недумающий", new DateTime(1998, 07, 02), 40_000));

			// Создание департамента 22
			Department departament22 = new Department("Департамент 22", depBoss22, workers22);

			#endregion    //	Департамент 22


			#region Департамент 23

			DepBoss depBoss23 = new DepBoss("Людмила", "Нелюдимая", new DateTime(1989, 5, 24));

			ObservableCollection<Worker> workers23 = new ObservableCollection<Worker>();

			workers23.Add(depBoss23);
			workers23.Add(new Employee("Иван", "Иванов", new DateTime(1971, 01, 03), "Программист", 750));
			workers23.Add(new Intern("Роман", "Ждущий", new DateTime(1995, 10, 27), 40_000));

			// Создание департамента 23
			Department departament23 = new Department("Департамент 23", depBoss23, workers23);

			#region Департамента 231

			DepBoss depBoss231 = new DepBoss("Ираклий", "Икаров", new DateTime(1995, 8, 11));

			ObservableCollection<Worker> workers231 = new ObservableCollection<Worker>();

			workers231.Add(depBoss231);
			workers231.Add(new Employee("Евстигней", "Старорусский", new DateTime(1958, 01, 01), "Программист", 750));
			workers231.Add(new Employee("Артур", "Молодой", new DateTime(1957, 12, 31), "Системный администратор", 550));

			// Создание департамента 231
			Department departament231 = new Department("Департамент 231", depBoss231, workers231);

			#endregion // Департамента 231


			#region Департамент 232

			DepBoss depBoss232 = new DepBoss("Аида", "Шестьдесятчетырная", new DateTime(1979, 10, 6));

			ObservableCollection<Worker> workers232 = new ObservableCollection<Worker>();

			workers232.Add(depBoss232);
			workers232.Add(new Employee("Анатолий", "Шарящий", new DateTime(1975, 01, 01), "Программист", 750));
			workers232.Add(new Employee("Петр", "Вопрошающий", new DateTime(1969, 02, 02), "Программист", 750));
			workers232.Add(new Employee("Иван", "Иванов", new DateTime(1995, 10, 19), "Системный администратор", 550));

			// Создание департамента 232
			Department departament232 = new Department("Департамент 232", depBoss232, workers232);

			#endregion


			#endregion    // Департамент 23


			// Добавление поддепартаментов в департаменты
			departament211.addDepartament(departament2111);
			departament21.addDepartament(departament211);
			departament21.addDepartament(departament212);
			departament23.addDepartament(departament231);
			departament23.addDepartament(departament232);
			departament2.addDepartament(departament21);
			departament2.addDepartament(departament22);
			departament2.addDepartament(departament23);


			#endregion  // Департамент 2


			// Создание организации
			Organization organization = new Organization("Организация", director, assDirector);
			organization.addDepartament(departament1);
			organization.addDepartament(departament2);

			ObservableCollection<Organization> orgs = new ObservableCollection<Organization>();
			orgs.Add(organization);


			return orgs;

		}

	}
}
