using SideScroller.UI;
using SideScroller.UI.Parts;
using SideScroller.Model.Unit;

namespace SideScroller.Model.UnitInventory
{
    class UnitBags
    {
        #region Fields

        private Equipment _equipment;
        private Inventory _inventory;
        private InventoryEventManager _inventoryEventManager;

        #endregion


        #region Properties

        public Equipment Equipment => _equipment;
        public Inventory Inventory => _inventory;
        public InventoryEventManager InventoryEventManager => _inventoryEventManager;

        #endregion


        #region ClassLifeCycle

        public UnitBags(BaseUnit unit)
        {
            _equipment = new Equipment(unit.InventoryTransform);
            _inventory = new Inventory(unit.InventoryParameters);
            _inventoryEventManager = new InventoryEventManager();

            CharacterMenu.EquipmentItemSelected += _inventory.AddItemToInventory;
            CharacterMenu.EquipmentItemSelected += _equipment.Unequip;
            CharacterMenu.InventoryItemSelected += _equipment.Equip;
            CharacterMenu.InventoryItemSelected += _inventory.RemoveItemFromInventory;

            CharacterInventoryUI.InventoryUIChecking += _inventory.SendItemsToCheck;
            CharacterEquipmentUI.EquipmentUIChecking += _equipment.SendEquipmentsToCheck;
        }

        ~UnitBags()
        {
            CharacterMenu.EquipmentItemSelected = null;
            CharacterMenu.InventoryItemSelected = null;

            CharacterInventoryUI.InventoryUIChecking -= _inventory.SendItemsToCheck;
            CharacterEquipmentUI.EquipmentUIChecking -= _equipment.SendEquipmentsToCheck;
        }
        #endregion

    }
}
