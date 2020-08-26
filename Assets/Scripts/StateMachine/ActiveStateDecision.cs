using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/ActiveState")]
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return (controller.chaseTarget != null);
        }
    }
}