using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAlignment;


namespace KDamaged
{
    public interface IDamageable
    {
        bool TakeDamage(float Damage, IAlignmentProvider _DamageAlignment, out HealthChangeInfo output);
    }
}