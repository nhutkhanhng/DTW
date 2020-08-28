using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public List<MovementData> _AllDataMovement = new List<MovementData>();
    const float minPathUpdateTime = .2f;
    const float pathUpdateMoveThreshold = .5f;

    public Dictionary<Unit, IEnumerator> _ThreadingPathfinding = new Dictionary<Unit, IEnumerator>();

    public void DoUpdateMovement(float deltaTime)
    {

    }

    public void InitPath(List<Unit> _AllUnits)
    {
        for (int i = 0; i < _AllUnits.Count; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
