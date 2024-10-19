using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _particleprefab;
    [SerializeField] private float _shootingRate = 1;
    [SerializeField] private float _projectileSpeed = 10;
    [SerializeField] private float _projectileLifetime = 10;
    public float _shootingTimer = 0;

    void Update()
    {
        if (Input.GetMouseButton(0) && _shootingTimer <= 0)
        {
            _shootingTimer = _shootingRate;
            SpawnProjectile();
        }

        if (_shootingTimer > 0)
        {
            _shootingTimer -= Time.deltaTime;
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
