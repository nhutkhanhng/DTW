using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTrajectory
{
    public class ArcingTrajectory : IMovementType
    {
        public float m_Height;
        public float Speed { get; set; }

        // D = v^2 * sin(2omega) / g
        public Vector3 Direction(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            return Vector3.forward;
        }

        public bool IsPrevReach(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            return true;
        }

        /*
             public static Vector3 MoveTowards(
      Vector3 current,
      Vector3 target,
      float maxDistanceDelta)
    {
      float num1 = target.x - current.x;
      float num2 = target.y - current.y;
      float num3 = target.z - current.z;
      float num4 = (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3);
      if ((double) num4 == 0.0 || (double) maxDistanceDelta >= 0.0 && (double) num4 <= (double) maxDistanceDelta * (double) maxDistanceDelta)
        return target;
      float num5 = (float) Math.Sqrt((double) num4);
      return new Vector3(current.x + num1 / num5 * maxDistanceDelta, current.y + num2 / num5 * maxDistanceDelta, current.z + num3 / num5 * maxDistanceDelta);
    } 
         */
        public Vector3 NextPoint(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            Vector3 Dist = Data.EndPoint - Data.BeginPoint;

            Vector3 nextX = Vector3.MoveTowards(CurrentPoint, Data.EndPoint, Speed * deltaTime);

            float baseY = Mathf.Lerp(Data.BeginPoint.y, Data.EndPoint.y, (nextX - Data.BeginPoint).magnitude / Dist.magnitude);

            var dStart = (nextX - Data.BeginPoint);
            dStart.y = 0;

            var dEnd = (nextX - Data.EndPoint);
            dEnd.y = 0;

            float arc = m_Height * dStart.magnitude * dEnd.magnitude / (0.25f * Dist.sqrMagnitude);

            nextX.y = baseY + arc;
            //nextX.y = Mathf.Max(baseY + arc, Mathf.Max(m_Height, Data.EndPoint.y));

            return nextX;
        }
    }
}