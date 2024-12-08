using Components.HumanComponents;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class TakePaperAwayStateBeh : StateMachineBehaviour
    {
        private HumanPathWalker _humanPathWalker;
        private Animator _animator;
    
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
            _humanPathWalker.ChangeDirection();
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
