using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable
{
    public int MaxHealth;

    protected int _CurrentHP;

    public int CurrentHP
    {
        get
        {
            return _CurrentHP;
        }

        set
        {
            OnHpChanged(_CurrentHP, value);
        }
    }

    public virtual int OnHpChanged(int Prev, int Current)
    {
        _CurrentHP = Current;

        return Current - Prev;
    }
}
