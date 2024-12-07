using Interfaces;
using TMPro;

namespace Services
{
    public class ActionTextHandlingService : IActionTextHandler

    {
        public void HandleActionText(TextMeshProUGUI actionText, bool isObjectPicked)
        {
            if (isObjectPicked)
            {
                actionText.text = "Press 'F' to throw object";
                actionText.gameObject.SetActive(true);
            }
            else
            {
                actionText.text = "Press 'F' to pick an object";
                actionText.gameObject.SetActive(true);
            }
        }
    }
}