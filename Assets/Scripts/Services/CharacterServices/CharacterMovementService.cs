using Interfaces;
using UnityEngine;

namespace Services.CharacterServices
{
    public class CharacterMovementService : ICharacterMover
    {
        public void Move(Rigidbody rigidbody, KeyCode key, float movingSpeed)
        {
            var movement = key switch
            {
                KeyCode.W => rigidbody.transform.forward * movingSpeed * Time.fixedDeltaTime,
                KeyCode.A => -rigidbody.transform.right * movingSpeed * Time.fixedDeltaTime,
                KeyCode.S => -rigidbody.transform.forward * movingSpeed * Time.fixedDeltaTime,
                KeyCode.D => rigidbody.transform.right * movingSpeed * Time.fixedDeltaTime,
                _ => Vector3.zero
            };

            rigidbody.MovePosition(rigidbody.position + movement);
        }
    }
}