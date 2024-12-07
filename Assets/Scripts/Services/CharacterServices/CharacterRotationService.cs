using Interfaces;
using UnityEngine;

namespace Services.CharacterServices
{
    public class CharacterRotationService : ICharacterRotator
    {
        public void Rotate(float mouseSensitivity, Rigidbody rigidbody, ref float verticalRotation,
            Transform cameraTransform)
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
            var deltaRotationY = Quaternion.Euler(0f, mouseX, 0f);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotationY);

            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;
            verticalRotation -= mouseY;

            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
}