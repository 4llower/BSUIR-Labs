using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_5_6
{
    abstract public class FastFood : Food
    {
        public int Price { get; set; }
        public int NumberOrder { get; set; }
        static int CurrentFreeNumberOrder { get; set; }

        public List<AdditionalIngredients> additionals = new List<AdditionalIngredients>();

        public enum AdditionalIngredients
        {
            Cheese, 
            Sausage,
            Сutlet,
            Ketchup,
            Mayonnaise
        }

        public FastFood(string name, double weight, int price) : base(name, weight)
        {
            Price = price;
            NumberOrder = CurrentFreeNumberOrder;
            CurrentFreeNumberOrder++;
        }

        public FastFood(string name, double weight, double carbohydrates, double fats, double proteins, int price): 
            base(name, weight, carbohydrates, fats, proteins)
        {
            Price = price;
            NumberOrder = CurrentFreeNumberOrder;
            CurrentFreeNumberOrder++;
        }

        public FastFood(string name, double weight, double carbohydrates, double fats, double proteins, string datePut, FoodHeat foodHeat, int price):
             base(name, weight, carbohydrates, fats, proteins, datePut, foodHeat)
        {
            Price = price;
            NumberOrder = CurrentFreeNumberOrder;
            CurrentFreeNumberOrder++;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            int lenTable = 32 + Name.Length;
            result.AppendLine("|" + String.Format("|->Price: {0} |", Price).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Order number №: {0} |", NumberOrder).PadRight(lenTable - 1, '='));
            result.AppendLine("".PadRight(lenTable, '-'));
            result.AppendLine("|" + String.Format("|->ExtraIngridients|").PadRight(lenTable - 1, '='));
            foreach (var additional in additionals)
            {
                result.AppendLine("|" + String.Format("|->{0}|", additional.ToString()).PadRight(lenTable - 1, '='));
            }
            result.AppendLine("".PadRight(lenTable, '-'));
            return result.ToString();
        }

        public void AddExtraIngridient(AdditionalIngredients additional)
        {
            additionals.Add(additional);
        }
    }
}
