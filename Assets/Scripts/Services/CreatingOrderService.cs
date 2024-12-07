using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class CreatingOrderService : IOrderCreator
    {
        public Dictionary<string, int> CreateOrder(int orderSize, int maxFoodAmount, List<int> usedNumbers)
        {
            var order = new Dictionary<string, int>();

            for (var i = 0; i < orderSize; i++)
            {
                var foodName = "";
                var foodAmount = Random.Range(1, maxFoodAmount + 1);
                var foodNameCode = GenerateFoodCode(usedNumbers);

                switch (foodNameCode)
                {
                    case 1:
                        foodName = "Apple";
                        break;
                    case 2:
                        foodName = "Cheese";
                        break;
                    case 3:
                        foodName = "Beer";
                        break;
                    case 4:
                        foodName = "Jack";
                        break;
                }

                order.Add(foodName, foodAmount);
            }

            usedNumbers.Clear();
            return order;
        }
        
        private int GenerateFoodCode(List<int> usedNumbers)
        {
            var foodCode = 0;

            do
            {
                foodCode = Random.Range(1, 5);
            } while (usedNumbers.Contains(foodCode));

            usedNumbers.Add(foodCode);
            return foodCode;
        }
    }
}