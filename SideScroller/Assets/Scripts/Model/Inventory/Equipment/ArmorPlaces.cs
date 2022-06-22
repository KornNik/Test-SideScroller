using SideScroller.Model.Item;

namespace SideScroller.Model.Inventory
{
    struct ArmorPlaces
    {
        #region MyRegion

        private CommonArmor _head;
        private CommonArmor _body;
        private CommonArmor _legs;
        private CommonArmor _hands;

        #endregion


        #region Properties

        public CommonArmor Head
        {
            get { return _head; }
            set
            {
                if (_head.ArmorType == Helpers.Types.ArmorTypes.Head)
                {
                    _head = value;
                }
            }
        }
        public CommonArmor Body
        {
            get { return _body; }
            set
            {
                if (_body.ArmorType == Helpers.Types.ArmorTypes.Body)
                {
                    _body = value;
                }
            }
        }
        public CommonArmor Legs
        {
            get { return _legs; }
            set
            {
                if (_legs.ArmorType == Helpers.Types.ArmorTypes.Legs)
                {
                    _legs = value;
                }
            }
        }
        public CommonArmor Hands
        {
            get { return _hands; }
            set
            {
                if (_hands.ArmorType == Helpers.Types.ArmorTypes.Hands)
                {
                    _hands = value;
                }
            }
        }
        #endregion

    }
}
