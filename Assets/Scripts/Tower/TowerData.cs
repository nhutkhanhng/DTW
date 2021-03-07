using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public struct _TowerDataInBattle
{
    public float AttackRange;
    public float AttackDamged;
}

[CreateAssetMenu(menuName = "Data/Tower", fileName = "TowerData")]
public class TowerData : ScriptableObject
{
    public byte ID;
    public Image _ImgTower;
    public byte Cost;

    public _TowerDataInBattle Info;
}

