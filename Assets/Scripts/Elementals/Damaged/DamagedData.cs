using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum DmgType
{
    Physic,
    Magic,
    Pure
}

public class EffectOnBasicAttack
{

}
public struct DamagedData
{
    public DmgType _DamgeType;
    public float _Value;
    public bool _IsCritical;

    public List<EffectOnBasicAttack> _Effects;
}
