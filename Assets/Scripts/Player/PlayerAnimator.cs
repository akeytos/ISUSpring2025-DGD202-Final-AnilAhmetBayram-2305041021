using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerAnimator : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerMover _playerMover;
    [SerializeField] private Transform _mesh;

    private float _moveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Start()
    {
        _moveSpeed = _playerMover.MoveSpeed;
    }

    private void Update()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        float forwardVelocity = Vector3.Dot(velocity, transform.forward);

        // D�nme miktar�n� h�zla do�ru orant�l� yap
        if (Mathf.Abs(forwardVelocity) > 0.01f)
        {
            float rotationSpeed = forwardVelocity * 50f; // 10 ile �arparsan daha fazla d�ner
            _mesh.localRotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
}
