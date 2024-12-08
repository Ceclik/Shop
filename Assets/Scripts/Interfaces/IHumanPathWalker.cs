using UnityEngine;

namespace Interfaces
{
    public interface IHumanPathWalker
    {
        public void GoForward(ref bool isPathComplete, Transform[] points, ref int currentPointIndex,
            float humanWalkSpeed, float humanRotationSpeed, Transform humanTransform, ref bool debugGoBack);
        public void GoBackward(ref bool isPathComplete, Transform[] points, ref int currentPointIndex,
            float humanWalkSpeed, float humanRotationSpeed, Transform humanTransform, ref bool debugGoBack);
    }
}