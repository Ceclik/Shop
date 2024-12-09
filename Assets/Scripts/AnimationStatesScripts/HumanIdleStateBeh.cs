using UnityEngine;

namespace AnimationStatesScripts
{
    public class HumanIdleStateBeh : StateMachineBehaviour
    {
        [SerializeField] private float showingPaperDelay;
        [SerializeField] private float showingMoneyDelay;
        
        private float _timeElapsed;
        private bool _isPaperShown;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed = 0f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed += Time.deltaTime;
            if (!_isPaperShown && _timeElapsed >= showingPaperDelay)
            {
                animator.SetTrigger("ShowPaper");
                _isPaperShown = true;
            }
            
            else if(_isPaperShown && _timeElapsed >= showingMoneyDelay)
                animator.SetTrigger("ShowMoney");
        }
    }
}

