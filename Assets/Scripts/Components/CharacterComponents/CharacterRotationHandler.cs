using Interfaces;
using Services.CharacterServices;
using UnityEngine;

namespace Components.CharacterComponents
{
    public class CharacterRotationHandler : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform cameraTransform;
        private ICharacterRotator _characterRotator;

        private Rigidbody _rigidbody;
        private float _verticalRotation;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
            _characterRotator = new CharacterRotationService();
        }

        private void Update()
        {
            _characterRotator.Rotate(mouseSensitivity, _rigidbody, ref _verticalRotation, cameraTransform);
        }
    }
}