using Components.CashRegisterComponents;
using UnityEngine;

public class ShowingMoneyIdleStateBeh : StateMachineBehaviour
{
    private MoneyInteraction _moneyInteraction;
    private Animator _animator;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator; 
        _moneyInteraction = GameObject.FindGameObjectWithTag("MoneyInteractionPart").GetComponent<MoneyInteraction>();
        _moneyInteraction.OnMoneyPutIntoCashRegister += SetTakeMoneyAwayTrigger;
    }

    private void SetTakeMoneyAwayTrigger()
    {
        _animator.SetTrigger("TakeMoneyAway");
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _moneyInteraction.OnMoneyPutIntoCashRegister -= SetTakeMoneyAwayTrigger;
    }
}
