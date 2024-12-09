using System.Collections.Generic;
using UnityEngine;

namespace Components.CashRegisterComponents
{
    public class MoneyInteraction : MonoBehaviour
    {
        public int MoneyAmount { get; private set; }
        private List<GameObject> _moneyInCashRegister;

        public delegate void HandleMoneyAfterCashRegister();
        public event HandleMoneyAfterCashRegister OnMoneyPutIntoCashRegister;
        
        private void Start()
        {
            _moneyInCashRegister = new List<GameObject>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Money"))
            {
                if (_moneyInCashRegister.Count >= 4)
                    _moneyInCashRegister.RemoveAt(0);
                
                other.transform.SetParent(transform);
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Money>().IsInCashRegister = true;
                MoneyAmount += 10;
                _moneyInCashRegister.Add(other.gameObject);
                OnMoneyPutIntoCashRegister?.Invoke();
            }
        }
    }
}