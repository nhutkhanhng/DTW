using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerRegion
{

    //returns true if an entity of the given size and position is intersecting
    //the trigger region.
    public abstract bool isTouching(Vector3 EntityPos, double EntityRadius);
}