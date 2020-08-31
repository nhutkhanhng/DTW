using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public List<Projectile> _ProjectilesIngame = new List<Projectile>();

    //public void DoUpdate(float deltaTime)
    //{
    //    for(int i = 0; i < _ProjectilesIngame.Count; i++)
    //    {
    //        _ProjectilesIngame[i].transform.position = _ProjectilesIngame[i]._Movement.NextPoint()
    //    }
    //}
}
