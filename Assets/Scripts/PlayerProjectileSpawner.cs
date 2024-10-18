using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particleprefab;
    [SerializeField] private float _shootingRate = 1;
    [SerializeField] private float _projectileSpeed = 10;
    [SerializeField] private float _projectileLifetime = 20;
    private float _shootingTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_shootingTimer <= 0)
            {
                _shootingTimer = _shootingRate;
                SpawnProjectile();
            }
            else
            {
                _shootingTimer -= Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _shootingTimer = 0;
        }
    }

    private void SpawnProjectile()
    {
        GameObject instance = Instantiate(_particleprefab, transform.position, transform.rotation, null);
        Destroy(instance, _projectileLifetime);
        Rigidbody instanceRb = instance.GetComponent<Rigidbody>();
        instanceRb.velocity = transform.forward * _projectileSpeed;
    }
}
