using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.DecreaseHealth(_damage);
        }
        Destroy(gameObject);
    }
}
