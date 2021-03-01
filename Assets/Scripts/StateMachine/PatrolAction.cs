using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
    public class PatrolAction : Action
    {
        public override void Act(StateController controller)
        {
            Patrol(controller);
        }

        private void Patrol(StateController controller)
        {
            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            float turn = controller.enemyStats.searchingTurnSpeed * Time.deltaTime;

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        }
    }
}
