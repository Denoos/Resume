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
using Microsoft.Win32;
using Resume.Properties;

namespace Resume
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Worker selectedWorker;

        public List<Worker> Workers { get; set; }
        public Worker SelectedWorker
        {
            get => selectedWorker;
            set
            {
                selectedWorker = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedWorker))); 
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Select(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
            }
        }
    }

    public class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public byte[] Img { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Age}"; ;
        }
    }
    public class WorkerView 
    {
        private readonly Worker student;

        public WorkerView(Worker student)
        {
            this.student = student;
        }

        public string Info
        {
            get =>
                    $"{student.LastName} {student.FirstName} {student.Age}";
        }
    }
}
/*
В окне MainWindow сделать интерфейс для заполнения резюме о приеме на работу. 
Должна быть кнопка со стилем MainButton - это кнопка Сохранить
Должна быть кнопка, по которой происходит открытие диалога с выбором картинки (OpenFileDialog). Выбранная картинка отображается в компоненте Image
На всех элементах должна быть привязка для ввода/вывода данных (на Image тоже, байтовый массив)*/
