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

public class TowerController : MonoBehaviour
{
    public State _CurrentState;

    public int Level;


    public AttackState Attacker;
}
