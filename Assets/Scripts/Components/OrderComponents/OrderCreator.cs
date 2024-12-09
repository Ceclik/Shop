using System;
using System.Collections.Generic;
using Components.HumanComponents;
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

        private bool _isOrderCreated;
        
        public Dictionary<string, int> Order { get; private set; }

        private List<int> _usedNumbers;
        private IOrderCreator _orderCreator;
        private HumanPathWalker _humanPathWalker;

        public delegate void HandleOrder();

        public event HandleOrder OnOrderCreated;


        private void Start()
        {
            _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
            _humanPathWalker.OnHumanGoAway += CreateNewOrder;
            _usedNumbers = new List<int>(orderSize);
            _orderCreator = new CreatingOrderService();
            _isOrderCreated = true;
        }

        private void Update()
        {
            if (_isOrderCreated)
            {
                CreateNewOrder();
            }
        }


        private void CreateNewOrder()
        {
            _isOrderCreated = false;
            Order = null;
            Order = _orderCreator.CreateOrder(orderSize, maxFoodAmount, _usedNumbers);
            OnOrderCreated?.Invoke();
                
            var orderText = "";

            foreach (var food in Order) orderText += $"{food.Key}: {food.Value}\n";

            this.orderText.text = orderText;
        }

        private void OnDestroy()
        {
            _humanPathWalker.OnHumanGoAway -= CreateNewOrder;
        }
    }
}