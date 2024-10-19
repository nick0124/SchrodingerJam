using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.transform.GetComponent<EnemyHealth>();
        if (enemyHealth)
        {
            enemyHealth.DecreaseHealth(_damage);
        }
        Destroy(gameObject);
    }
}
