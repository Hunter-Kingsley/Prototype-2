using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Camera components
    [SerializeField] private Transform cameraTransform;

    // Player controls
    public InputActionAsset inputActions;
    private InputActionMap playerActionMap;
    private InputAction moveAction;
    private InputAction dashAction;
    private InputAction escapeAction;
    public InputAction jumpAction;
    //private InputAction playerBounce;

    // Get UI Elements
    public GameObject dashUI;
    public Image dashBar;

    public Vector3 moveDirection = Vector3.zero;
    public float dashing = 0f;
    public float dashMult = 1f;
    public float dashFloor = 1f;
    public float dashCeiling = 10f;
    public float dashChargeSpeed = 5f;
    public float dashSlowdown = .5f;
    public float horizontalMoveSpeed = 5f;
    public float verticalMoveSpeed = 5f;
    public float gravityValue = -5.0f;
    public float maxGravity = -7.0f;
    public float bounceStrength = 10.0f;
    //public float bounceCooldown = 0.25f;
    //public float bounceTimer = 0.0f;
    public float dragValue = 1.0f;
    public string titleScene;

    void Awake()
    {
        playerActionMap = inputActions.FindActionMap("Player");
        moveAction = playerActionMap.FindAction("Move");
        dashAction = playerActionMap.FindAction("Dash");
        jumpAction = playerActionMap.FindAction("Jump");
        escapeAction = playerActionMap.FindAction("Exit");
    }

    // Enable/Disable player controls
    private void OnEnable()
    {
        playerActionMap.Enable();
    }
    private void OnDisable()
    {
        playerActionMap.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {   
        // Starting state for the player
        Cursor.lockState = CursorLockMode.Locked;
        currentState = idleState;
        currentState.EnterState(this);

        rb.linearDamping = dragValue;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (bounceTimer < bounceCooldown)
        {
            bounceTimer += Time.deltaTime;
        }*/

        // Update UI Elements
        if (dashing > 0)
        {
            dashUI.SetActive(true);
        }
        else
        {
            dashUI.SetActive(false);
        }
        dashBar.fillAmount = dashMult / dashCeiling;

        // Update current state
        currentState.UpdateState(this);

        if (escapeAction.ReadValue<float>() > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(titleScene);
        }

    }

    void FixedUpdate()
    {
        // You can add physics-related state updates here if needed
        // Get control inputs
        moveDirection = moveAction.ReadValue<Vector3>();
        Debug.Log(moveDirection);
        moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        Debug.Log(moveDirection);
        dashing = dashAction.ReadValue<float>();

        currentState.FixedUpdateState(this);

        if (jumpAction.WasPressedThisFrame())
        {
            rb.AddForce(new Vector3(0, bounceStrength, 0), ForceMode.Impulse);
        }
    }

    // Transition to a new state
    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
