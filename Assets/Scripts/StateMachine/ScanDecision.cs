﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Scan")]
    public class ScanDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            bool noEnemyInSight = Scan(controller);
            return noEnemyInSight;
        }

        private bool Scan(StateController controller)
        {
            controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
            return controller.CheckIfCountDownElapsed(controller.enemyStats.searchDuration);
        }
    }
}