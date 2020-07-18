using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_8
{
    public class Party
    {
        public delegate void PartyInformation(string message);

        public event PartyInformation PartyEvent;

        enum TypeParty
        {
            PizzaParty,
            BurgerParty
        }

        TypeParty PartyStatus;

        public bool Started { get; set; }

        public int PartyMood { get; set; }

        public int NumberPeople { get; set; }

        public int Budget { get; set; }

        public int PurchasedFood { get; set; }

        public Party(int numberPeople, int budget)
        {
            if (numberPeople <= 0)
            {
                throw new ArgumentException("Party can't be without people:(");
            }

            if (budget <= 0)
            {
                throw new ArgumentException("Budget can't be non-positive.");
            }
            
            NumberPeople = numberPeople;
            Random rand = new Random();
            Budget = budget;

            if (rand.Next(1, 2) == 1)
            {
                PartyStatus = TypeParty.BurgerParty;
            }
            else
            {
                PartyStatus = TypeParty.PizzaParty;
            }

            PartyEvent += PartyHandler;
        }

        public void tryToBuyFood(Food food)
        {
            if (Started == true) return;
            if (food is Pizza)
            {
                Pizza pizza = food as Pizza;
                if (pizza.Price <= Budget)
                {
                    PartyEvent?.Invoke("Successfully buying");
                    pizza.AddMessageToEvent("Successfully buying");
                    
                    if (PartyStatus == TypeParty.PizzaParty)
                    {
                        PartyMood += 10;
                    }
                    else
                    {
                        PartyMood -= 5;
                    }
                    Budget -= pizza.Price;
                } 
                else
                { 
                    pizza.AddMessageToEvent("Unsuccesfully buying:(");
                    PartyEvent?.Invoke("Unsuccesfully buying:(");
                }
            }
            else
            {
                if (((Burger)food).Price <= Budget)
                {
                    PartyEvent?.Invoke("Successfully buying burger");    
                    if (PartyStatus == TypeParty.BurgerParty)
                    {
                        PartyMood += 10;
                    }
                    else
                    {
                        PartyMood -= 5;
                    }                 
                    Budget -= ((Burger)food).Price;
                }
                else
                {
                    PartyEvent?.Invoke("Unsuccesfully buying burger:(");
                }
            }
        }

        void PartyHandler(string message)
        {
            if (message == "Not enough food")
            {
                Console.WriteLine("Party was not created:(");
                return;
            }
            
            if (message == "Successfully buying")
            {
                PurchasedFood++;
            } 
            else
            {
                if (message != "Unsuccesfully buying:(")
                {
                    Console.WriteLine(message);
                }
            }

            if (PurchasedFood == NumberPeople)
            {
                Started = true;
                Console.WriteLine("Good! Party was created with mood value: " + PartyMood.ToString());
            }
        }
    }
}
