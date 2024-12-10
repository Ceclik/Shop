using Components.HumanComponents;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class HumanWalkStateBeh : StateMachineBehaviour
    {
        [SerializeField] private float stepSoundDelta;
        private Animator _animator;
        private HumanPathWalker _humanPathWalker;
        private AudioSource _stepSound;
        private float _timer;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timer = 0;
            _animator = animator;
            ResetAllTriggers();
            _humanPathWalker = GameObject.FindGameObjectWithTag("Human").GetComponent<HumanPathWalker>();
            _humanPathWalker.OnHumanCameToTable += SetCameToTableTrigger;
            _stepSound = _humanPathWalker.GetComponent<AudioSource>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timer += Time.deltaTime;
            if (_timer >= stepSoundDelta && _humanPathWalker.CurrentPointIndex >= 2)
            {
                _stepSound.Play();
                _timer = 0;
            }
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
