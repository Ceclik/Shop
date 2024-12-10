using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class ButtonsHandler : MonoBehaviour
    {
        [SerializeField] private GameObject storyPanel;
        [SerializeField] private GameObject pausePanel;

        public void OnRestartOrPlayButtonClick()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Gameplay");
        }

        public void OnStoryButtonClick()
        {
            storyPanel.SetActive(true);
        }

        public void OnQuitButtonClick()
        {
            Application.Quit();
        }

        public void OnCloseInstructionButtonClick()
        {
            storyPanel.SetActive(false);
        }

        public void OnExitToMenuButtonClick()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnContinueButtonClick()
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

    private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Gameplay" && Input.GetKeyDown(KeyCode.Escape) &&
                !pausePanel.activeSelf)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else if(SceneManager.GetActiveScene().name == "Gameplay" && Input.GetKeyDown(KeyCode.Escape) &&
                    pausePanel.activeSelf)
                    OnContinueButtonClick();
        }
    }
}