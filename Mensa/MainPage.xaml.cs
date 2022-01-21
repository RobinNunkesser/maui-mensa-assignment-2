using System.Diagnostics;
using Italbytz.Adapters.Meal.Mock;
using Italbytz.Ports.Common;
using Italbytz.Ports.Meal;

namespace Mensa;

public partial class MainPage : ContentPage
{
    private IService<IMealQuery, List<IMealCollection>> _service = new MockGetMealsService();

    public MainPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _service.Execute(new MealQuery() { Mensa = 42, Date = DateTime.Now }, SuccessHandler, ErrorHandler);
    }

    private void ErrorHandler(Exception e)
    {
        Debug.WriteLine(e.ToString());
    }

    private void SuccessHandler(List<IMealCollection> meals)
    {
        Debug.WriteLine(meals.ToString());
    }

}

