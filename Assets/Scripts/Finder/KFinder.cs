using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KDamageable : MonoBehaviour
{

}

public class KFinder : MonoBehaviour
{
    public CollisionData _Rada;


    public List<KDamageable> Review()
    {
        return CollisionManager.Instance.Collision(_Rada);
    }
}