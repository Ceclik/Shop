﻿using Components;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class ObjectsThrowerService : IObjectsThrower
    {
        public void ThrowObject(Transform objectTransform, Transform mainObjectsParent,
            ActionTextHandler actionTextHandler, ref bool isObjectPicked)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                objectTransform.SetParent(mainObjectsParent);
                objectTransform.GetComponent<Rigidbody>().isKinematic = false;
                objectTransform = null;
                actionTextHandler.HideActionText();
                isObjectPicked = false;
            }
        }
    }
}