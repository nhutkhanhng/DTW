﻿using Core.Utilities;
using KTrajectory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAlignment;


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


    protected void Launch(List<Transform> _Targets, AttackState _Controller)
    {
        if (Amount <= 150)
        {
            for (int i = 0; i < _Targets.Count; i++)
            {
                var _newBullet = new Projectile();

                _newBullet._VFX.Vfx = Poolable.TryGetPoolable(_Controller._Bullet._VFX);
                Amount++;
                _newBullet._VFX.Vfx.transform.localScale = _Controller._Bullet.LocalScale;
                _newBullet._VFX.Vfx.name = "Bullet-" + Amount;
                _newBullet.alignment = _Controller.alignment;

                _newBullet.Start(_Controller._Launcher.Owner, _Controller._Launcher.PositionInit.position, _Targets[i].transform,
                    _newBullet._VFX.Vfx.GetComponent<CollisionData>());
            }
        }
        //else
        //    Debug.Break();
    }

    public override void DoUpdate(AttackState _controller)
    {
        if(_controller._DataExecute.IsCanAttack())
        {
            Launch(_controller._AllEnemies, _controller);
            _controller._DataExecute._Amount++;
        }
    }

    public override void OnDestroy()
    {
        
    }

    public override void OnInit()
    {
        
    }
}
