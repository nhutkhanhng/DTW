using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public AttackState _CurrentSate;
    public Launcher _Launcher;

    public List<Transform> _AllEnemies;
    public BulletSetting _Bullet;

    public void Start()
    {
        _CurrentSate = new AttackState()
        {
            _DataExecute = new AttackState.AttackExecuteData()
            {
                _Data = new AttackData() { Amount = 1, DelayTime = 0, EmitPerWave = 1 , Interval = 0.1f}
            },
            _Attack = new RocketAttack(),
            _Launcher = this._Launcher,
            _AllEnemies = this._AllEnemies,
            _Bullet = this._Bullet
        };
    }

    public void Update()
    {
        _CurrentSate.DoUpdate(this);
    }
}
