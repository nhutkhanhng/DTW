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

        public float normalisedHealth
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
        public bool isDead
        {
            get { return currentHealth <= 0f; }
        }
        public bool isAtMaxHealth
        {
            get { return Mathf.Approximately(currentHealth, maxHealth); }
        }

        // events
        public event Action reachedMaxHealth;
        public event Action<HealthChangeInfo> damaged, healed, died, healthChanged;

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

            if (healthChanged != null)
            {
                healthChanged(info);
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

            if (isDead || !canDamage)
            {
                return false;
            }

            ChangeHealth(-damage, output);
            damaged?.Invoke(output);

            if (isDead)
            {
                died?.Invoke(output);
            }

            return true;
        }


        public HealthChangeInfo IncreaseHealth(float health)
        {
            var info = new HealthChangeInfo { damageable = this };

            ChangeHealth(health, info);
            healed?.Invoke(info);

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

            if (healthChanged != null)
            {
                healthChanged(info);
            }
        }
    }
}