using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KDamaged
{
    public struct HitInfo
    {
        readonly HealthChangeInfo m_HealthChangeInfo;
        readonly Vector3 m_DamagePoint;

        public HealthChangeInfo healthChangeInfo
        {
            get { return m_HealthChangeInfo; }
        }

        public Vector3 damagePoint
        {
            get { return m_DamagePoint; }
        }

        public HitInfo(HealthChangeInfo info, Vector3 damageLocation)
        {
            m_DamagePoint = damageLocation;
            m_HealthChangeInfo = info;
        }
    }
}