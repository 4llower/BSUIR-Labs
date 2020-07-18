using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lab_work_task_5_6
{
    class Program
    {
        static List<Food> foodStorage;
        static void Main(string[] args)
        {
            foodStorage = new List<Food>();

            foodStorage.Add(new Food("Egg", 100, 0.4, 11, 13, DateTime.Now.ToString("dd/MM/yyyy"), Food.FoodHeat.Cold));
            foodStorage.Add(new Food("Chicken meat", 100, 0, 14, 27));

            var pepperoni = new Pizza("Pepperoni", 6, Pizza.TypePizza.Round, 99, 500);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Sausage);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            foodStorage.Add(pepperoni);

            var margarita = new Pizza("Margarita", 8, Pizza.TypePizza.Round, 44, 800);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Mayonnaise);
            foodStorage.Add(margarita);

            var bigMac = new Burger("BIG-MAC", 2, 3, 300, 200);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Sausage);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            foodStorage.Add(bigMac);

            var vopper = new Burger("vopper", 4, 5, 100, 300);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Cheese);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            pepperoni.AddExtraIngridient(FastFood.AdditionalIngredients.Ketchup);
            foodStorage.Add(vopper);

            while (true)
            {
                Info();
                switch (GetChoice(1, 9))
                {
                    case 1:
                        foodStorage.Add(GetFoodShort());
                        break;
                    case 2:
                        foodStorage.Add(GetFoodLong());
                        break;
                    case 3:
                        ShowAll();
                        break;
                    case 4:
                        FindAndDelete();
                        break;
                    case 5:
                        FindAndEdit();
                        break;
                    case 6:
                        SetDateAndCheck();
                        break;
                    case 7:
                        FindAndChangeHeat();
                        break;
                    case 8:
                        MakePizzaAndBurgerSelection(foodStorage.Where(food => food is ICalories).Select(food => food as ICalories));
                        break;
                    default:
                        return;
                }
            }
        }
        static void Info()
        {
            Console.WriteLine("Enter number(1-8): ");
            Console.WriteLine("1. Add a food item (Short)");
            Console.WriteLine("2. Add a food item (Long)");
            Console.WriteLine("3. Print all information about food items in storage");
            Console.WriteLine("4. Delete food item by Id");
            Console.WriteLine("5. Change food item");
            Console.WriteLine("6. Set date and check how many days");
            Console.WriteLine("7. Make heat or cooling for food item");
            Console.WriteLine("8. Find burgers ans pizza, then sort by Calorie Absorption Time");
            Console.WriteLine("9. Exit");
        }

        static void MakePizzaAndBurgerSelection(IEnumerable<ICalories> pizzaAndBurgers)
        {
            List<ICalories> food = pizzaAndBurgers.ToList();
            food.Sort();
            foreach (var item in food)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Name of food: " + item.Name.ToString());
                Console.WriteLine("Time in sec absortion: " + item.getCalorieAbsorptionTime().ToString());
                Console.WriteLine("Calories per one item: " + item.getCaloriesValue().ToString());
                Console.WriteLine("Price: " + item.Price.ToString());
                Console.WriteLine("Order is : " + item.NumberOrder.ToString());
                Console.WriteLine("----------------------");
            }
        }

        static void FindAndChangeHeat()
        {
            Console.Write("Insert Id which match to your item, or enter enter id which is not exists: ");
            int id = GetInt();

            if (foodStorage.Any(item => item.Id == id) == false)
            {
                Console.WriteLine("This id is not exists");
                return;
            }

            Console.Write("Enter what your want: \n"
                          + "1. Make short heat\n"
                          + "2. Make long heat\n"
                          + "3. Make short cooling\n"
                          + "4. Make hard cooling\n"
                          + "5. Nothing to do\n");

            int answer = GetChoice(1, 4);
            Food refFood = null;

            foreach (var item in foodStorage)
            {
                if (item.Id == id)
                {
                    refFood = item;
                    break;
                }
            }

            switch (answer)
            {
                case 1:
                    refFood.MakeLittleHeat();
                    break;
                case 2:
                    refFood.MakeLongHeat();
                    break;
                case 3:
                    refFood.MakeEasyCooling();
                    break;
                case 4:
                    refFood.MakeHardCooling();
                    break;
            }
        }

        static int GetChoice(int left, int right)
        {
            int result;

            while (true)
            {
                string data = Console.ReadLine();
                if (int.TryParse(data, out result) == false || result < left || result > right)
                {
                    Console.Write("Please enter int value from " + left.ToString() + " to " + right.ToString() + ": ");
                    continue;
                }
                return result;
            }
        }
        static DateTime GetDate()
        {
            DateTime date;

            CultureInfo provider = CultureInfo.InvariantCulture;

            Console.Write("Enter the date in format(dd/MM/yyyy): ");
            while (true)
            {
                string data = Console.ReadLine();

                if (DateTime.TryParseExact(data, "dd/MM/yyyy", provider, DateTimeStyles.None, out date) == false)
                {
                    Console.Write("Enter the correct date(dd/MM/yyyy): ");
                    continue;
                }

                return date;
            }
        }

        static void FindAndDelete()
        {
            Console.Write("Insert Id which match to your item, or enter enter id which is not exists: ");
            int id = GetInt();

            if (foodStorage.Any(item => item.Id == id) == false)
            {
                Console.WriteLine("This id is not exists");
                return;
            }

            foodStorage.RemoveAll(item => item.Id == id);

            Console.WriteLine("This item was successfully deleted");
        }

        static void FindAndEdit()
        {
            Console.Write("Insert Id which match to your item, or enter enter id which is not exists: ");
            int id = GetInt();

            if (foodStorage.Any(item => item.Id == id) == false)
            {
                Console.WriteLine("This id is not exists");
                return;
            }

            for (int i = 0; i < foodStorage.Count; ++i)
            {
                var item = foodStorage[i];
                if (item.Id == id)
                {
                    item = GetFoodLong();
                    break;
                }
            }
        }

        static void SetDateAndCheck()
        {
            DateTime inputDate = GetDate();
            foreach (var item in foodStorage)
            {
                item.PrintInfo();
                Console.WriteLine("Holding in food storage about " + 
                    (item.GetTimeHoldInDays(inputDate) == -1 ? "Unknown" : item.GetTimeHoldInDays(inputDate).ToString()));

            }
        }

        static Food GetFoodShort()
        {
            string name;
            double carbohydrates;
            double fats;
            double proteins;
            double weight;

            Console.Write("Enter the name of food: ");
            name = Console.ReadLine();

            Console.Write("Enter the weight: ");
            weight = GetDouble();

            Console.Write("Enter the carbohydrates: ");
            carbohydrates = GetDouble();

            Console.Write("Enter the fats: ");
            fats = GetDouble();

            Console.Write("Enter the proteins: ");
            proteins = GetDouble();

            return new Food(name, weight, carbohydrates, fats, proteins);              
        }

        static Food GetFoodLong()
        {
            Food primaryData = GetFoodShort();

            Food.FoodHeat foodHeat = Food.FoodHeat.None;

            string putDate = GetDate().ToString();

            return new Food(primaryData.Name, primaryData.Weight, primaryData.Сarbohydrates, primaryData.Fats, primaryData.Proteins, putDate, foodHeat);
        }

        static double GetDouble(string errorMessage = "Please enter the correct double value: ")
        {
            double result;
            while (true)
            {
                string data = Console.ReadLine();
                data.Replace('.', ',');
                if (double.TryParse(data, out result) == false)
                {
                    Console.Write(errorMessage);
                    continue;
                }
                return result;
            }
        }

        static int GetInt(string errorMessage = "Please enter the correct int value: ")
        {
            int result;
            while (true)
            {
                string data = Console.ReadLine();
                if (int.TryParse(data, out result) == false)
                {
                    Console.Write(errorMessage);
                    continue;
                }
                return result;
            }
        }
        
        static void ShowAll()
        {
            foreach (var item in foodStorage)
            {
                item.PrintInfo();
            }
        }
    }
}
