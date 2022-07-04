using System;
using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.Controller;

namespace SideScroller.Helpers.Services
{
    sealed class PlayerService
    {
        #region Fields

        private BasePlayerCharacter _playerCharacter;

        #endregion


        #region Properties

        public BasePlayerCharacter PlayerCharacter => _playerCharacter;

        #endregion


        #region ClassLifeCycle

        public PlayerService()
        {

        }
        ~PlayerService()
        {

        }

        #endregion


        #region Mehtods

        public void SetPlayer(BasePlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        #endregion
    }
}
