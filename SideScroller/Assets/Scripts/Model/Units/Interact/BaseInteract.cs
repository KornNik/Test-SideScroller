using UnityEngine;
using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.Interact
{
    class BaseInteract
    {
        #region Fields

        private BaseUnit _unit;
        private Collider2D[] _itemsInteractable;

        #endregion


        public BaseInteract(BaseUnit unit)
        {
            _unit = unit;
            _itemsInteractable = new Collider2D[32];
        }

        #region Methods

        public void InteractWithObjects()
        {
            var countItems = Physics2D.OverlapCircleNonAlloc(_unit.AttackArea.transform.position,
                _unit.Parameters.InteractDistance, _itemsInteractable, LayersManager.Item);

            for (int i = 0; i < countItems; i++)
            {
                var interactable = _itemsInteractable[i].GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interacte(_unit);
                }
            }
        }
        public bool IsInteractPresent()
        {
            var isFindTarget = Physics2D.OverlapCircle(_unit.AttackArea.transform.position,
                _unit.Parameters.InteractDistance, LayersManager.Item);

            return isFindTarget;
        }

        #endregion
    }
}
