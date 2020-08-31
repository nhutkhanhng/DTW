using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core.Utilities;

namespace KTrajectory
{
    public interface ITracjectoryData : ISerializableInterface
    {
        Vector3 BeginPoint { get; }
        Vector3 EndPoint { get; }
    }

    public struct LinearData : ITracjectoryData
    {
        public Vector3 _Begin;
        public Vector3 BeginPoint { get { return _Begin; }
            set { _Begin = value; }
        }

        public Vector3 _End;
        public Vector3 EndPoint { get { return _End; }
            set { _End = value; }
        }

        public LinearData(Vector3 Begin, Vector3 End)
        {
            _Begin = Begin;
            _End = End;
        }
    }
    [System.Serializable]
    public class SerializableTrajectoryData : SerializableInterface<ITracjectoryData>
    {
    }
}