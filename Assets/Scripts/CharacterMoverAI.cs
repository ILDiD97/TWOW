using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoverAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _stoppingDistance;
    private Vector3 _targetPoint;
    [SerializeField] private bool _moving = false;
    private bool AtTarget 
    {get => Vector3.Distance(transform.position, _targetPoint) <=
    _stoppingDistance;}
    public void MoveToPoint(Vector3 point)
    {
        if (_moving) return;
        _agent.isStopped = false;
        _agent.SetDestination(point);
        _moving = true;
        _targetPoint = point;
    }
    
    public bool TryOnCalculatePath (Vector3 position, out Vector3[] points, out float lenght)
    {
        points = new Vector3[0];
        lenght = 0;
        NavMeshPath path = new NavMeshPath();
        _agent.CalculatePath(position, path);
        bool pathComplete = path.status == NavMeshPathStatus.PathComplete;
        if (pathComplete)
        {
            points = path.corners;
        }
        return pathComplete;
    }

    private void Update()
    {
        if (_moving)
        {
            if (AtTarget)
            {
                _moving = false;
                _agent.isStopped = true;
            }
        }
    }
}
