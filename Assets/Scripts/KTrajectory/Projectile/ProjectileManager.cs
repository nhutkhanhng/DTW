using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileManager : MonoSingleton<ProjectileManager>
{
    public List<Projectile> _ProjectilesIngame = new List<Projectile>();
    public List<Vector3> _NextPoints = new List<Vector3>();

    public void AddProjectile(Projectile _projectile)
    {
        _ProjectilesIngame.Add(_projectile);
        _NextPoints.Add(_projectile._Translation.Postion);
    }
    public void PrevCalculate(float deltaTime)
    {
        Projectile _Projectile = null;

        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            _Projectile = _ProjectilesIngame[i];

            _NextPoints[i] = _Projectile._Movement.NextPoint(
                _Projectile._Translation.Postion, _Projectile._DataTrajectory, deltaTime);
        }
    }

    public void DoUpdate(float deltaTime)
    {
        Projectile _Projectile;
        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            _Projectile = _ProjectilesIngame[i];

            _Projectile._Translation.Postion = _NextPoints[i];
            _Projectile._Vfx.transform.position = _Projectile._Translation.Postion;
        }
    }

    public void Remove(Projectile projectile)
    {

    }

    public void Remove(int index)
    {
        _ProjectilesIngame.RemoveAt(index);
        _NextPoints.RemoveAt(index);
    }

    public void FixedUpdate()
    {
        PrevCalculate(Time.deltaTime);
    }

    private void Update()
    {
        DoUpdate(Time.deltaTime);
    }
}
