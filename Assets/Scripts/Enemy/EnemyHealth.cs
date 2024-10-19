using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;

    public void DecreaseHealth(int healthToDecrease)
    {
        _health -= healthToDecrease;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
