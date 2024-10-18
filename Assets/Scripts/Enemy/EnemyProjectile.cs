using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int _damage;

    void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.DecreaseHealth(_damage);
        }
        Destroy(gameObject);
    }
}
