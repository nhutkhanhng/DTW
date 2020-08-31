using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAlignment
{
    [CreateAssetMenu(fileName = "Alignment.asset", menuName = "StarterKit/Simple Alignment", order = 1)]
    public class EAlignment : ScriptableObject, IAlignmentProvider
    {
        public List<EAlignment> opponents;

        public bool CanHarm(IAlignmentProvider other)
        {
            var otherAlignment = other as EAlignment;
            return otherAlignment != null && opponents.Contains(otherAlignment);
        }
    }
}
