using Components;
using UnityEngine;

namespace Interfaces
{
    public interface IObjectsThrower
    {
        public void ThrowObject(Transform objectTransform, Transform mainObjectsParent,
            ActionTextHandler actionTextHandler, ref bool isObjectPicked);
    }
}