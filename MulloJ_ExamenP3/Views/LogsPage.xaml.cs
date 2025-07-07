using MulloJ_ExamenP3.ViewModels;
namespace MulloJ_ExamenP3.Views;

public partial class LogsPage : ContentPage
{
	public LogsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is LogsViewModel vm)
        {
            await vm.CargarLogsAsync();
        }
    }

}