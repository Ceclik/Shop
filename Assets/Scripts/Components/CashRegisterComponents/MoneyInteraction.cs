using UnityEngine;

namespace Components.CashRegisterComponents
{
    public class MoneyInteraction : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Money"))
            {
                other.transform.SetParent(transform);
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Money>().IsInCashRegister = true;
                Debug.Log("Money has fallen");
            }
        }
    }
}