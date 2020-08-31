using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public struct HitInfo
//{

//}
public class CollisionData : MonoBehaviour
{
    public Collider _ColliderData;

    public Vector3 Position
    {
        get { return this.transform.position; }
    }

    public Quaternion Rotation
    {
        get { return this.transform.rotation; }
    }

    private void Awake()
    {
        CollisionManager.Instance.AllCollisionsData.Add(this);
    }
}
