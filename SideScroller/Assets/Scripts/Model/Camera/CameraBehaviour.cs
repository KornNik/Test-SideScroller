using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.Controller;
using SideScroller.Data.Camera;

namespace SideScroller.Model.CameraBeh
{
    [RequireComponent(typeof(Camera))]
    class CameraBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Camera _camera;
        [SerializeField] private CameraData _cameraData;

        private BasePlayerCharacter _target;
        private bool _isTarget;

        #endregion


        #region UnityMethods


        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            if (_isTarget)
            {
                CameraMovingToTarget(_target.transform);
            }
        }

        #endregion


        #region Methods

        public void SetPlayer(BasePlayerCharacter playerCharacter)
        {
            if (playerCharacter is BasePlayerCharacter)
            {
                _target = playerCharacter;
                _isTarget = true;
            }
        }

        private void CameraMovingToTarget(Transform target)
        {
            var desiredPosition = target.position + _cameraData.Offset;
            var lerpPostion = Vector3.Lerp(transform.position, desiredPosition, _cameraData.SmoothFactor * Time.fixedDeltaTime);
            transform.position = lerpPostion;
        }

        #endregion
    }
}