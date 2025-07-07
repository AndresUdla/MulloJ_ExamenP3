using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MulloJ_ExamenP3.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Logs { get; set; } = new();

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set { isBusy = value; OnPropertyChanged(); }
        }

        private readonly string logPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Logs_Mullo.txt"
        );

        public LogsViewModel()
        {
            CargarLogsAsync();
        }

        public async Task CargarLogsAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Logs.Clear();

            try
            {
                if (File.Exists(logPath))
                {
                    var lines = await Task.Run(() => File.ReadAllLines(logPath));
                    foreach (var line in lines)
                    {
                        Logs.Add(line);
                    }
                }
                else
                {
                    Logs.Add("No hay registros de logs aún.");
                }
            }
            catch (Exception ex)
            {
                Logs.Add($"Error al leer el archivo de logs: {ex.Message}");
            }

            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

