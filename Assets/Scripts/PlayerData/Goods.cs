using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Goods
{
    public int Gold;
}
public class PlayerData
{
    public Goods _Goods;

    public int Gold { get { return _Goods.Gold; } set { _Goods.Gold = value; } }
}
