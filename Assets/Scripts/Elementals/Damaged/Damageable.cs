using UnityEngine;
using System;

using KAlignment;

namespace KDamaged
{

    // DamageAble class for handling health using events.
    [System.Serializable]
    public class Damageable
    {
        public float maxHealth;
        public float startingHealth;

        public SerializableIAlignmentProvider alignment;

        public float currentHealth { protected set; get; }

        public float NormalisedHealth
        {
            get
            {
                // vl vl vl =]]
                if (System.Math.Abs(maxHealth) <= Mathf.Epsilon)
                {
                    Debug.LogError("Max Health is 0");
                    maxHealth = 1f;
                }
                return currentHealth / maxHealth;
            }
        }

        public IAlignmentProvider alignmentProvider
        {
            get
            {
                return alignment != null ? alignment.GetInterface() : null;
            }
        }
        public bool IsDead
        {
            get { return currentHealth <= 0f; }
        }
        public bool isAtMaxHealth
        {
            get { return Mathf.Approximately(currentHealth, maxHealth); }
        }

        // events
        public event Action reachedMaxHealth;
        public event Action<HealthChangeInfo> _OnDamaged, _OnHealed, _OnDied, _HealthChanged;

        public virtual void Init()
        {
            currentHealth = startingHealth;
        }

        public void SetMaxHealth(float health)
        {
            if (health <= 0)
            {
                return;
            }
            maxHealth = startingHealth = health;
        }

        public void SetMaxHealth(float health, float startingHealth)
        {
            if (health <= 0)
            {
                return;
            }
            maxHealth = health;
            this.startingHealth = startingHealth;
        }

        public void SetHealth(float health)
        {
            var info = new HealthChangeInfo { damageable = this, newHealth = health, oldHealth = currentHealth };

            currentHealth = health;

            if (_HealthChanged != null)
            {
                _HealthChanged(info);
            }
        }

        public bool TakeDamage(float damage, IAlignmentProvider damageAlignment, out HealthChangeInfo output)
        {
            output = new HealthChangeInfo
            {
                damageAlignment = damageAlignment,
                damageable = this,
                newHealth = currentHealth,
                oldHealth = currentHealth
            };

            bool canDamage = damageAlignment == null || alignmentProvider == null ||
                             damageAlignment.CanHarm(alignmentProvider);

            if (IsDead || !canDamage)
            {
                return false;
            }

            ChangeHealth(-damage, output);
            _OnDamaged?.Invoke(output);

            if (IsDead)
            {
                _OnDied?.Invoke(output);
            }

            return true;
        }


        public HealthChangeInfo IncreaseHealth(float health)
        {
            var info = new HealthChangeInfo { damageable = this };

            ChangeHealth(health, info);
            _OnHealed?.Invoke(info);

            if (isAtMaxHealth)
            {
                reachedMaxHealth?.Invoke();
            }

            return info;
        }


        protected void ChangeHealth(float healthIncrement, HealthChangeInfo info)
        {
            info.oldHealth = currentHealth;
            currentHealth += healthIncrement;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            info.newHealth = currentHealth;

            if (_HealthChanged != null)
            {
                _HealthChanged(info);
            }
        }
    }
}