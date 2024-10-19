using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;

    void Start()
    {
        Destroy(gameObject,_timeToDestroy);
    }
}
