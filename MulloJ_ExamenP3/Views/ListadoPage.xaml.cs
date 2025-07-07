using MulloJ_ExamenP3.ViewModels;
namespace MulloJ_ExamenP3.Views;

public partial class ListadoPage : ContentPage
{
	public ListadoPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ListadoViewModel vm)
        {
            await vm.CargarSuscripcionesAsync();
        }
    }

}