using Interfaces;
using UnityEngine;

namespace Services.CharacterServices
{
    public class ObjectsFinderService : IObjectsFinder
    {
        public bool FindObject(Camera camera, float rayDistance, out Transform objectTransform)
        {
            var ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("Food"))
                {
                    objectTransform = hit.collider.transform;
                    return true;
                }

                objectTransform = null;
                return false;
            }

            objectTransform = null;
            return false;
        }
    }
}