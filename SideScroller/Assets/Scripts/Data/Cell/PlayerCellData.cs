using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Cell
{
    [CreateAssetMenu(fileName = "CharacterCellData", menuName = "Data/Unit/CharacterCellData")]
    class PlayerCellData : GameOjectCellData
    {
        #region Fields

        [SerializeField] private PlayerCharacterTypes _playerCharacterType;

        #endregion


        #region Properties

        public PlayerCharacterTypes PlayerCharacterType => _playerCharacterType;

        #endregion

    }
}