using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace KStateMachine
{
    /// <summary>
    ///  This class is a abstract class.
    ///  That controll all action that generable after
    /// </summary>
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}