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
        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            var _Projectiles = _ProjectilesIngame[i];

            _NextPoints[i] = _Projectiles._Movement.NextPoint(
                _Projectiles._Translation.Postion, _Projectiles._DataTrajectory, deltaTime);
        }
    }

    public void DoUpdate(float deltaTime)
    {
        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            var _Projectiles = _ProjectilesIngame[i];

            _Projectiles._Translation.Postion = _NextPoints[i];
            _Projectiles._VFX.Vfx.transform.position = _Projectiles._Translation.Postion;
        }
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
