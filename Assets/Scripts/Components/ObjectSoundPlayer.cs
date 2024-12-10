using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AudioSource))]
    public class ObjectSoundPlayer : MonoBehaviour
    {
        private AudioSource _source;
        private int _collisionCounter;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_collisionCounter > 0 &&
                (other.gameObject.CompareTag("ObjectsCounter") || other.gameObject.CompareTag("Floor")))
                _source.Play();
            _collisionCounter++;
        }
    }
}