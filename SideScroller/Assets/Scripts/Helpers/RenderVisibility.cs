using UnityEngine;

namespace SideScroller.Helpers
{
    static class RenderVisibility
    {
        #region Methods

        public static SpriteRenderer SpriteRenderVisibilityChange(Transform transformObject, SpriteRenderer spriteRenderer, bool status)
        {
            var tempSprite = spriteRenderer;
            if (tempSprite)
            {
                tempSprite.enabled = status;
                if (transformObject.childCount <= 0) return tempSprite;
                foreach (Transform item in transformObject)
                {
                    tempSprite = item.GetComponentInChildren<SpriteRenderer>();
                    if (tempSprite)
                    {
                        tempSprite.enabled = status;
                    }
                }
                return tempSprite;
            }
            return spriteRenderer;
        }

        #endregion
    }
}
