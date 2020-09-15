using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_5_6
{
    static public class IngridientsInfo
    {
        public struct Ingridient
        {
            public double carbohydrates;
            public double fats;
            public double proteins;
            public double weight;
        }

        public static Ingridient GetInfoAbout(string ingridientName)
        {
            Ingridient result = new Ingridient();

            switch (ingridientName)
            {
                case "Cheese":
                    result.weight = 20;
                    result.proteins = 4.66;
                    result.fats = 5.744;
                    result.carbohydrates = 0.138;
                    break;
                case "Sausage":
                    result.weight = 100;
                    result.proteins = 11;
                    result.fats = 23.9;
                    result.carbohydrates = 0.4;
                    break;
                case "Сutlet":
                    result.weight = 100;
                    result.proteins = 5.5;
                    result.fats = 12.4;
                    result.carbohydrates = 0.2;
                    break;
                case "Ketchup":
                    result.weight = 20;
                    result.proteins = 0.36;
                    result.fats = 0.2;
                    result.carbohydrates = 0.42;
                    break;
                case "Mayonnaise":
                    result.weight = 20;
                    result.proteins = 0.56;
                    result.fats = 13.4;
                    result.carbohydrates = 0.72;
                    break;
                case "Dough":
                    result.weight = 100;
                    result.proteins = 5.8;
                    result.fats = 6.4;
                    result.carbohydrates = 49.2;
                    break;
                case "Bread":
                    result.weight = 100;
                    result.proteins = 8.85;
                    result.fats = 3.33;
                    result.carbohydrates = 49.72;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
