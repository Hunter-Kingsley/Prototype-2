using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{
    // State pattern implementation
    MovementBaseState currentState;
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public DashState dashState = new DashState();
    public BounceState bounceState = new BounceState();

    // Player components
    public Rigidbody rb;

    // Player controls
    public InputAction playerControls;
    public Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 5f;

    // Enable/Disable player controls
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {   
        // Starting state for the player
        currentState = idleState;
        currentState.EnterState(this); 
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        // You can add physics-related state updates here if needed
        currentState.FixedUpdateState(this);
    }

    // Transsition to a new state
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
