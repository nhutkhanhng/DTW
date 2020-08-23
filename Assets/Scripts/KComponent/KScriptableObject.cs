using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KScriptableObject : ScriptableObject
{
    public virtual object DeepCopy()
    {
        return UnityEngine.Object.Instantiate(this);
    }
}
