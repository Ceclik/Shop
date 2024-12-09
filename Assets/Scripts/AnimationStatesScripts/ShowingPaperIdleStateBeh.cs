using Components;
using Components.OrderComponents;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class ShowingPaperIdleStateBeh : StateMachineBehaviour
    {
        private ObjectsCounter _order;

        private Animator _animator;
        private TimerHandler _timer;
        
    
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //OnOrderShown?.Invoke();
            _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerHandler>();
            _timer.ShowTimer();
            _timer.OnTimerFailed += TimerFailTrigger;
            
            _order = GameObject.FindGameObjectWithTag("ObjectsCounter").GetComponent<ObjectsCounter>();
            _animator = animator;
            _order.OnOrderComplete += SetHideTrigger;
        }

        private void TimerFailTrigger()
        {
            _animator.SetTrigger("HidePaper");
            _animator.SetTrigger("TimerFailGoAway");
        }
        
        private void SetHideTrigger()
        {
            _animator.SetTrigger("HidePaper");
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _order.OnOrderComplete -= SetHideTrigger;
            _timer.OnTimerFailed -= TimerFailTrigger;
        }
    }
}
