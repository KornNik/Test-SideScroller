using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;
using SideScroller.Helpers.Types;
using SideScroller.Model.Inventory;

namespace SideScroller.UI.Parts
{
    [RequireComponent(typeof(Image))]
    class ItemCell : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        [SerializeField] protected Text _itemName;
        [SerializeField] protected Image _itemImage;
        [SerializeField] protected Sprite _baseSpriteIcon;

        [SerializeField] protected BaseItem _item;

        protected bool _isEmpty = true;

        #endregion


        #region Properties

        public bool IsEmpty => _isEmpty;
        public BaseItem Item => _item;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _itemImage = GetComponent<Image>();
            _itemName = GetComponentInChildren<Text>();
        }

        #endregion


        #region Methods

        public void FillCellInfo(BaseItem item)
        {
            SetItem(item);
            SetName(item.name);
            SetImage(item.ItemSpriteRenderer.sprite);
            _isEmpty = false;
        }

        private void SetItem(BaseItem item)
        {
            _item = item;
        }
        private void SetImage(Sprite itemImage)
        {
            _itemImage.sprite = itemImage;
        }
        private void SetName(string name)
        {
            _itemName.text = name;
        }

        public void EmptyCell()
        {
            _item = null;
            _itemImage.sprite = _baseSpriteIcon;
            _itemName.text = " ";
            _isEmpty = true;
        }

        #endregion


        #region IPointerClickHandler

        public virtual void OnPointerClick(PointerEventData pointerEventData)
        {
            if(_item is BaseItem)
            {
                CharacterMenu.ItemShiftedInUIEquipment?.Invoke(_item);
            }
        }

        #endregion
    }
}
