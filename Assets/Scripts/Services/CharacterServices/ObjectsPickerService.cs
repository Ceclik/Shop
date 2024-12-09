using Components;
using Components.CharacterComponents;
using Interfaces;
using UnityEngine;

namespace Services.CharacterServices
{
    public class ObjectsPickerService : IObjectsPicker
    {
        private readonly IObjectsFinder _objectsFinderService = new ObjectsFinderService();

        public void PickObject(Camera camera, float rayDistance, Transform objectTransform,
            ActionTextHandler actionTextHandler, ref bool isObjectPicked, Transform cameraTransform)
        {
            if (_objectsFinderService.FindObject(camera, rayDistance, out objectTransform))
            {
                if (!actionTextHandler.IsTextShown )
                    actionTextHandler.ShowActionText(isObjectPicked);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (objectTransform.CompareTag("Money") && objectTransform.GetComponent<Money>().IsInCashRegister)
                        return;
                    objectTransform.SetParent(cameraTransform);
                    objectTransform.GetComponent<Rigidbody>().isKinematic = true;
                    objectTransform.GetComponent<Collider>().isTrigger = true;
                    /*objectTransform.position = new Vector3(objectTransform.position.x, camera.transform.position.y,
                        objectTransform.position.z);*/
                    isObjectPicked = true;
                    actionTextHandler.ShowActionText(isObjectPicked);
                }
            }
        }
    }
}