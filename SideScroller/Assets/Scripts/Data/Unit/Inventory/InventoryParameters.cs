using System;
using UnityEngine;

namespace SideScroller.Data.Inventory
{
    [CreateAssetMenu(fileName ="InventoryParameters",menuName ="Data/Unit/Inventory")]
    class InventoryParameters : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _inventorySize;

        #endregion


        #region Properties

        public int InventorySize => _inventorySize;

        #endregion

    }
}
