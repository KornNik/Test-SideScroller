using UnityEngine;

namespace SideScroller.Helpers
{
    static class ColliderEnabler
    {
        #region Methods

        public static Collider2D ColliderEnabledChanger(Transform transformObject, Collider2D collider, bool status)
        {
            var tempCollider = collider;
            if (tempCollider)
            {
                tempCollider.enabled = status;
                if (transformObject.childCount <= 0) return tempCollider;
                foreach (Transform item in transformObject)
                {
                    tempCollider = item.GetComponentInChildren<Collider2D>();
                    if (tempCollider)
                    {
                        tempCollider.enabled = status;
                    }
                }
                return tempCollider;
            }
            return collider;
        }

        #endregion
    }
}
