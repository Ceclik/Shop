using UnityEngine;

public class MoneySpawner : StateMachineBehaviour
{
    [SerializeField] private GameObject money;
    
    private Transform _moneySpawnPoint;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _moneySpawnPoint = GameObject.Find("MoneyPoint").transform;
        var spawnedMoney = Instantiate(money, _moneySpawnPoint.position, _moneySpawnPoint.rotation, _moneySpawnPoint);
        spawnedMoney.GetComponent<Rigidbody>().isKinematic = true;
    }

}
