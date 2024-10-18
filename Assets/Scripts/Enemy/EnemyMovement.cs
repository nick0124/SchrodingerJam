using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _whatisGround, _whatIsPlayer;
    private NavMeshAgent _agent;

    private Vector3 _destinationPoint;
    private bool _destinationPointIsSet;
    [SerializeField] private float _walkPointRange = 10;

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
            FindNextDestanationPoint();
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

    private void FindNextDestanationPoint()
    {
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_destinationPoint, -transform.up, 2f, _whatisGround))
        {
            _destinationPointIsSet = true;
        }
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
