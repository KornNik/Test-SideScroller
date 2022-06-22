using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace SideScroller.Helpers.Pool
{
    abstract class PoolObjects <T>
    {
        #region Fields

        protected Dictionary<T, HashSet<IPoolable>> _objectPool;
        protected readonly int _capacityPool;
        protected readonly Transform _poolTransform;

        #endregion


        #region ClassLifeCycles

        public PoolObjects(int capacityPool, Transform poolTransform)
        {
            _capacityPool = capacityPool;
            _poolTransform = poolTransform;
        }

        #endregion


        #region Methods

        public abstract IPoolable GetObject(T ammunitionType);

        protected virtual void ReturnToPool(Transform transform)
        {
            transform.SetParent(_poolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
        }
        protected void RemovePool()
        {
            Object.Destroy(_poolTransform.gameObject);
        }
        protected HashSet<IPoolable> GetListObject(T type)
        {
            return _objectPool.ContainsKey(type) ? _objectPool[type] : _objectPool[type] = new HashSet<IPoolable>();
        }

        #endregion
    }
}
