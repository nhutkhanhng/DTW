using Core.Utilities;
using KTrajectory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAlignment;

[System.Serializable]
[CreateAssetMenu(menuName = "Behaviour/RocketAttack")]
public class RocketAttack : AttackBehaviour
{
    protected int Amount = 0;
    public override void DoEnter(AttackState _controller)
    {
        Amount = 0;
    }

    public override void DoExit(AttackState _Controller)
    {
        
    }

    public override void DoInterrup(AttackState _Controller)
    {
        
    }

    public override void DoLaunch(AttackState _State)
    {
        _Launch(_State._AllEnemies, _State);
    }

    protected void _Launch(List<Transform> _Targets, AttackState _InfoState)
    {
        for (int i = 0; i < _Targets.Count; i++)
        {
            Amount++;

            var _newBullet = new Projectile();

            _newBullet._Vfx = Poolable.TryGetPoolable(_InfoState.BulletVfx).transform;
            _newBullet._Vfx.name = "Bullet-" + Amount;

            _newBullet.alignment = _InfoState.alignment;

            _newBullet.Start(_InfoState._Launcher.Owner, 
                             _InfoState._Launcher.PositionInit.position,
                             _Targets[i].transform,
                             null);


        }
    }

    public override void DoUpdate(AttackState _controller)
    {
        
    }

    public override void OnDestroy()
    {
        
    }

    public override void OnInit()
    {
        
    }
}
