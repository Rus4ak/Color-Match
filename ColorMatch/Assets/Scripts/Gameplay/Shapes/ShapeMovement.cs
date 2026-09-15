using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    private float _fallSpeed;
    private Rigidbody _rigidbody;

    private bool _isFalling = true;

    public void Initialize(float fallSpeed)
    {
        _fallSpeed = fallSpeed;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFalling)
        {
            _isFalling = false;
            _rigidbody.useGravity = true;
        }
    }

    private void FixedUpdate()
    {
        if (!_isFalling) return;

        _rigidbody.linearVelocity = new Vector3(
            _rigidbody.linearVelocity.x,
            -_fallSpeed,
            0);
    }
}
