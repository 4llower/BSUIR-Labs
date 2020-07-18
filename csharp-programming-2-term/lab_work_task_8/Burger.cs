using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_8
{
    public class Burger : FastFood, ICalories
    {
        public int NumberСutlet { get; set; }
        
        public int NumberBreads { get; set; }

        public Burger(string name, int numberСutlet, int numberBreads, int price, double weight): base(name, weight, price)
        {
            NumberСutlet = numberСutlet;
            NumberBreads = numberBreads;
        }

        public Burger(string name, double weight, double carbohydrates, double fats, double proteins, int price, int numberСutlet, int numberBreads):
            base(name, weight, carbohydrates, fats, proteins, price)
        {
            NumberСutlet = numberСutlet;
            NumberBreads = numberBreads;
        }

        public Burger(string name, double weight, double carbohydrates, double fats, double proteins, string datePut, FoodHeat foodHeat, int price, int numberСutlet, int numberBreads):
            base(name, weight, carbohydrates, fats, proteins, datePut, foodHeat, price)
        {
            NumberСutlet = numberСutlet;
            NumberBreads = numberBreads;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            int lenTable = 32 + Name.Length;
            result.AppendLine("|" + String.Format("|->Number of cutlets: {0} |", NumberСutlet).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Number of breads: {0} |", NumberBreads).PadRight(lenTable - 1, '='));
            result.AppendLine("".PadRight(lenTable, '-'));
            return result.ToString();
        }

        public double getCalorieAbsorptionTime()
        {
            double DailyRate = 2000;
            double OneDayInSec = 86400;

            foreach (var item in additionals)
            {
                if (item == AdditionalIngredients.Mayonnaise) DailyRate -= 13;
                if (item == AdditionalIngredients.Сutlet) DailyRate -= 22;
                if (item == AdditionalIngredients.Cheese) DailyRate -= 28;
                if (item == AdditionalIngredients.Ketchup) DailyRate -= 44;
            }

            return OneDayInSec * ((getCaloriesValue()) / DailyRate);
        }

        public double getCaloriesValue()
        {
            IngridientsInfo.Ingridient bread = IngridientsInfo.GetInfoAbout("Bread");
            double result = bread.carbohydrates * 4 + bread.fats * 4 + bread.carbohydrates * 9;
            result *= NumberBreads;

            IngridientsInfo.Ingridient cutlet = IngridientsInfo.GetInfoAbout("Сutlet");
            result += (cutlet.carbohydrates * 4 + cutlet.fats * 4 + cutlet.carbohydrates * 9) * NumberСutlet;

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
