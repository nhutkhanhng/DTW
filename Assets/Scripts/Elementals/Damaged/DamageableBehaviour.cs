using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using KAlignment;

namespace KDamaged
{
    // The truth of me. --- I dont wanna use mono.
    public class DamageableBehaviour : KDamageable
    {
		public Damageable configuration;

        public bool IsDead
        {
            get { return configuration.IsDead; }
        }

        public virtual Vector3 position
        {
            get { return transform.position; }
        }

        public virtual void TakeDamage(float damageValue, Vector3 damagePoint, IAlignmentProvider alignment)
        {
            HealthChangeInfo info;
            configuration.TakeDamage(damageValue, alignment, out info);
            var damageInfo = new HitInfo(info, damagePoint);
        }

        protected virtual void Kill()
        {
            HealthChangeInfo healthChangeInfo;
            configuration.TakeDamage(configuration.currentHealth, null, out healthChangeInfo);
        }

        public virtual void Remove()
        {
            configuration.SetHealth(0);
        }
    }
}
