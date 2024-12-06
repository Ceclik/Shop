using UnityEngine;

namespace Interfaces
{
    public interface ICharacterRotator
    {
        public void Rotate(float mouseSensitivity, Rigidbody rigidbody, ref float verticalRotation,
            Transform cameraTransform);
    }
}