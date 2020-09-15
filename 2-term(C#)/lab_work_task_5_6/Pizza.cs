using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_5_6
{
    public class Pizza : FastFood, ICalories
    {

        public int NumberSlices { get; set; }

        public TypePizza PizzaType { get; set; }

        public enum TypePizza
        {
            Square,
            Round
        }

        public Pizza(string name, int numberSlices, TypePizza typePizza, int price, double weight) : base(name, weight, price)
        {
            PizzaType = typePizza;
            NumberSlices = numberSlices;
        }

        public Pizza(string name, double weight, double carbohydrates, double fats, double proteins, int price, int numberSlices, TypePizza typePizza) :
            base(name, weight, carbohydrates, fats, proteins, price)
        {
            PizzaType = typePizza;
            NumberSlices = numberSlices;
        }

        public Pizza(string name, double weight, double carbohydrates, double fats, double proteins, string datePut, FoodHeat foodHeat, int price, int numberSlices, TypePizza typePizza) :
            base(name, weight, carbohydrates, fats, proteins, datePut, foodHeat, price)
        {
            PizzaType = typePizza;
            NumberSlices = numberSlices;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            int lenTable = 32 + Name.Length;
            result.AppendLine("|" + String.Format("|->Number of Slices: {0} |", NumberSlices).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Type of Pizza: {0} |", PizzaType.ToString()).PadRight(lenTable - 1, '='));
            result.AppendLine("".PadRight(lenTable, '-'));
            return result.ToString();
        }

        public double getCalorieAbsorptionTime()
        {
            double DailyRate = 2000;
            double OneDayInSec = 86400;
            foreach (var item in additionals)
            {
                if (item == AdditionalIngredients.Mayonnaise) DailyRate -= 20;
                if (item == AdditionalIngredients.Сutlet) DailyRate -= 30;
            }
            return OneDayInSec * ((getCaloriesValue() - 10 * NumberSlices) / DailyRate);
        }

        public double getCaloriesValue()
        {
            // every pizza has a dough
            IngridientsInfo.Ingridient dough = IngridientsInfo.GetInfoAbout("Dough");
            double result = dough.carbohydrates * 4 + dough.fats * 4 + dough.carbohydrates * 9;
            result *= Weight / 100;

            foreach (AdditionalIngredients item in additionals)
            {
                IngridientsInfo.Ingridient temp = IngridientsInfo.GetInfoAbout(item.ToString());
                result += temp.carbohydrates * 4 + temp.fats * 4 + temp.carbohydrates * 9;
            }

            return result;
        }

        public int CompareTo(ICalories food)
        {
            double timeThis = this.getCalorieAbsorptionTime();
            double timeAnother = food.getCalorieAbsorptionTime();
            if (timeThis == timeAnother) return 0;
            return (timeThis > timeAnother ? 1 : -1);
        }

    }
}
