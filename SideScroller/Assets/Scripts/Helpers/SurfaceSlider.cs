using System;
using UnityEngine;
using System.Linq;

namespace SideScroller.Helpers
{
    class SurfaceSlider : MonoBehaviour
    {
        #region Fields

        private Vector3 _normal;

        #endregion


        #region UnityMethods

        private void OnCollisionEnter(Collision collision)
        {
            _normal = collision.contacts[0].normal;
        }

        #endregion


        #region Methods

        public Vector3 Project(Vector3 unitDirection)
        {
            return unitDirection - Vector3.Dot(unitDirection, _normal) * _normal;
        }

        #endregion
    }
}
