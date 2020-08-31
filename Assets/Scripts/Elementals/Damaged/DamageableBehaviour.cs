using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using KAlignment;

namespace KDamaged
{
    // The truth of me. --- I dont wanna use mono.
    public class DamageableBehaviour : MonoBehaviour
    {
		public Damageable configuration;


        public bool IsDead
        {
            get { return configuration.IsDead; }
        }

        /// <summary>
        /// The position of the transform
        /// </summary>
        public virtual Vector3 position
        {
            get { return transform.position; }
        }

        /// <summary>
        /// Occurs when damage is taken
        /// </summary>
        public event Action<HitInfo> _OnHit;

        /// <summary>
        /// Event that is fired when this instance is removed, such as when pooled or destroyed
        /// </summary>
        public event Action<DamageableBehaviour> _OnRemoved;

        /// <summary>
        /// Event that is fired when this instance is killed
        /// </summary>
        public event Action<DamageableBehaviour> _OnDied;

        public virtual void TakeDamage(float damageValue, Vector3 damagePoint, IAlignmentProvider alignment)
        {
            HealthChangeInfo info;
            configuration.TakeDamage(damageValue, alignment, out info);
            var damageInfo = new HitInfo(info, damagePoint);

            if (_OnHit != null)
            {
                _OnHit(damageInfo);
            }
        }

        protected virtual void Awake()
        {
            configuration.Init();
            configuration._OnDied += OnConfigurationDied;
        }

        /// <summary>
        /// Kills this damageable
        /// </summary>
        protected virtual void Kill()
        {
            HealthChangeInfo healthChangeInfo;
            configuration.TakeDamage(configuration.currentHealth, null, out healthChangeInfo);
        }


        /// <summary>
        /// Removes this damageable without killing it
        /// </summary>
        public virtual void Remove()
        {
            // Set health to zero so that this behaviour appears to be dead. This will not fire death events
            configuration.SetHealth(0);
            OnRemoved();
        }

        /// <summary>
        /// Fires kill events
        /// </summary>
        void OnDeath()
        {
            if (_OnDied != null)
            {
                _OnDied(this);
            }
        }

        void OnRemoved()
        {
            if (_OnRemoved != null)
            {
                _OnRemoved(this);
            }
        }

        void OnConfigurationDied(HealthChangeInfo changeInfo)
        {
            OnDeath();
            Remove();
        }
    }
}
