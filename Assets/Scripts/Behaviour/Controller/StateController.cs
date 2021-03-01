using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public AttackState _CurrentSate;
    public Launcher _Launcher;

    public List<Transform> _AllEnemies;
    public void Start()
    {
        _CurrentSate = new AttackState()
        {
            _DataExecute = new AttackExecuteData()
            {
                _Data = new AttackData()
                {
                    Amount = 1,
                    EmitPerWave = 1,
                    Interval = 1f
                }
            },
            _Attack = new RocketAttack(),
            _Launcher = this._Launcher,
            _AllEnemies = this._AllEnemies,
        };
    }

    public void Update()
    {
        _CurrentSate.DoUpdate(this);
    }
}
