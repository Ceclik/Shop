using Components.HumanComponents;
using UnityEngine;

public class TakeMoneyAwayStateBeh : StateMachineBehaviour
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
       _animator.ResetTrigger("ShowMoney");
       _animator.ResetTrigger("TakeMoneyAway");
       _animator.ResetTrigger("CameToTable");
    }
    
}
