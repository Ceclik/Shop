using UnityEngine;

namespace Components
{
    public class DoorsRotator : MonoBehaviour
    {
        [SerializeField] private float rotationDuration;
        public bool IsOpened { get; private set; }
        
        public bool IsOpening { get; private set; }
        private float _elapsedTime;

        private Quaternion _doorStartRotation;
        private Quaternion _doorEndRotation;


        private void Start()
        {
            _doorStartRotation = transform.rotation;
            _doorEndRotation = _doorStartRotation * Quaternion.Euler(0f, 120.0f, 0.0f);
        }

        public void RotateDoor()
        {
            _elapsedTime = 0f;
            IsOpening = true;
        }
        
        private void FixedUpdate()
        {
            if (IsOpening)
            {
                _elapsedTime += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(_doorStartRotation, _doorEndRotation,
                    _elapsedTime / rotationDuration);
                if (_elapsedTime >= rotationDuration)
                {
                    if (!IsOpened) IsOpened = true;
                    else IsOpened = false;
                    _doorEndRotation = _doorStartRotation;
                    _doorStartRotation = transform.rotation;
                
                    IsOpening = false;
                }
            }
        }

        
    }
}