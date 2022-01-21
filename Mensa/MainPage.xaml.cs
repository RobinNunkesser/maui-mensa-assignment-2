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
        try
        {
            SuccessHandler(await _service.Execute(
                new MealQuery() { Mensa = 42, Date = DateTime.Now }));
        }
        catch (Exception ex)
        {
            ErrorHandler(ex);
        }
    }

    private void ErrorHandler(Exception ex)
    {
        Debug.WriteLine(ex.ToString());
    }

    private void SuccessHandler(List<IMealCollection> meals)
    {
        Debug.WriteLine(meals.ToString());
    }

}

