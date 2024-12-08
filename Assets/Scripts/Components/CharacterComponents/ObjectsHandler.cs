using Components.CashRegisterComponents;
using Interfaces;
using Services.CharacterServices;
using UnityEngine;

namespace Components.CharacterComponents
{
    [RequireComponent(typeof(ActionTextHandler), typeof(CashRegisterInteractor))]
    public class ObjectsHandler : MonoBehaviour
    {
        [SerializeField] private float rayDistance;
        [SerializeField] private Transform mainObjectsParent;
        private ActionTextHandler _actionTextHandler;

        private Camera _camera;

        private bool _isObjectPicked;
        private IObjectsFinder _objectsFinder;
        private IObjectsPicker _objectsPicker;
        private IObjectsThrower _objectsThrower;
        private CashRegisterInteractor _cashRegisterInteractor;
        private Transform _objectTransform;

        private void Start()
        {
            _objectsFinder = new ObjectsFinderService();
            _objectsPicker = new ObjectsPickerService();
            _objectsThrower = new ObjectsThrowerService();
            _camera = Camera.main;
            _actionTextHandler = GetComponent<ActionTextHandler>();
            _cashRegisterInteractor = GetComponent<CashRegisterInteractor>();
        }

        private void Update()
        {
            if (!_isObjectPicked && !_objectsFinder.FindObject(_camera, rayDistance, out _objectTransform))
                _actionTextHandler.HideActionText();

            if (!_isObjectPicked && _objectTransform != null && _objectTransform.gameObject.CompareTag("CashRegister"))
            {
                _cashRegisterInteractor.Interact();
            }

            if (!_isObjectPicked && _objectTransform != null && (_objectTransform.gameObject.CompareTag("Food") ||
                                                                 _objectTransform.gameObject.CompareTag("Money")))
            {
                _objectsPicker.PickObject(_camera, rayDistance, _objectTransform, _actionTextHandler,
                    ref _isObjectPicked, _camera.transform);
            }
            else if (_isObjectPicked)
            {
                //Debug.Log(_objectTransform);
                _objectsThrower.ThrowObject(_objectTransform, mainObjectsParent, _actionTextHandler,
                    ref _isObjectPicked);
            }
        }
    }
}