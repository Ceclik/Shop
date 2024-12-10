using System;
using UnityEngine;

namespace Components.CharacterComponents
{
    public class CharacterDeathHandler : MonoBehaviour
    {
        [SerializeField] private int amountOfTimersFailedToDeath;
        [SerializeField] private GameObject deathPanel;

        private TimerHandler _timer;
        private int _amountOfFailedTimers;

        private void Start()
        {
            _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerHandler>();
            _timer.OnTimerFailed += FailedTimersCounter;
        }

        private void FailedTimersCounter()
        {
            _amountOfFailedTimers++;

            if (_amountOfFailedTimers >= amountOfTimersFailedToDeath)
            {
                deathPanel.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        private void OnDestroy()
        {
            _timer.OnTimerFailed -= FailedTimersCounter;
        }
    }
}