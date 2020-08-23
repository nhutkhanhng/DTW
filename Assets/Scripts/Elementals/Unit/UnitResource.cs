using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Units/Resources", fileName = "UnitResource")]
public class UnitResource : ScriptableObject
{
    public Transform[] _Prefabs;
}