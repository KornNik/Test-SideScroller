using System;
using UnityEngine;

namespace SideScroller.Helpers.Managers
{
    static class LayersManager
    {
        #region Fields

        private const string UI = "UI";
        private const string ENEMY = "Enemy";
        private const string PLAYER = "Player";
        private const string DEFAULT = "Default";
        private const string GROUND = "Ground";
        private const string WALL = "Wall";
        private const string ITEM = "Item";

        public const int DEFAULT_LAYER = 0;

        #endregion


        #region Proeprties

        public static int DefaultLayer { get; }
        public static int UiLayer { get; }
        public static int EnemyLayer { get; }
        public static int PlayerLayer { get; }
        public static int Ground { get; }
        public static int Wall { get; }
        public static int Item { get; }

        #endregion



        #region Class lifecycle

        static LayersManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            UiLayer = LayerMask.GetMask(UI);
            EnemyLayer = LayerMask.GetMask(ENEMY);
            PlayerLayer = LayerMask.GetMask(PLAYER);
            Ground = LayerMask.GetMask(GROUND);
            Wall = LayerMask.GetMask(WALL);
            Item = LayerMask.GetMask(ITEM);
        }

        #endregion
    }
}
