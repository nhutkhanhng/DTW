using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoSingleton<TowerManager>
{
    public List<TowerController> Attacking = new List<TowerController>();
    public List<TowerController> Pursuing = new List<TowerController>();
    public List<TowerController> Resting = new List<TowerController>();

    public void DoUpdate(float deltaTime)
    {

    }
}
