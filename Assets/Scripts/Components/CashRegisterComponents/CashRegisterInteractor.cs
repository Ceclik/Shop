using Components.CharacterComponents;
using UnityEngine;

namespace Components.CashRegisterComponents
{
    [RequireComponent(typeof(ActionTextHandler))]
    public class CashRegisterInteractor : MonoBehaviour
    {
        [SerializeField] private float openingSpeed;
        [SerializeField] private Transform openingPart;
        [SerializeField] private Transform openedPoint;
        [SerializeField] private Transform closedPoint;
        
        private ActionTextHandler _actionTextHandler;
        private bool _isOpened;
        private bool _isMoving;

        private void Start()
        {
            _actionTextHandler = GetComponent<ActionTextHandler>();
        }

        private void FixedUpdate()
        {
            if (_isMoving && !_isOpened)
            {
                openingPart.position =
                    Vector3.MoveTowards(openingPart.position, openedPoint.position, 
                        openingSpeed * Time.deltaTime);
                if (Vector3.Distance(openingPart.position, openedPoint.position) <= 0.1f)
                {
                    _isMoving = false;
                    _isOpened = true;
                }
            }
            else if (_isMoving && _isOpened)
            {
                openingPart.position =
                    Vector3.MoveTowards(openingPart.position, closedPoint.position, 
                        openingSpeed * Time.deltaTime);
                if (Vector3.Distance(openingPart.position, closedPoint.position) <= 0.1f)
                {
                    _isMoving = false;
                    _isOpened = false;
                }
            }
            
        }

        public void Interact()
        {
            if (!_isMoving)
            {
                _actionTextHandler.ShowCashRegisterText(_isOpened);
                if (Input.GetKeyDown(KeyCode.F))
                    _isMoving = true;
            }
        }
    }
}