using System.Collections.Generic;
using UnityEngine;

namespace Components.CashRegisterComponents
{
    public class MoneyInteraction : MonoBehaviour
    {

        [SerializeField] private int amountOfMoneyToRestore;
        public int MoneyAmount { get; private set; }
        private List<GameObject> _moneyInCashRegister;
        private ObjectsSpawner _objectsSpawner;

        public delegate void HandleMoneyAfterCashRegister();
        public event HandleMoneyAfterCashRegister OnMoneyPutIntoCashRegister;
        
        private void Start()
        {
            _moneyInCashRegister = new List<GameObject>();
            _objectsSpawner = GameObject.FindGameObjectWithTag("ObjectsManager").GetComponent<ObjectsSpawner>();
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
                MoneyAmount += 100;
                _moneyInCashRegister.Add(other.gameObject);
                OnMoneyPutIntoCashRegister?.Invoke();

                if (MoneyAmount >= amountOfMoneyToRestore)
                {
                    for (int i = 0; i < _moneyInCashRegister.Count; i++)
                    {
                        Destroy(_moneyInCashRegister[i]);
                        _moneyInCashRegister[i] = null;
                    }
                    _moneyInCashRegister.Clear();
                    _objectsSpawner.RespawnObjects();
                    Debug.Log("Money in cash register destroyed\nProducts has been restored");
                }
            }
        }
    }
}