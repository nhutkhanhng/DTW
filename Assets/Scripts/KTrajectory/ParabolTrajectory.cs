using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTrajectory
{
    public class ParabolTrajectory : IMovementType
    {
        public static Vector3 GetParabolaInitVelocity(Vector3 from, Vector3 to, float gravity = 9.8f, float heightOff = 0.0f, float rangeOff = 0.11f)
        {
            Vector3 newVel = new Vector3();

            Vector3 direction = new Vector3(to.x, 0f, to.z) - new Vector3(from.x, 0f, from.z);

            float range = direction.magnitude;

            range += rangeOff;
            // Find unit direction of motion without the y component
            Vector3 unitDirection = direction.normalized;

            float maxYPos = to.y + heightOff;

            if (maxYPos < from.y)
                maxYPos = from.y;

            // find the initial velocity in y direction
            //// We find the initial velocity in the Y direction.//
            float ft;
            ft = -2.0f * gravity * (maxYPos - from.y);
            if (ft < 0) ft = 0f;
            newVel.y = Mathf.Sqrt(ft);

            ft = -2.0f * (maxYPos - from.y) / gravity;
            if (ft < 0)
                ft = 0f;

            float timeToMax = Mathf.Sqrt(ft);

            ft = -2.0f * (maxYPos - to.y) / gravity;
            if (ft < 0)
                ft = 0f;

            float timeToTargetY = Mathf.Sqrt(ft);

            float totalFlightTime;

            totalFlightTime = timeToMax + timeToTargetY;


            float horizontalVelocityMagnitude = range / totalFlightTime;

            newVel.x = horizontalVelocityMagnitude * unitDirection.x;
            newVel.z = horizontalVelocityMagnitude * unitDirection.z;
            return newVel;
        }
        /// <returns></returns>
        public static Vector3 GetParabolaNextPosition(Vector3 position, Vector3 velocity, float gravity, float time)
        {
            velocity.y += gravity * time;
            return position + velocity * time;
        }

        protected bool IsDirty = true;

        protected Vector3 m_Direction;
        public float m_Height;
        public float Speed { get; set; }

        public Vector3 Direction(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            return GetParabolaInitVelocity(Data.BeginPoint, Data.EndPoint, -9.8f, m_Height, 0);
        }

        public bool IsPrevReach(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            var m_Change = Direction(CurrentPoint, Data, deltaTime);

            return
                Vector3.Distance(GetParabolaNextPosition(CurrentPoint, m_Change, -9.8f, deltaTime * 2f), 
                                                        Data.EndPoint) <= 0.5f;
        }

        public Vector3 NextPoint(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            if (IsDirty)
            {
                m_Direction = Direction(CurrentPoint, Data, deltaTime);
                IsDirty = false;
            }

            m_Direction.y += -9.8f * deltaTime;

            return GetParabolaNextPosition(CurrentPoint, m_Direction, -9.8f, deltaTime);
        }
    }
}