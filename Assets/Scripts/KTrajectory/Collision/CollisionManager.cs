using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitInfoData
{
    public CollisionData _Data;
    public List<CollisionData> _BeHitted;
}

public class CollisionManager : MonoSingleton<CollisionManager>
{
    public List<CollisionData> AllCollisionsData = new List<CollisionData>();

    // public List<CollisionData> Projectiles = new List<CollisionData>();

    public List<HitInfoData> _Hits = new List<HitInfoData>();

    public KObjectPool<HitInfoData> _PoolHitInfo = new KObjectPool<HitInfoData>(() => new HitInfoData());

    public List<HitInfoData> DoUpdate(float deltaTime)
    {
        List<HitInfoData> Result = new List<HitInfoData>();
        List<CollisionData> _collisions = new List<CollisionData>();

        Vector3 _Direction;
        float Distance = 0f;

        for (int i = 0; i < AllCollisionsData.Count; i++)
        {
            _collisions.Clear();
            // _collisions = new List<CollisionData>();
            var _Data = AllCollisionsData[i];

            for (int j = 0; j < AllCollisionsData.Count; j++)
            {
                var _caching = AllCollisionsData[j];

                if (_caching.Equals(_Data))
                    continue;



                if (Physics.ComputePenetration(_Data._ColliderData, _Data.Position, _Data.Rotation,
                                                _caching._ColliderData, _caching.Position, _caching.Rotation,
                                                out _Direction, out Distance))
                {
                    _collisions.Add(_caching.GetComponent<CollisionData>());
                }
            }

            if(_collisions.Count > 0)
            {
                for(int iP = 0; iP < _collisions.Count; iP++)
                {
                    Debug.LogError(_Data.transform.name + "  _-- " + _collisions[iP].transform.name);
                }

                Result.Add(new HitInfoData() { _Data = _Data, _BeHitted = _collisions });
            }
        }

        return Result;
    }

    public void Update()
    {
        this._Hits = DoUpdate(Time.deltaTime);
    }
}
