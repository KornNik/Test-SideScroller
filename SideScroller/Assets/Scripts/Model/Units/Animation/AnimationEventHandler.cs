using UnityEngine;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class AnimationEventHandler
    {
        #region Fields

        private Animator _animator;
        private AnimationEventInstalling _eventInstalling;

        #endregion


        #region ClassLifeCycle

        public AnimationEventHandler(Animator animator)
        {
            _animator = animator;

            _eventInstalling = new AnimationEventInstalling();
        }

        #endregion


        #region Methods

        public void SetEvent(string attackClipName, float eventTime, string damageMethod)
        {
            _eventInstalling.GetAnimationClip(_animator, attackClipName);
            _eventInstalling.SetEventByTime(eventTime, damageMethod);
        }

        #endregion
    }
}
