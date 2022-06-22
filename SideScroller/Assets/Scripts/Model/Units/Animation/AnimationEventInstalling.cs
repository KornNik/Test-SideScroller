using UnityEngine;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class AnimationEventInstalling
    {
        #region Fields

        private AnimationClip _animationClip;
        private AnimationEvent _animationEvent = new AnimationEvent();

        #endregion


        #region ClassLifeCycle

        public AnimationEventInstalling()
        {

        }

        #endregion


        #region Methods

        public void GetAnimationClip(Animator animator, string animationClipName)
        {
            foreach (var item in animator.runtimeAnimatorController.animationClips)
            {
                if (item.name == animationClipName)
                {
                    _animationClip = item;
                }
            }
        }
        public void SetEventByTime(float eventTime, string functionName)
        {
            _animationEvent.time = eventTime;
            _animationEvent.functionName = functionName;
            _animationClip.AddEvent(_animationEvent);
        }

        #endregion
    }
}
