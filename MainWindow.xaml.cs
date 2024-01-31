using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf1125ListsSample.Properties;

namespace Wpf1125ListsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Student selectedStudent;

        public List<Student> Students { get; set; }
        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedStudent))); 
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            Students = new List<Student>();
            Students.Add(new Student
            {
                FirstName = "Алексей",
                LastName = "Пушкин",
                Birthday = DateTime.Parse("06.07.1987"),
                Group = 1145,
                Img = Properties.Resources.mini_pin
            }) ;
            Students.Add(new Student
            {
                FirstName = "Тамара",
                LastName = "Петрова",
                Birthday = DateTime.Parse("02.10.2000"),
                Group = 1115,
                Img = Properties.Resources.mini_pin
            });
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = SelectedStudent == null ?
                "Ничего не выбрано" : 
                SelectedStudent.ToString();
            MessageBox.Show(message);
        }


        // Тема: Списки в WPF
        // существует несколько стандартных
        // компонентов для вывода списка:
        // 1. ComboBox - выпадающий список
        // 2. ListBox  - одноколоночный список
        // 3. ListView - многоколоночный список
        // 4. DataGrid - редактор для множества
        // записей с разбитием по колонкам
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
        public DateTime Birthday { get; set; }

        public byte[] Img { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Group} {Birthday.ToShortDateString()}"; ;
        }
        //public string Info { get =>
        //        $"{LastName} {FirstName} {Group} {Birthday.ToShortDateString()}";
        //}
    }
    // Если доступно наследование 
    // и недоступно редактирование Student
    //public class StudentView : Student
    //{
    //    public string Info
    //    {
    //        get =>
    //                $"{LastName} {FirstName} {Group} {Birthday.ToShortDateString()}";
    //    }
    //}

    // Либо декоратор и тп
    public class StudentView 
    {
        private readonly Student student;

        public StudentView(Student student)
        {
            this.student = student;
        }

        public string Info
        {
            get =>
                    $"{student.LastName} {student.FirstName} {student.Group} {student.Birthday.ToShortDateString()}";
        }
    }
}
