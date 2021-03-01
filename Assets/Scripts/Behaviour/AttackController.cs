using KAlignment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void DoUpdate(StateController _Contoller);
    public abstract void DoEnter(StateController _Controller);
    public abstract void DoExit(StateController _Controller);

    public abstract void DoInterrup(StateController _Controller);
}


public static class AttackExecuteExtension
{
    public static bool IsCanAttack(this AttackExecuteData _Execute)
    {
        return _Execute.CurrentTime >= _Execute._Data.Interval * _Execute._Amount;
    }
}
[System.Serializable]
public class AttackExecuteData
{
    public AttackData _Data;

    [System.NonSerialized] public float _AmountPerWave = 0;
    [System.NonSerialized] public float _Amount = 0;
    [System.NonSerialized] public float CurrentTime = 0;
}

[System.Serializable]
public class Launcher
{
    public Transform Owner;
    public Transform PositionInit;
}

[System.Serializable]
public class AttackState : State
{
    public AttackExecuteData _DataExecute;
    public AttackBehaviour _Attack;

    public GameObject BulletVfx;

    /*[System.NonSerialized]*/ public SerializableIAlignmentProvider alignment;
    public List<Transform> _AllEnemies { get; set; }

    [System.NonSerialized] public Launcher _Launcher;

    public override void DoEnter(StateController _Controller)
    {
        _Attack.DoEnter(this);
    }

    public override void DoUpdate(StateController _controller)
    {
        if (_DataExecute.IsCanAttack())
        {
            _Attack.DoLaunch(this);
            _DataExecute._Amount++;
        }

        _Attack.DoUpdate(this);
        this._DataExecute.CurrentTime += Time.deltaTime;
    }   

    public override void DoExit(StateController _controller)
    {
        _Attack.DoExit(this);
    }

    public override void DoInterrup(StateController _controller)
    {
        _Attack.DoInterrup(this);
    }    
}
