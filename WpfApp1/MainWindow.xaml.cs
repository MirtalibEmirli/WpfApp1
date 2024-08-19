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
          
        }

        
    

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 
                Process process = Process.Start(t1.Text);

                
                if (process != null)
                {
                    ProcessList.Add(process);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process p = new ();
                foreach (var item in items.SelectedItems)
                {
                    var process = item as Process;

                    if (process != null)
                    {
                        if (process.SessionId == Process.GetCurrentProcess().SessionId)
                        {
                            process.Kill();
                            p = process;
                        }
                        else
                        {
                            MessageBox.Show($"You cannot terminate this process: {process.ProcessName}");
                        }
                    }
                }
                ProcessList.Remove(p);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error terminating process: {ex.Message}");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
