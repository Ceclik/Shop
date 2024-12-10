using Components.HumanComponents;
using Components.OrderComponents;
using TMPro;
using UnityEngine;

namespace Components
{
    public class TimerHandler : MonoBehaviour
    {
        [SerializeField] private float timeOnOneClient;
        [SerializeField] private AudioSource losingSound;
        private float _currentTimer;
        private TextMeshProUGUI _timerText;
        private ObjectsCounter _order;
        private HumanPathWalker _humanPathWalker;

        private bool _isFailed;

        public delegate void SetAnimationTriggers();

        public event SetAnimationTriggers OnTimerFailed;

        private void Start()
        {
            _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
            _order = GameObject.FindGameObjectWithTag("ObjectsCounter").GetComponent<ObjectsCounter>();
            _order.OnOrderComplete += HideTimer;
            _timerText = GetComponent<TextMeshProUGUI>();
            HideTimer();
        }

        public void ShowTimer()
        {
            _currentTimer = timeOnOneClient;
            _timerText.enabled = true;
            _isFailed = false;
        }

        public void HideTimer()
        {
            _currentTimer = 0;
            _timerText.enabled = false;
        }

        private void HandleTimerText()
        {
            int minutes = (int)_currentTimer / 60;
            int seconds;
            if (_currentTimer > 60)
                seconds = (int)_currentTimer % 60;
            else seconds = (int)_currentTimer;
            
            _timerText.text = $"{minutes}:{seconds}";
        }

        private void OnDestroy()
        {
            _order.OnOrderComplete -= HideTimer;
        }


        private void Update()
        {
            if (_currentTimer < 1 && !_isFailed && _timerText.isActiveAndEnabled)
            {
                _isFailed = true;
                HideTimer();
                OnTimerFailed?.Invoke();
                losingSound.Play();
                _humanPathWalker.ChangeDirection();
            }
            if (_currentTimer >= 1)
            {
                _currentTimer -= Time.deltaTime;
                HandleTimerText();
            }
        }
    }
}