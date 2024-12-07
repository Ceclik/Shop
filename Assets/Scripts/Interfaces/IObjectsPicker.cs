using Components;
using UnityEngine;

namespace Interfaces
{
    public interface IObjectsPicker
    {
        public void PickObject(Camera camera, float rayDistance, Transform objectTransform,
            ActionTextHandler actionTextHandler, ref bool isObjectPicked, Transform cameraTransform);
    }
}