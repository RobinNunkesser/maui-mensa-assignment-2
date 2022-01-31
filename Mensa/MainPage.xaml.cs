using System.Diagnostics;
using Italbytz.Adapters.Meal.Mock;
using Italbytz.Ports.Common;
using Italbytz.Ports.Meal;

namespace Mensa;

public partial class MainPage : ContentPage
{
    private IService<IMealQuery, List<IMealCollection>> _service = new MockGetMealsService();
    private readonly MensaViewModel viewModel = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            SuccessHandlerAsync(await _service.Execute(
                new MealQuery() { Mensa = 42, Date = DateTime.Now }));
        }
        catch (Exception ex)
        {
            await ErrorHandlerAsync(ex);
        }
    }

    private async Task ErrorHandlerAsync(Exception ex)
    {
        await DisplayAlert("Error", ex.Message,"Ok");
    }

    private async Task SuccessHandlerAsync(List<IMealCollection> meals)
    {
        if (meals.Count > 0)
        {
            viewModel.SetMeals(meals);
        }
        else
        {
            await DisplayAlert("Error", "Keine Mahlzeiten gefunden. Mensa geschlossen?", "Ok"); 
        }
    }

}

