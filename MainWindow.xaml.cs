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

            ObservableCollection<Employee> emps = new ObservableCollection<Employee>();

            emps.Add(new Employee("Иван", "Иванов", "Программист", 100_000));
            emps.Add(new Employee("Василий", "Васильев", "Программист", 100_000));
            emps.Add(new Employee("Петр", "Петров", "Программист", 100_000));
            emps.Add(new Employee("Федор", "Федоров", "Инженер", 90_000));

            Debug.WriteLine(emps[0].Name);

            //employeesTree.ItemsSource = emps;

            Director director = Director.getInstance("Олег", "Важный", 1_000_000);
            AssociateDirector assDirector = AssociateDirector.getInstance("Игорь", "Секонд", 500_000);

            ObservableCollection<Worker> workers = new ObservableCollection<Worker>();

            foreach (var emp in emps)
            {
                workers.Add(emp);
            }

            workers.Add(director);
            workers.Add(assDirector);

            Director director1 = Director.getInstance("Олег1", "Важный1", 11_000_000);
            AssociateDirector assDirector1 = AssociateDirector.getInstance("Игорь1", "Секонд1", 500_000);

            Department dep1111 = new Department("Департамент 1111", workers);
            Department dep1211 = new Department("Департамент 1211", workers);
            Department dep2111 = new Department("Департамент 2111", workers);
            Department dep2211 = new Department("Департамент 2211", workers);

            ObservableCollection<Department> deps211 = new ObservableCollection<Department>();
            ObservableCollection<Department> deps221 = new ObservableCollection<Department>();
            deps211.Add(dep1111);
            deps211.Add(dep1211);
            deps221.Add(dep2111);
            deps221.Add(dep2211);

            Department dep11 = new Department("Департамент 11", workers, deps211);
            Department dep12 = new Department("Департамент 12", workers, deps221);
            Department dep21 = new Department("Департамент 21", workers);
            Department dep22 = new Department("Департамент 22", workers);

            ObservableCollection<Department> deps21 = new ObservableCollection<Department>();
            ObservableCollection<Department> deps22 = new ObservableCollection<Department>();
            deps21.Add(dep11);
            deps21.Add(dep12);
            deps22.Add(dep21);
            deps22.Add(dep22);

            Department dep1 = new Department("Департамент 1", workers, deps21);
            Department dep2 = new Department("Департамент 2", workers, deps22);

            ObservableCollection<Department> deps1 = new ObservableCollection<Department>();
            deps1.Add(dep1);
            deps1.Add(dep2);


            // Вывод пробных департаментов
            Department depMain = new Department("Главный департамент", workers, deps1);

            MessageBox.Show(depMain.ToString());

            //MessageBox.Show($"Всех сотрудников: { workers.Count }");

            //MessageBox.Show(director1.Name);
            //MessageBox.Show(assDirector1.Name);
        }
    }
}
