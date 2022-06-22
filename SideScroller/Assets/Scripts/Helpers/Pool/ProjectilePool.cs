using System;
using UnityEngine;
using System.Linq;
using SideScroller.Helpers.AssetsPath;
using SideScroller.Helpers.Types;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using SideScroller.Model.Item;

namespace SideScroller.Helpers.Pool
{
    sealed class ProjectilePool : PoolObjects<ProjectileTypes>
    {
        #region ClassLifeCycle

        public ProjectilePool(int capacityPool, Transform poolTransform) : base(capacityPool, poolTransform)
        {
            _objectPool = new Dictionary<ProjectileTypes, HashSet<IPoolable>>();
        }

        #endregion


        #region Methods
        public override IPoolable GetObject(ProjectileTypes type)
        {
            IPoolable result;
            switch (type)
            {
                case ProjectileTypes.Arrow:
                    result = GetArrow(GetListObject(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private IPoolable GetArrow(HashSet<IPoolable> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            if (ammunition == null)
            {
                var bullet = CustomResources.Load<Arrow>(ProjectilesAssetPath.ProjectilesPath[ProjectileTypes.Arrow]);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(bullet);
                    ReturnToPool(instantiate.transform);
                    instantiate.PoolTransform = _poolTransform;
                    ammunitions.Add(instantiate);
                }

                GetArrow(ammunitions);
            }
            ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            return ammunition;
        }

        #endregion
    }
}
