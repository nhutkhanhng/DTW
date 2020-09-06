using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assailant : MonoBehaviour
{
    public CollisionData _Collision;
    public DamagedData _Data;
}

public class SystemCalculateDamaged : Singleton<SystemCalculateDamaged>
{
    public List<HitInfoData> HitInfoAfterCollision = new List<HitInfoData>();

    public void ReceiveFromCollision(List<HitInfoData> _Collision)
    {
        HitInfoAfterCollision.AddRange(_Collision);
    }


}