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
        private AudioSource _screamer;

        private void Start()
        {
            _screamer = GetComponent<AudioSource>();
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
                _screamer.Play();
            }
        }

        private void OnDestroy()
        {
            _timer.OnTimerFailed -= FailedTimersCounter;
        }
    }
}