using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
    public class LookDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool targetVisible = Look(controller);
            return targetVisible;
        }

        private bool Look(StateController controller)
        {
            #region Rotation partRoTation
            #endregion
            RaycastHit hit;

            if (controller.chaseTarget == null)
            {
                //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                //float shortestDistance = Mathf.Infinity;

                //GameObject nearestEnemy = null;

                //foreach (GameObject enemy in enemies)
                //{
                //    float distanceToEnemy = Vector3.Distance(controller.Tower.transform.position, enemy.transform.position);
                //    if (distanceToEnemy < shortestDistance)
                //    {
                //        shortestDistance = distanceToEnemy;
                //        nearestEnemy = enemy;
                //    }
                //}

                //if (nearestEnemy != null && shortestDistance <= controller.enemyStats.lookRange)
                //{
                //    controller.chaseTarget = nearestEnemy.GetComponent<Enemy>();
                //    controller.Tower.targetEnemy = controller.chaseTarget;
                //    controller.Tower.target = nearestEnemy.transform;

                //    return true;
                //}
                //else
                //{
                //    controller.Tower.target = null;
                //    return false;
                //}
            }

            return false;
        }
    }
}