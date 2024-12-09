using Components;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class HumanIdleStateBeh : StateMachineBehaviour
    {
        [SerializeField] private float showingPaperDelay;
        [SerializeField] private float showingMoneyDelay;

        private TimerHandler _timer;
        
        private float _timeElapsed;
        private bool _isPaperShown;
        private bool _isMoneyShown;
        private bool _isNotExit;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed = 0f;
            _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerHandler>();
            _timer.OnTimerFailed += HandleTimerFail;
        }

        private void HandleTimerFail()
        {
            _isPaperShown = false;
            _isMoneyShown = false;
            _isNotExit = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed += Time.deltaTime;
            if (!_isPaperShown && !_isMoneyShown && _timeElapsed >= showingPaperDelay && !_isNotExit)
            {
                Debug.Log("In show paper");
                animator.SetTrigger("ShowPaper");
                _isPaperShown = true;
                _isNotExit = true;
            }
            else if (_isPaperShown && !_isMoneyShown && _timeElapsed >= showingMoneyDelay && !_isNotExit)
            {
                Debug.Log("In show money");
                animator.SetTrigger("ShowMoney");
                _isMoneyShown = true;
                _isNotExit = true;
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //_timeElapsed = 0f;
            Debug.Log("in idle exit");
            _isNotExit = false;
            if (_isMoneyShown && _isPaperShown)
            {
                _isPaperShown = false;
                _isMoneyShown = false;
            }
            //_timer.OnTimerFailed -= HandleTimerFail;
        }
        
    }
}

