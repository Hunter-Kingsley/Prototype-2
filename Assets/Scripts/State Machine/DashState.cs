using UnityEngine;
using UnityEngine.InputSystem;

public class DashState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        Debug.Log("Entering Dash State");
    }

    public override void UpdateState(MovementManager player)
    {
        // Dash state logic
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Dash physics logic
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in dash state
    }
}
