using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private InputActionReference _moveAction;

    private Rigidbody _rigidbody;
    private float _horizontalDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalDirection = _moveAction.action.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = Vector3.right * _horizontalDirection * _speed;
    }
}
