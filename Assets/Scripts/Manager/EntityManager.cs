using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public Entity _Config;

    public UnitResource _UnitResource;

    public List<EntityInGame> Entites = new List<EntityInGame>();

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
    public Transform CreateEntity(EntityInfo Info)
    {
        var newObject = UnityEngine.GameObject.Instantiate(_FindResource(_Config._Info._UnitInfo.Prefab));

        EntityInGame _Entity = new EntityInGame();
        _Entity.Setup(_Config, this.PositionToSpawn);

        _Entity._ModelInfo = new ModelComponent() { Prefab = newObject };

        newObject.position = this.PositionToSpawn;

        this.Entites.Add(_Entity);

        return newObject;
    }

    public GameObject Despawn(GameObject _Object)
    {
        //  Implement after;
        return _Object;
    }
}
