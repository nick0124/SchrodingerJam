using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _whatIsPlayer;
    private NavMeshAgent _agent;

    [SerializeField] private Transform[] _waypoints;

    private Vector3 _destinationPoint;
    private bool _destinationPointIsSet;

    [SerializeField] private float _detectionRange, _stopRange = 10;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool playerInDetectionRange = Physics.CheckSphere(transform.position, _detectionRange, _whatIsPlayer);
        bool playerInStopRange = Physics.CheckSphere(transform.position, _stopRange, _whatIsPlayer);

        if (!playerInDetectionRange && !playerInStopRange)
        {
            Patroling();
        }
        if (playerInDetectionRange && !playerInStopRange)
        {
            ChasePlayer();
        }
        if (playerInDetectionRange && playerInStopRange)
        {
            StopMoving();
        }
    }

    private void Patroling()
    {
        if (!_destinationPointIsSet)
        {
            RandomWaypoint();
        }

        if (_destinationPointIsSet)
        {
            _agent.SetDestination(_destinationPoint);
        }

        Vector3 distanceToDestinationPoint = transform.position - _destinationPoint;

        if (distanceToDestinationPoint.magnitude < 1f)
        {
            _destinationPointIsSet = false;
        }
    }

    private void RandomWaypoint()
    {
        Vector3 currentWaypoint = _waypoints[Random.Range(0, _waypoints.Length)].position;
        _destinationPoint = new Vector3(currentWaypoint.x, transform.position.y, currentWaypoint.z);
        _destinationPointIsSet = true;
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void StopMoving()
    {
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);
    }
}
