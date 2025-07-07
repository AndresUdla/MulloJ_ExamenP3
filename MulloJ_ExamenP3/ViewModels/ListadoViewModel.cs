using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MulloJ_ExamenP3.Models;
using MulloJ_ExamenP3.Services;

namespace MulloJ_ExamenP3.ViewModels
{
    public class ListadoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Suscripcion> Suscripciones { get; set; } = new();

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set { isBusy = value; OnPropertyChanged(); }
        }

        public ListadoViewModel()
        {
            CargarSuscripcionesAsync();
        }

        public async Task CargarSuscripcionesAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Suscripciones.Clear();
            var list = await DatabaseService.SuscripcionRepository.ObtenerSuscripcionesAsync();

            foreach (var item in list)
                Suscripciones.Add(item);

            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

