using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace KTrajectory
{

    [System.Serializable]
    public class KTrajectory : ICloneable
    {
        [System.NonSerialized]
        public Vector3 _Begin;
        [System.NonSerialized]
        public Vector3 _End;


        [System.NonSerialized]
        public float m_Progress;
        public float Progress
        {
            get { return m_Progress; }

            set
            {
                m_Progress = value;
                // todo something.
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public abstract class Trajectory : KTrajectory
    {
        public IMovementType _Movement;

        public ITracjectoryData _Data;

        [System.NonSerialized]
        public float m_Time;

        [System.NonSerialized]
        protected Vector3 m_Current;

        public abstract void DoReached();

        public virtual Vector3 Calculate(float deltaTime)
        {
            m_Time += deltaTime;

            if (_Movement.IsPrevReach(m_Current, _Data, deltaTime))
            {
                // Todo something else.
                // this.m_Current = _Data.EndPoint;
            }
            else
            {
                this.m_Current = _Movement.NextPoint(m_Current, _Data, deltaTime);
            }

            if (IsReached())
            {
                DoReached();
            }

            return this.m_Current;
        }

        public virtual bool IsReached()
        {
            return false;
        }
    }
}