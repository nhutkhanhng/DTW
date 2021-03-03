using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackData
{
    public float Interval;

    public float Amount;

    public float EmitPerWave;
}

[System.Serializable]
public struct VfxSetting
{
    public GameObject Vfx;
    public Vector3 Scale;
}

[System.Serializable]
public class AttackExecuteData
{
    public AttackData _Data;

    [System.NonSerialized] public float _AmountPerWave = 0;
    [System.NonSerialized] public float _Amount = 0;
    [System.NonSerialized] public float CurrentTime = 0;

    public VfxSetting _Bullet;
    public VfxSetting _VfxHit;
}
