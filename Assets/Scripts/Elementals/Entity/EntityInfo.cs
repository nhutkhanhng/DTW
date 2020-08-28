using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class _MyTransform
{
    public Vector3 Position;
    public Quaternion Rotation;
}

[CreateAssetMenu(menuName = "Asset/Entity/Entity", fileName = "Entity")]
public class EntityInfo : KScriptableObject
{
    public HpInfo _Hp;
    public MovementData _Movement;

    public UnitInfo _UnitInfo;
    [System.NonSerialized]
    public _MyTransform _Transform;
}
