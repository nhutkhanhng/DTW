using Core.Utilities;
using KTrajectory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAlignment;

[System.Serializable]
public class Finder
{
    public List<Transform> _Targets = new List<Transform>();
    public List<Transform> Targets()
    {
        return _Targets;
    }
}

[System.Serializable]
public struct BulletSetting
{
    public GameObject _VFX;
    public CollisionData _Collision;

    public Vector3 LocalScale;
}

public class KLauncher : MonoBehaviour
{
    public SerializableIAlignmentProvider alignment;

    public BulletSetting _Bullet;

    public Finder _Finder;

    public Transform _PositionLaunch;

    public void Start()
    {
        Launch(_Finder._Targets);
    } 
    public void Launch(List<Transform> _Targets)
    {
        for(int i = 0; i < _Targets.Count; i++)
        {
            var _newBullet = new Projectile();

            _newBullet._VFX.Vfx = Poolable.TryGetPoolable(_Bullet._VFX);
            _newBullet._VFX.Vfx.transform.localScale = _Bullet.LocalScale;

            _newBullet.alignment = this.alignment;

            _newBullet.Start(this.transform, _PositionLaunch.position, _Targets[i].transform,
                _newBullet._VFX.Vfx.GetComponent<CollisionData>());
        }
    }
}
