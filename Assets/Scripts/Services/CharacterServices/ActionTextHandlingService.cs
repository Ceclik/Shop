using Interfaces;
using TMPro;

namespace Services.CharacterServices
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

        public void ShowCashRegisterText(TextMeshProUGUI actionText, bool isOpened)
        {
            actionText.text = !isOpened ? "Press 'F' to open cash register" : "Press 'F' to close cash register";

            actionText.gameObject.SetActive(true);
        }
    }
}