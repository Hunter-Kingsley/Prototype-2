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
    public InputAction playerBounce;
    public Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 5f;
    public float gravityValue = -5.0f;
    public float maxGravity = -7.0f;
    public float bounceStrength = 5.0f;
    public float bounceCooldown = 0.25f;
    public float bounceTimer = 0.0f;

    // Enable/Disable player controls
    private void OnEnable()
    {
        playerControls.Enable();
        playerBounce.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
        playerBounce.Disable();
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
        if (bounceTimer < bounceCooldown)
        {
            bounceTimer += Time.deltaTime;
        }

        moveDirection = playerControls.ReadValue<Vector2>();
       currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        // You can add physics-related state updates here if needed
        currentState.FixedUpdateState(this);

        // apply gravity
        rb.AddForce(new Vector3(0, gravityValue, 0), ForceMode.Acceleration);
        //Debug.Log(rb.linearVelocity.y);

        if (rb.linearVelocity.y < maxGravity)
        {
            rb.linearVelocity = new Vector3(0, maxGravity, 0);
        }
    }

    // Transsition to a new state
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
