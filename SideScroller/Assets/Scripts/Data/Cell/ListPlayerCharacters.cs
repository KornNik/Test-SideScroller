using UnityEngine;
using SideScroller.Model.Unit;

namespace SideScroller.Data.Cell
{
    [CreateAssetMenu(fileName ="ListPlayerCharacters", menuName = "Data/Unit/ListPlayerChracters")]
    class ListPlayerCharacters : ScriptableObject
    {
        #region Fields

        [SerializeField] private PlayerCellData[] _playersCharactersArray;

        #endregion


        #region Properties

        public PlayerCellData[] PlayerCharactersArray => _playersCharactersArray;

        #endregion

    }
}