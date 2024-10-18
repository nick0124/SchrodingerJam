using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAim : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsGround;
    private Rigidbody _rigidBody;
    private Ray _mouseRay;
    private RaycastHit _hit;
    private Vector3 _lookDirection = Vector3.forward;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_mouseRay, out _hit, 100f, _whatIsGround))
        {
            Vector3 lookPoint = _hit.point - transform.position;
            _lookDirection.Set(lookPoint.x, 0, lookPoint.z);
        }
    }

    void FixedUpdate()
    {
        _rigidBody.MoveRotation(Quaternion.LookRotation(_lookDirection));
    }
}
