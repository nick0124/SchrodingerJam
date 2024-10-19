using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _shootingRate = 1;
    [SerializeField] private float _projectileSpeed = 10;
    [SerializeField] private float _projectileLifetime = 10;
    public bool Emit { get; set; }

    void Update()
    {
        if (Emit)
        {
            if (!IsInvoking(nameof(SpawnProjectile)))
                InvokeRepeating(nameof(SpawnProjectile), 0, _shootingRate);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void SpawnProjectile()
    {
        GameObject instance = Instantiate(_projectilePrefab, transform.position, transform.rotation, null);
        Destroy(instance, _projectileLifetime);
        Rigidbody instanceRb = instance.GetComponent<Rigidbody>();
        instanceRb.velocity = transform.forward * _projectileSpeed;
    }
}
