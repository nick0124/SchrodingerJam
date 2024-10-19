using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.transform.GetComponent<EnemyHealth>();
        if (enemyHealth)
        {
            enemyHealth.DecreaseHealth(_damage);
        }
        Instantiate(_explosionPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
