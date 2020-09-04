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
        _NextPoints.Add(new Vector3(_projectile.transform.position.x, _projectile.transform.position.y, _projectile.transform.position.z));
    }
    public void PrevCalculate(float deltaTime)
    {
        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            _NextPoints[i] = _ProjectilesIngame[i].Calculate(deltaTime);
        }
    }

    public void DoUpdate(float deltaTime)
    {
        for (int i = 0; i < _ProjectilesIngame.Count; i++)
        {
            _ProjectilesIngame[i].transform.position = _NextPoints[i];
        }
    }

    public void FixedUpdate()
    {
        PrevCalculate(Time.deltaTime);
        DoUpdate(Time.deltaTime);
    }
}
