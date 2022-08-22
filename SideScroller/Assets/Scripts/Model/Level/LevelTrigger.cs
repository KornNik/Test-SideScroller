using System;
using UnityEngine;
using SideScroller.Model.Unit;

namespace SideScroller.Model.LevelModel
{
    class LevelTrigger : MonoBehaviour
    {

        #region Fields

        public Action TriggerEntered;

        #endregion

        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.GetComponent<BasePlayerCharacter>();
            if (player is BasePlayerCharacter)
            {
                TriggerEntered?.Invoke();
            }
        }

        #endregion

    }
}
