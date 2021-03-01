using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asset/Unit/MovementData", fileName = "MoveMentData")]
public class MovementData : KScriptableObject
{
    public float Speed;
    public float MaxSpeed;

    public float TurnSpeed;
    public float TurnDst;
}