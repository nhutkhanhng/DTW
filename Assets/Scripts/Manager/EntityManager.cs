using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public Entity _Config;

    public UnitResource _UnitResource;

    public List<Entity> _EntityIngame = new List<Entity>();

    public Vector3 PositionToSpawn;

    protected Transform _FindResource(string Name)
    {
        Transform Result = null;
        for(int i = 0; i < _UnitResource._Prefabs.Length; i++)
        {
            if(Name.Equals(_UnitResource._Prefabs[i]))
            {
                return _UnitResource._Prefabs[i];
            }
        }

        return Result;
    }

    protected Transform _FindResource(Transform _Object)
    {
        Transform Result = null;
        for (int i = 0; i < _UnitResource._Prefabs.Length; i++)
        {
            if (_Object.Equals(_UnitResource._Prefabs[i]))
            {
                return _UnitResource._Prefabs[i];
            }
        }

        return Result;
    }

    /// <summary>
    ///  Việc Caching cần đưcọ xem xét
    /// </summary>
    [ContextMenu("Create")]
    public Transform CreateEntity()
    {
        var newObject = UnityEngine.GameObject.Instantiate(_FindResource(_Config._UnitInfo.Prefab));
        newObject.position = _Config._Transform.Position;

        return newObject;
    }

    public GameObject Despawn(GameObject _Object)
    {
        //  Implement after;
        return _Object;
    }
}
