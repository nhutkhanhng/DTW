using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackData
{
    public float DelayTime;

    public float Interval;

    public float Amount;

    public float EmitPerWave;
}

public abstract class AttackBehaviour
{
    public abstract void OnInit();

    public abstract void DoEnter(AttackState _controller);

    public abstract void DoUpdate(AttackState _controller);

    public abstract void DoExit(AttackState _Controller);

    public abstract void DoInterrup(AttackState _Controller);

    public abstract void OnDestroy();
}
