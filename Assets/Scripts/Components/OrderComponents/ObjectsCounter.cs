using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Components.OrderComponents
{
    public class ObjectsCounter : MonoBehaviour
    {
        [SerializeField] private OrderCreator orderCreator;
        private Dictionary<string, int> _order;
        private Dictionary<string, int> _items;

        public delegate void CompleteOrder();

        public event CompleteOrder OnOrderComplete;

        private void Start()
        {
            orderCreator.OnOrderCreated += HandleEvent;
        }

        private void HandleEvent()
        {
            _order = orderCreator.Order;
            _items = new Dictionary<string, int>(orderCreator.Order);
            
            SetItemsCounterZero();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Food") && _items.ContainsKey(other.gameObject.name))
            {
                _items[other.gameObject.name]++;
                Debug.Log($"{other.gameObject.name} is on table!");
            }
            else return;

            if (_order.Count == _items.Count && !_order.Except(_items).Any())
            {
                Debug.Log("Order is complete!!!");
                OnOrderComplete?.Invoke();
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Food") && _items.ContainsKey(other.gameObject.name))
            {
                _items[other.gameObject.name]--;
                Debug.Log($"{other.gameObject.name} is not on table!");
            }
            else return;

            if (_order.Count == _items.Count && !_order.Except(_items).Any())
            {
                Debug.Log("Order is complete!!!");
                OnOrderComplete?.Invoke();
            }
        }

        private void SetItemsCounterZero()
        {
            List<string> keys = new List<string>(_items.Keys);
            foreach (var key in keys)
            {
                _items[key] = 0;
            }
        }

        private void OnDestroy()
        {
            orderCreator.OnOrderCreated -= HandleEvent;
        }
    }
}