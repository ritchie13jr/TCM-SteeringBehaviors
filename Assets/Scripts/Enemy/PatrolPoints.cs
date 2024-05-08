using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] _patrolPoints;

    public Transform CurrentPoint => _patrolPoints[_currentPoint];

    private int _currentPoint = 0;

    public Transform GetNext()
    {
        var point = _patrolPoints[_currentPoint];
        _currentPoint = (_currentPoint + 1) % _patrolPoints.Length;
        return point;
    }

    public bool HasReached(PatrollingAgent agent)
    {
        return agent.HasReachedDestination;
    }
}

