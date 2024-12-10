using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class ButtonsHandler : MonoBehaviour
    {
        public void OnRestartOrPlayButtonClick()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Gameplay");
        }
    }
}