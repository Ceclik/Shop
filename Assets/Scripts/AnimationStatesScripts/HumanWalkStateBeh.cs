using Components.HumanComponents;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class HumanWalkStateBeh : StateMachineBehaviour
    {
        private Animator _animator;
        private HumanPathWalker _humanPathWalker;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _animator = animator;
            ResetAllTriggers();
            _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
            _humanPathWalker.OnHumanCameToTable += SetCameToTableTrigger;
        }

        private void SetCameToTableTrigger()
        {
            _animator.SetTrigger("CameToTable");
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _humanPathWalker.OnHumanCameToTable -= SetCameToTableTrigger;
        }

        private void ResetAllTriggers()
        {
            _animator.ResetTrigger("CameToTable");
            _animator.ResetTrigger("ShowPaper");
            _animator.ResetTrigger("HidePaper");
            _animator.ResetTrigger("ShowMoney");
            _animator.ResetTrigger("TakeMoneyAway");
            _animator.ResetTrigger("TimerFailGoAway");
        }
    
    }
}
