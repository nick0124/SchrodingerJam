using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.DecreaseHealth(_damage);
        }
        Instantiate(_explosionPrefab, transform.position, transform.rotation, null);
        Destroy(gameObject);
    }
}
