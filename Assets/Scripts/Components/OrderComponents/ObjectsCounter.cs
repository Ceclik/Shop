using System.Collections.Generic;
using System.Linq;
using Components.CashRegisterComponents;
using UnityEngine;

namespace Components.OrderComponents
{
    public class ObjectsCounter : MonoBehaviour
    {
        [SerializeField] private OrderCreator orderCreator;
        private MoneyInteraction _moneyInteraction;
        private Dictionary<string, int> _order;
        private Dictionary<string, int> _items;
        //private bool _isOrderComplete;
        private List<GameObject> _objectsOnTable;

        public delegate void CompleteOrder();

        public event CompleteOrder OnOrderComplete;

        private void Start()
        {
            _moneyInteraction = GameObject.FindGameObjectWithTag("MoneyInteractionPart").GetComponent<MoneyInteraction>();
            
            orderCreator.OnOrderCreated += HandleEvent;
            _moneyInteraction.OnMoneyPutIntoCashRegister += DestroyAddedObjects;
            _objectsOnTable = new List<GameObject>();
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
                _objectsOnTable.Add(other.gameObject);
            }
            else return;

            if (_order.Count == _items.Count && !_order.Except(_items).Any())
            {
                Debug.Log("Order is complete!!!");
                //_isOrderComplete = true;
                OnOrderComplete?.Invoke();
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Food") && _items.ContainsKey(other.gameObject.name))
            {
                _items[other.gameObject.name]--;
                Debug.Log($"{other.gameObject.name} is not on table!");
                _objectsOnTable.Remove(other.gameObject);
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

        private void DestroyAddedObjects()
        {
            foreach (var item in _objectsOnTable)
                Destroy(item);
            _objectsOnTable.Clear();
        }

        private void OnDestroy()
        {
            orderCreator.OnOrderCreated -= HandleEvent;
            _moneyInteraction.OnMoneyPutIntoCashRegister -= DestroyAddedObjects;
        }
    }
}