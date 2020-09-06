using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HpComponent
{
    public int Hp;
    public int MaxHP;
}

public struct MovementComponent
{
    public float Speed;
    public float MaxSpeed;
}

public struct RotationConponent
{
    public float TurnSpeed;
    public float TurnDst;
}

public class ModelComponent
{
    public Transform Prefab;
} 

public struct PositionComponent
{
    public Vector3 Position;
}

[System.Serializable]
public class EntityInGame
{
    public HpComponent _HpInfo;

    public PositionComponent _PositionInfo;
    public MovementComponent _MovementInfo;

    public RotationConponent _RotationInfo;

    public ModelComponent _ModelInfo;
}