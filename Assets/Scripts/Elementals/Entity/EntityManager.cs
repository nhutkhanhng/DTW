using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core.Utilities;

public class EntityManager : MonoSingleton<EntityManager>
{
    public List<Entity> _Entites = new List<Entity>();


    public void Add(Entity entity)
    {
        _Entites.Add(entity);
    }
    

    public void Remove(Entity entity)
    {
        _Entites.Remove(entity);
    }


    public Entity Create(GameObject Entity)
    {
        var newEntity = Poolable.TryGetPoolable(Entity);

        return newEntity.AddComponent<Entity>();
    }
}
