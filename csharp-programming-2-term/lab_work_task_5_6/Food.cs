using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_task_5_6
{
    public class Food
    {
        private DateTime putDate;

        static private int currentFreeId = 1;

        public enum FoodHeat
        {
            None,
            Cold,
            Warm,
            Hot
        }

        public string PutDate
        {
            get
            {
                return putDate.ToString();
            }
            set
            {
                putDate = DateTime.Parse(value);
            }
        }
        
        public int Id { get; set; }
        public string Name { get; set; }

        public double Сarbohydrates { get; set; }

        public double Fats { get; set; }

        public double Proteins { get; set; }

        public double Weight { get; set; }

        public FoodHeat foodHeatStatus = new FoodHeat();

        public Food(string name, double weight)
        {
            Id = currentFreeId++;
            Name = name;
            Weight = weight;
        }

        public Food(string name, double weight, double carbohydrates, double fats, double proteins)
        {
            Id = currentFreeId++;
            Name = name;
            Weight = weight;
            Сarbohydrates = carbohydrates;
            Fats = fats;
            Proteins = proteins;
            foodHeatStatus = FoodHeat.None;
            
        }

        public Food(string name, double weight, double carbohydrates, double fats, double proteins, string datePut, FoodHeat foodHeat) :
                this(name, weight, carbohydrates, fats, proteins)
        {
            PutDate = datePut;
            foodHeatStatus = foodHeat;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            int lenTable = 32 + Name.Length;
            result.AppendLine("".PadRight(lenTable, '-'));
            result.AppendLine(String.Format("|-Description-|-{0}-|-Description-|", Name));
            result.AppendLine("".PadRight(lenTable, '-'));
            result.AppendLine("|" + String.Format("|->Id: {0} |", Id).PadRight(lenTable - 1, '='));
            if (putDate != DateTime.MinValue) result.AppendLine("|" + String.Format("|->Date: {0} |", PutDate).PadRight(lenTable - 1, '='));
            if (foodHeatStatus != FoodHeat.None) result.AppendLine("|" + String.Format("|->Food Heat: {0} |", foodHeatStatus.ToString()).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Сarbohydrates: {0:f} |", Сarbohydrates).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Fats: {0:f} |", Fats).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Proteins: {0:f} |", Proteins).PadRight(lenTable - 1, '='));
            result.AppendLine("|" + String.Format("|->Weight: {0:f} |", Weight).PadRight(lenTable - 1, '='));
            result.AppendLine("".PadRight(lenTable, '-'));
            return result.ToString();

        }


        public void MakeLongHeat()
        {
            foodHeatStatus = FoodHeat.Hot;
        }

        public void MakeLittleHeat()
        {
            if (foodHeatStatus != FoodHeat.Hot) foodHeatStatus = FoodHeat.Warm;
        }

        public void MakeEasyCooling()
        {
            switch (foodHeatStatus)
            {   
                case FoodHeat.Hot:
                    foodHeatStatus = FoodHeat.Warm;
                    break;
                default:
                    foodHeatStatus = FoodHeat.Cold;
                    break;
            }
        }

        public void MakeHardCooling()
        {
            foodHeatStatus = FoodHeat.Cold;
        }

        public int GetTimeHoldInDays(DateTime potentialDate)
        {
            if (potentialDate > putDate) return -1;

            TimeSpan span = putDate.Subtract(potentialDate);

            return span.Days;
        }   

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }
    }
}
