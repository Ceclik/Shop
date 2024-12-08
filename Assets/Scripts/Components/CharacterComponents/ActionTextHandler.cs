using Interfaces;
using Services.CharacterServices;
using TMPro;
using UnityEngine;

namespace Components.CharacterComponents
{
    public class ActionTextHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI actionText;
        private IActionTextHandler _actionTextHandler;

        private Camera _camera;

        public TextMeshProUGUI ActionText => actionText;

        public bool IsTextShown { get; private set; }

        private void Start()
        {
            _camera = Camera.main;
            _actionTextHandler = new ActionTextHandlingService();
        }

        public void ShowActionText(bool isObjectPicked)
        {
            _actionTextHandler.HandleActionText(actionText, isObjectPicked);
            IsTextShown = true;
        }

        public void ShowCashRegisterText(bool isOpened)
        {
            _actionTextHandler.ShowCashRegisterText(actionText, isOpened);
        }

        public void HideActionText()
        {
            actionText.gameObject.SetActive(false);
            IsTextShown = false;
        }
    }
}