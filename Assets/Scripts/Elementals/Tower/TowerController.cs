using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerData
{
    public byte Level;
    public Transform Prefab;
}

public enum ETowerStatus
{
    Building,
    Destroying,


    Idle,
    Attacking,
    Looking,
}

public class TowerController : StateController
{
    public State _CurrentState;

    public int Level;
    public AttackState Attacker;

    [ContextMenu("Launch")]
    public void Attack()
    {
        Attacker._Launcher = _Launcher;
        Attacker._Attack = new RocketAttack();
        Attacker._AllEnemies = AllEnemies;
        // Attacker._Attack.DoLaunch(Attacker);
    }

    public void Awake()
    {
        Attack();
        Attacker.DoEnter(this);
    }
    public void Update()
    {
        Attacker.DoUpdate(this);
    }

}
