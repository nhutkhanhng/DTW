using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
    public class AttackAction : Action
    {
        public override void Act(StateController controller)
        {
            Attack(controller);
        }

        private void Attack(StateController controller)
        {
            if (controller.chaseTarget != null)
            {

                Vector3 dir = controller.chaseTarget.transform.position - controller.eyes.position;

                Quaternion lookRotation = Quaternion.LookRotation(dir);

                //if (15f >= Quaternion.Angle(lookRotation, Quaternion.LookRotation(controller.eyes.forward))
                //    || 10f > Vector3.Distance(controller.chaseTarget.transform.position, controller.Tower.partToRotate.transform.position))
                //{
                //}

                //Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.blue);
                //Debug.DrawRay(controller.Tower.partToRotate.transform.position, controller.eyes.forward, Color.black);
            }
        }
    }
}