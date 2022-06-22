using UnityEngine;


namespace SideScroller.Model.Unit.AI
{
    static class PatrolPoinGenerator
    {
        public static Vector3 GeneratePoint(Vector3 point,float distance)
        {
            var randomDistance = Random.Range(-distance, distance);
            Vector3 result = new Vector3(point.x + randomDistance, 0f, 0f);
            return result;
        }
    }
}
