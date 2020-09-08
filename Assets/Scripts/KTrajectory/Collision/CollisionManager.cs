using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HitInfoData
{
    public CollisionData _Data;
    public List<CollisionData> _BeHiited;
}
public class CollisionManager : MonoSingleton<CollisionManager>
{
    public List<CollisionData> AllCollisionsData = new List<CollisionData>();

    public List<HitInfoData> _Hits = new List<HitInfoData>();

    public List<KDamageable> Collision(CollisionData _Data)
    {
        List<KDamageable> Result = new List<KDamageable>();

        for(int i = 0; i < AllCollisionsData.Count; i++)
        {
            if (AllCollisionsData[i].Equals(_Data))
                continue;

            var _caching = AllCollisionsData[i];

            Vector3 _Direction;
            float Distance = 0f;

            if (Physics.ComputePenetration(_Data._ColliderData, _Data.Position, _Data.Rotation,
                                            _caching._ColliderData, _caching.Position, _caching.Rotation,
                                            out _Direction, out Distance))
            {
                Result.Add(_caching.GetComponent<KDamageable>());
            }
        }

        return Result;
    }

    public List<HitInfoData> DoUpdate(float deltaTime)
    {
        List<HitInfoData> Result = new List<HitInfoData>();
        for (int i = 0; i < AllCollisionsData.Count; i++)
        {
            var _Data = AllCollisionsData[i];
            List<CollisionData> _collisions = new List<CollisionData>();

            for (int j = 0; j < AllCollisionsData.Count; j++)
            {
                var _caching = AllCollisionsData[j];

                if (_caching.Equals(_Data))
                    continue;

                Vector3 _Direction;
                float Distance = 0f;

                if (Physics.ComputePenetration(_Data._ColliderData, _Data.Position, _Data.Rotation,
                                                _caching._ColliderData, _caching.Position, _caching.Rotation,
                                                out _Direction, out Distance))
                {
                    _collisions.Add(_caching.GetComponent<CollisionData>());
                }
            }

            if(_collisions.Count > 0)
            {
                Result.Add(new HitInfoData() { _Data = _Data, _BeHiited = _collisions });
            }
        }

        return Result;
    }

    public void Update()
    {
        this._Hits = DoUpdate(Time.deltaTime);
    }
}
