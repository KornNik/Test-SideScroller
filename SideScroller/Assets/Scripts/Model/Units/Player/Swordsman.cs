using SideScroller.Model.Unit.Combat;

namespace SideScroller.Model.Unit
{
    class Swordsman : BasePlayerCharacter
    {
        #region Fields


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _combat = new SwordsmanCombat(_unitCombatParameters, this);
        }

        #endregion


        #region Methods


        #endregion
    }
}