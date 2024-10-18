using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    private Rigidbody _rigidBody;
    private Vector3 _moveDirection = Vector3.zero;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _moveDirection.Set(horizontal, 0, vertical);
    }

    void FixedUpdate()
    {
        _rigidBody.MovePosition(transform.position + _moveDirection.normalized * _speed * Time.deltaTime);
    }
}
