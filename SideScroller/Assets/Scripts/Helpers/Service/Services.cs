using System;

namespace SideScroller.Helpers.Services
{
    sealed class Services
    {
        #region Fields

        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        #endregion


        #region ClassLifeCycles

        public Services()
        {
            Initialize();
        }

        #endregion


        #region Properties

        public static Services Instance => _instance.Value;
        public PlayerService PlayerService { get; private set; }

        #endregion


        #region Methods

        private void Initialize()
        {
            PlayerService = new PlayerService();
        }

        #endregion
    }
}
