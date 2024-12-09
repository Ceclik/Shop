using Components.HumanComponents;
using UnityEngine;

public class TakeMoneyAwayStateBeh : StateMachineBehaviour
{
    [SerializeField] private GameObject beerPack;
    
    private Transform _moneySpawnPoint;
    private HumanPathWalker _humanPathWalker;
    private Animator _animator;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _moneySpawnPoint = GameObject.Find("MoneyPoint").transform;
        _animator = animator;
        _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
        _humanPathWalker.ChangeDirection();
        ResetAllTriggers();
        //Vector3 newPackRotation = new Vector3(90.0f, 0, 0);
        Instantiate(beerPack, _moneySpawnPoint.position, _moneySpawnPoint.rotation, _moneySpawnPoint);
    }
    
    private void ResetAllTriggers()
    {
       _animator.ResetTrigger("ShowMoney");
       _animator.ResetTrigger("TakeMoneyAway");
       _animator.ResetTrigger("CameToTable");
    }
    
}
