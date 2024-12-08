using Interfaces;
using UnityEngine;

namespace Services.HumanServices
{
    public class HumanPathWalkerService : IHumanPathWalker

    {
        public void GoForward(ref bool isPathComplete, Transform[] points, ref int currentPointIndex,
            float humanWalkSpeed, float humanRotationSpeed, Transform humanTransform, ref bool debugGoBack)
        {
            if (!isPathComplete)
            {
                Vector3 targetPosition = points[currentPointIndex].position;
                Vector3 direction = targetPosition - humanTransform.position;

                humanTransform.position = Vector3.MoveTowards(humanTransform.position, targetPosition,
                    humanWalkSpeed * Time.deltaTime);

                if (direction.sqrMagnitude > 0.01f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180, 0);
                    humanTransform.rotation = Quaternion.Slerp(humanTransform.rotation, targetRotation,
                        Time.deltaTime * humanRotationSpeed);
                }

                if (Vector3.Distance(humanTransform.position, targetPosition) < 0.1f)
                {
                    currentPointIndex++;
                    Debug.Log($"Current point index: {currentPointIndex}");
                }

                if (currentPointIndex == points.Length)
                {
                    Debug.Log("Path complete!!!");
                    isPathComplete = true;
                }
            }
        }

        public void GoBackward(ref bool isPathComplete, Transform[] points, ref int currentPointIndex,
            float humanWalkSpeed, float humanRotationSpeed, Transform humanTransform, ref bool debugGoBack)
        {
            if (!isPathComplete)
            {
                Vector3 targetPosition = points[currentPointIndex].position;
                Vector3 direction = targetPosition - humanTransform.position;

                humanTransform.position = Vector3.MoveTowards(humanTransform.position, targetPosition,
                    humanWalkSpeed * Time.deltaTime);

                if (direction.sqrMagnitude > 0.01f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180, 0);
                    humanTransform.rotation = Quaternion.Slerp(humanTransform.rotation, targetRotation,
                        Time.deltaTime * humanRotationSpeed);
                }

                if (Vector3.Distance(humanTransform.position, targetPosition) < 0.1f)
                {
                    currentPointIndex--;
                    Debug.Log($"Current point index: {currentPointIndex}");
                }

                if (currentPointIndex == -1)
                {
                    Debug.Log("Path complete!!!");
                    isPathComplete = true;
                }
            }
        }
    }
}
