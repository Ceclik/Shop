using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components.OrderComponents
{
    internal enum Food
    {
        Apple,
        Cheese,
        Beer,
        Jack
    }

    public class OrderCreator : MonoBehaviour
    {
        [SerializeField] private int orderSize;
        [SerializeField] private int maxFoodAmount;
        [SerializeField] private TextMeshProUGUI orderText;

        [SerializeField] private bool isOrderCreated;

        private List<int> _usedNumbers;


        private void Start()
        {
            _usedNumbers = new List<int>(orderSize);
        }

        private void Update()
        {
            if (isOrderCreated)
            {
                isOrderCreated = false;
                var order = CreateOrder();
                var orderText = "";

                foreach (var food in order) orderText += $"{food.Key}: {food.Value}\n";

                this.orderText.text = orderText;
            }
        }

        private Dictionary<string, int> CreateOrder()
        {
            var order = new Dictionary<string, int>();

            for (var i = 0; i < orderSize; i++)
            {
                var foodName = "";
                var foodAmount = Random.Range(1, maxFoodAmount + 1);
                var foodNameCode = GenerateFoodCode();

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

            _usedNumbers.Clear();
            return order;
        }

        private int GenerateFoodCode()
        {
            var foodCode = 0;

            do
            {
                foodCode = Random.Range(1, 5);
            } while (_usedNumbers.Contains(foodCode));

            _usedNumbers.Add(foodCode);
            Debug.Log($"Used numbers: {_usedNumbers}");
            return foodCode;
        }
    }
}