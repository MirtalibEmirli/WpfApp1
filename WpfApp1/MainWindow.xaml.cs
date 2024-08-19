using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

         ObservableCollection<Process> processList { get; set; }
        public ObservableCollection<Process> ProcessList
        {
            get { return processList; }
            set
            {
                processList = value;
                OnPropertyChanged();
                   
            }

        }


        public MainWindow()
        {
            processList = new ObservableCollection<Process>();  
            InitializeComponent();
            var paints = Process.GetProcesses();
            ProcessList = new ObservableCollection<Process>(paints);
            DataContext = this;
            var p = new Process();
          
        }

        
    

        private void Create_Click(object sender, RoutedEventArgs e)
        {
          Process.Start(t1.Text);

        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
