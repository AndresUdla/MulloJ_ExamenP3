using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MulloJ_ExamenP3.Models;
using MulloJ_ExamenP3.Services;

namespace MulloJ_ExamenP3.ViewModels
{
    public class CrearSuscripcionViewModel : INotifyPropertyChanged
    {

        private string servicio;
        public string Servicio
        {
            get => servicio;
            set { servicio = value; OnPropertyChanged(); }
        }

        private string correoAsociado;
        public string CorreoAsociado
        {
            get => correoAsociado;
            set { correoAsociado = value; OnPropertyChanged(); }
        }

        private decimal costoMensual;
        public decimal CostoMensual
        {
            get => costoMensual;
            set { costoMensual = value; OnPropertyChanged(); }
        }

        private bool renovacionAutomatica;
        public bool RenovacionAutomatica
        {
            get => renovacionAutomatica;
            set { renovacionAutomatica = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }

        public CrearSuscripcionViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarAsync());
        }

        private async Task GuardarAsync()
        {
            if ((int)CostoMensual % 2 == 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Solo se permiten costos mensuales impares.", "OK");
                return;
            }

            var nuevaSuscripcion = new Suscripcion
            {
                Servicio = Servicio,
                CorreoAsociado = CorreoAsociado,
                CostoMensual = CostoMensual,
                RenovacionAutomatica = RenovacionAutomatica
            };

            await DatabaseService.SuscripcionRepository.AgregarSuscripcionAsync(nuevaSuscripcion);

            string log = $"Se incluyó el registro [{Servicio}] el {DateTime.Now:dd/MM/yyyy HH:mm}";
            string logPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Logs_Mullo.txt"
            );
            File.AppendAllText(logPath, log + Environment.NewLine);

            Servicio = string.Empty;
            CorreoAsociado = string.Empty;
            CostoMensual = 0;
            RenovacionAutomatica = false;

            await App.Current.MainPage.DisplayAlert("Éxito", "Suscripción guardada correctamente.", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}