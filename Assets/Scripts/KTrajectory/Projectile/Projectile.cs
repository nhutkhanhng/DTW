using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KTrajectory;
using Core.Utilities;
using KAlignment;

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

[System.Serializable]
public struct PositionData
{
    public Vector3 Postion;
}

[System.Serializable]
public class Projectile
{
    public SerializableIAlignmentProvider alignment;

    public ITracjectoryData _DataTrajectory;
    public IMovementType _Movement;

    public CollisionData _CollisionData;

    [HideInInspector]
    public BallisticPrefabData _VFX;

    public PositionData _Translation;

    public void Start(Transform _Launcher, Vector3 __Begin, Transform Target, CollisionData _Collision)
    {
        /// Kiểu này có vẽ nguy hiểm dữ vậy ta =]]ư.
        /// Nếu mà khai báo thiếu cái _Begin của mình thì lại thành sai flow của mình. Ahihi.
        _DataTrajectory = new FollowData() { _Launcher = _Launcher, _Target = Target, _Begin = __Begin};

        _Movement = new LinearTrajectory() { _Speed = 5f };

        // _Movement = new ArcingTrajectory() { m_Height = 5f, Speed = 5f };
        _Translation.Postion = __Begin;

        _CollisionData = _Collision;
        ProjectileManager.Instance.AddProjectile(this);
    }
}
