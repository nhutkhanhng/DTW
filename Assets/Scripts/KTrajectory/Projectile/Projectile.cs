using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KTrajectory;

public struct FollowData : ITracjectoryData
{
    public Transform _Target;
    public Transform _Launcher;

    public Vector3 _Begin;
    public Vector3 BeginPoint { get { return _Begin; } }

    // private Vector3 _End;
    public Vector3 EndPoint { get { return _Target.transform.position; } }


    public FollowData(Transform Launcher, Transform Target)
    {
        _Target = Target;
        _Launcher = Launcher;

        _Begin = Launcher.transform.position;
    }
}

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public Trajectory _Trajectory;

    public ITracjectoryData _DataTrajectory;
    public IMovementType _Movement;

    public CollisionData _CollisionData;

    public Transform Target;
    public void Start()
    {
        /// Kiểu này có vẽ nguy hiểm dữ vậy ta =]]ư.
        /// Nếu mà khai báo thiếu cái _Begin của mình thì lại thành sai flow của mình. Ahihi.
        _DataTrajectory = new FollowData() { _Launcher = this.transform, _Target = Target, _Begin = this.transform.position};
        //_Movement = new LinearTrajectory() { _Speed = 50f };

        _Movement = new ArcingTrajectory() { m_Height = 5f, Speed = 5f };

        ProjectileManager.Instance.AddProjectile(this);
    }

    public Vector3 Calculate(float deltaTime)
    {
        //if (_Movement.IsPrevReach(this.transform.position, _DataTrajectory, deltaTime))
        //    return _DataTrajectory.EndPoint;
        //else
            return _Movement.NextPoint(this.transform.position, _DataTrajectory, deltaTime);
    }

    public void LateUpdate()
    {
        var Hits = CollisionManager.Instance.Collision(this._CollisionData);
    }
}
