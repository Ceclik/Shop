using UnityEngine;

namespace Interfaces
{
    public interface IObjectsFinder
    {
        public bool FindObject(Camera camera, float rayDistance, out Transform objectTransform);
    }
}