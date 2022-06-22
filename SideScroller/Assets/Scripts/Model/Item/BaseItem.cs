using UnityEngine;
using SideScroller.Data.Item;
using SideScroller.Model.Unit;
using SideScroller.Helpers;

namespace SideScroller.Model.Item
{
    [RequireComponent(typeof(SpriteRenderer),typeof(Collider2D))]
    abstract class BaseItem : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] protected Collider2D _collider;
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        protected bool _isReadyToInteract = true;
        protected bool _isInBag;

        #endregion


        #region Properties

        public Collider2D ItemCollider => _collider;
        public SpriteRenderer ItemSpriteRenderer => _spriteRenderer;
        public bool IsInBag
        {
            get
            {
                return _isInBag;
            }
            set
            {
                _isInBag = value;
                if (_isInBag)
                {
                    _isReadyToInteract = false;
                }
                else { _isReadyToInteract = true; }
            }
        }

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }

        #endregion


        #region Methods

        public void Drop()
        {
            transform.parent = null;
            IsInBag = false;
            RenderVisibility.SpriteRenderVisibilityChange(transform, ItemSpriteRenderer, false);
            ColliderEnabler.ColliderEnabledChanger(transform, ItemCollider, false);
        }

        #endregion


        #region IInteractable

        public virtual void Interacte(BaseUnit interactUnit)
        {
            if (!_isReadyToInteract) return;

            interactUnit.Inventory.AddItemToInventory(this);
            transform.parent = interactUnit.transform;
            IsInBag = true;
        }

        #endregion

    }
}
