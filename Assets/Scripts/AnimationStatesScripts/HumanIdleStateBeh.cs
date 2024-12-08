using UnityEngine;

namespace AnimationStatesScripts
{
    public class HumanIdleStateBeh : StateMachineBehaviour
    {
        [SerializeField] private float showingPaperDelay;

        private float _timeElapsed;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed = 0f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= showingPaperDelay)
            {
                animator.SetTrigger("ShowPaper");
            }
        }
    }
}

