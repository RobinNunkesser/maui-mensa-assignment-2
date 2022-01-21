using System;
using Italbytz.Ports.Meal;

namespace Mensa
{
    public class MealQuery : IMealQuery
    {
        public MealQuery()
        {
        }

        public int Mensa { get; set; }
        public DateTime Date { get; set; }
    }
}

