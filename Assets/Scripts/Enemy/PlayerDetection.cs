using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private float _detectionDistance = 5;

    [SerializeField] private EnemyProjectileSpawner[] _enemyProjectileSpawners;

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, _detectionDistance, _whatIsPlayer))
        {
            foreach (EnemyProjectileSpawner item in _enemyProjectileSpawners)
            {
                item.Emit = true;
            }
        }
        else
        {
            foreach (EnemyProjectileSpawner item in _enemyProjectileSpawners)
            {
                item.Emit = false;
            }
        }
    }
}
