using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInGame : MonoSingleton<UIInGame>
{
    public Grid _GridTower;

    public List<UITower> _Towers = new List<UITower>();

    public void RequestBuyTower(int IdTower, Vector2Int Position)
    {

    }
}




public class _Logic
{
    public PlayerData _Player = new PlayerData() { _Goods = new Goods() { Gold = 5 } };

    public bool IsCanBuy(int IdTower)
    {
        if (_Player.Gold > 0)
        {

            return true;
        }

        return false;
    }

    public bool BuyTower(int IdTower, Vector2Int Position)
    {



        return true;
    }
}


public class RespondBuildTower
{
    public byte IdTower;
    public Vector2Int Grid;
}

public static class Logic
{
    public  static _Logic __Logics = new _Logic();

    public static bool BuyTower(byte IdTower)
    {
        if (__Logics.IsCanBuy(IdTower) == false)
            return false;

        return true;
    }

    public static bool RequestBuildTower(byte IdTower, Vector2Int Grid)
    {
        if (__Logics.BuyTower(IdTower, Grid))
        {


            return true;
        }

        return false;
    }
}