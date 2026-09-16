using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private InputActionReference _pointerPositionAction;
    [SerializeField] private InputActionReference _pointerPressAction;

    private Rigidbody _rigidbody;
    private Camera _camera;
    private bool _isDragging;
    private float _targetX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _pointerPressAction.action.started += StartDrag;
        _pointerPressAction.action.canceled += EndDrag;

        _pointerPositionAction.action.Enable();
        _pointerPressAction.action.Enable();
    }

    private void OnDisable()
    {
        _pointerPressAction.action.started -= StartDrag;
        _pointerPressAction.action.canceled -= EndDrag;

        _pointerPositionAction.action.Disable();
        _pointerPressAction.action.Disable();
    }

    private void Update()
    {
        if (!_isDragging)
            return;

        Vector2 pointerPosition = _pointerPositionAction.action.ReadValue<Vector2>();

        Ray ray = _camera.ScreenPointToRay(pointerPosition);

        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);

            _targetX = Mathf.Clamp(worldPosition.x, -10f, 10f);
        }
    }

    private void FixedUpdate()
    {
        if (!_isDragging)
            return;

        float newX = Mathf.MoveTowards(
            _rigidbody.position.x,
            _targetX,
            _moveSpeed * Time.fixedDeltaTime
        );

        Vector3 position = _rigidbody.position;
        position.x = newX;

        _rigidbody.MovePosition(position);
    }

    private void StartDrag(InputAction.CallbackContext context)
    {
        Vector2 pointerPosition = _pointerPositionAction.action.ReadValue<Vector2>();

        Ray ray = _camera.ScreenPointToRay(pointerPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform != transform)
                return;

            _isDragging = true;
        }
    }

    private void EndDrag(InputAction.CallbackContext context)
    {
        _isDragging = false;
    }
}
