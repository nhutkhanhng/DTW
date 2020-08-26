using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateController controller);
    }
}
