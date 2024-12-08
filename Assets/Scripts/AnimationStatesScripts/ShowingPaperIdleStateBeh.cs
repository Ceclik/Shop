using Components.OrderComponents;
using UnityEngine;

namespace AnimationStatesScripts
{
    public class ShowingPaperIdleStateBeh : StateMachineBehaviour
    {
        private ObjectsCounter _order;

        private Animator _animator;
    
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _order = GameObject.FindGameObjectWithTag("ObjectsCounter").GetComponent<ObjectsCounter>();
            _animator = animator;
            _order.OnOrderComplete += SetHideTrigger;
        }

        private void SetHideTrigger()
        {
            _animator.SetTrigger("HidePaper");
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _order.OnOrderComplete -= SetHideTrigger;
        }
    }
}
