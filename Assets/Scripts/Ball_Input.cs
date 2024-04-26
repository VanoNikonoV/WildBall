using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Input : MonoBehaviour
{
    private IControllable controllable;
    private PlayerInput actions;
    private float directionX, directionY;
    private Vector3 direction;
    private Vector2 moveVector;

    private void Awake()
    {
        controllable = GetComponent<IControllable>();
        if (controllable == null)
        {
            throw new System.Exception($"There is no IControllable component on the object: {gameObject.name}");
        }
        actions = new PlayerInput();

        actions.Player.Jump.performed += OnJump;
    }
    private void FixedUpdate()
    {
        ReadMovement();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       controllable.Jump();
    }
    private void ReadMovement()
    {
        moveVector = actions.Player.Move.ReadValue<Vector2>();
        directionX = moveVector.x;
        directionY = moveVector.y;
        direction = new Vector3(directionY, 0.0f, -directionX);
        controllable.Move(direction);
    }

    private void OnEnable() { actions.Player.Enable(); }
    private void OnDisable() { actions.Player.Disable(); }
}
