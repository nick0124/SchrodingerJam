using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;

    public void DecreaseHealth(int healthToDecrease)
    {
        _health -= healthToDecrease;
        if (_health < 0)
        {
            Debug.Log("falure");
        }
    }
}
