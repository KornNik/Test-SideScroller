using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Unit;

namespace SideScroller.Data.Cell
{
    abstract class GameOjectCellData : ScriptableObject
    {
        #region Fields

        [SerializeField] protected Sprite _characterSprite;
        [SerializeField] protected string _characterName;

        #endregion


        #region Properties

        public Sprite CharacterSprite => _characterSprite;
        public string ChracterName => _characterName;

        #endregion
    }
}