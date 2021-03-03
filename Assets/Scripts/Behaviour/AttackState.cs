using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AttackBehaviour
{
    public abstract void OnInit();

    public abstract void DoEnter(AttackState _State);

    public abstract void DoUpdate(AttackState _State);

    public abstract void DoExit(AttackState _State);

    public abstract void DoInterrup(AttackState _State);

    public abstract void DoLaunch(AttackState _State);

    public abstract void OnDestroy();
}
