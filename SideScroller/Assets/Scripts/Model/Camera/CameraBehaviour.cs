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

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            LevelController.OnPlayerLoaded += SetPlayer;
        }

        private void OnDisable()
        {
            LevelController.OnPlayerLoaded -= SetPlayer;
        }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                CameraMovingToTarget(_target.transform);
            }
        }

        #endregion


        #region Methods

        private void CameraMovingToTarget(Transform target)
        {
            var desiredPosition = target.position + _cameraData.Offset;
            var lerpPostion = Vector3.Lerp(transform.position, desiredPosition, _cameraData.SmoothFactor * Time.fixedDeltaTime);
            transform.position = lerpPostion;
        }

        private void SetPlayer(BasePlayerCharacter playerCharacter)
        {
            _target = playerCharacter;
        }
        #endregion
    }
}