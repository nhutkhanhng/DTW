using UnityEngine;

namespace KTrajectory
{
    public interface IMovementType
    {
        float Speed { get; }

        Vector3 Direction(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime);

        Vector3 NextPoint(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime);

        bool IsPrevReach(Vector3 CurrentPoint, ITracjectoryData Data, float deltaTime);
    }


}
