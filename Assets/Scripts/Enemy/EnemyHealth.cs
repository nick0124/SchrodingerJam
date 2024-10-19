using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private int _health;

    public void DecreaseHealth(int healthToDecrease)
    {
        _health -= healthToDecrease;
        if (_health <= 0)
        {
            _playerHealth.RessetHealth();
            Destroy(gameObject);
        }
    }
}
