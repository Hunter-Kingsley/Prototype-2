using UnityEngine;
using UnityEngine.InputSystem;

public class BounceState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        Debug.Log("Entering Bounce State");
    }

    public override void UpdateState(MovementManager player)
    {
        // Bounce state logic
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Bounce physics logic
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in bounce state
    }
}
