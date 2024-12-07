using System.Collections.Generic;
using Interfaces;
using Services;
using TMPro;
using UnityEngine;

namespace Components.OrderComponents
{
    public class OrderCreator : MonoBehaviour
    {
        [SerializeField] private int orderSize;
        [SerializeField] private int maxFoodAmount;
        [SerializeField] private TextMeshProUGUI orderText;

        [SerializeField] private bool isOrderCreated;
        
        public Dictionary<string, int> Order { get; private set; }

        private List<int> _usedNumbers;
        private IOrderCreator _orderCreator;

        public delegate void HandleOrder();

        public event HandleOrder OnOrderCreated;


        private void Start()
        {
            _usedNumbers = new List<int>(orderSize);
            _orderCreator = new CreatingOrderService();
        }

        private void Update()
        {
            if (isOrderCreated)
            {
                isOrderCreated = false;
                Order = _orderCreator.CreateOrder(orderSize, maxFoodAmount, _usedNumbers);
                OnOrderCreated?.Invoke();
                
                var orderText = "";

                foreach (var food in Order) orderText += $"{food.Key}: {food.Value}\n";

                this.orderText.text = orderText;
            }
        }
        
    }
}