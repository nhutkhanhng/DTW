using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTrajectory
{
    public class LinearTrajectory : IMovementType
    {
        [SerializeField]
        public float _Speed;
        public float Speed { get { return _Speed; } } 

        public Vector3 Direction(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            return (Data.EndPoint - CurrentPoint).normalized * Speed * deltaTime;
        }

        public bool IsPrevReach(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            Vector3 Change = Direction(CurrentPoint, Data, deltaTime);
            return Vector3.Distance(Data.EndPoint, CurrentPoint) <= Change.magnitude;
        }

        public Vector3 NextPoint(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime)
        {
            return CurrentPoint + (Data.EndPoint - CurrentPoint).normalized * Speed * deltaTime;
        }
    }
}