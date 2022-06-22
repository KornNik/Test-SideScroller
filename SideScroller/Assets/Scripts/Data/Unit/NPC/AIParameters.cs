using UnityEngine;

namespace SideScroller.Data.Unit.AI
{
    [CreateAssetMenu(fileName = "AIParameters", menuName = "Data/Unit/AIPaarmeters")]
    class AIParameters : ScriptableObject
    {
        #region Fields

        [Range(0f, 10f)]
        [SerializeField] private float _distanceView;
        [Range(0.2f, 3f)]
        [SerializeField] private float _stopingDistance;
        [Range(1f, 4f)]
        [SerializeField] private float _patrolDistance;

        #endregion


        #region Properties

        public float DistanceView => _distanceView; 
        public float StopingDistance => _stopingDistance;
        public float PatrolDistance => _patrolDistance;

        #endregion

    }
}
