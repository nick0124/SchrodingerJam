using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _smoothing = 5f;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 8f, -9f);
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;

    void FixedUpdate()
    {
        Vector3 targetCamPos = _player.position + _offset;
        _camera.position = Vector3.Lerp(_camera.position, targetCamPos, _smoothing * Time.deltaTime);
    }
}
