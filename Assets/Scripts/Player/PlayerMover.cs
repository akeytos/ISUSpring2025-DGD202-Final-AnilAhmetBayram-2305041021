using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        // X = sağ/sol, Z = ileri/geri → Unity 3D yönlendirmesi
        Vector3 move = new Vector3(input.x, 0f, input.y);
        rb.linearVelocity = move * moveSpeed;
    }

    // Diğer scriptler (örneğin PlayerAnimator) buradan erişebilir
    public float MoveSpeed => moveSpeed;
}

