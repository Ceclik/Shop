using UnityEngine;

namespace AnimationStatesScripts
{
    public class TakePaperAwayStateBeh : StateMachineBehaviour
    {
        private Animator _animator;
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            ResetAllTriggers();
        }

        private void ResetAllTriggers()
        {
            _animator.ResetTrigger("CameToTable");
            _animator.ResetTrigger("ShowPaper");
            _animator.ResetTrigger("HidePaper");
        }
    }
}
