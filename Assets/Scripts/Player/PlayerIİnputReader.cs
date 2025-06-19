using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerControls controls;
    private PlayerMover mover;

    private void Awake()
    {
        controls = new PlayerControls();
        mover = GetComponent<PlayerMover>();

        controls.Gameplay.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Gameplay.Move.canceled += ctx => Move(Vector2.zero);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Move(Vector2 input)
    {
        mover.Move(input);
    }
}

