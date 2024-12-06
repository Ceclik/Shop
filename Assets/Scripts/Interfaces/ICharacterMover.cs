using UnityEngine;

namespace Interfaces
{
    public interface ICharacterMover
    {
        public void Move(Rigidbody rigidbody, KeyCode key, float movingSpead);
    }
}