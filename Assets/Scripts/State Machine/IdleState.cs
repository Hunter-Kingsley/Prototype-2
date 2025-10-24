using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        //Debug.Log("Entering Idle State");

        // Apply Drag on the X and Z axis to the player
        //player.rb.linearVelocity = Vector3.zero;
        //player.rb.angularVelocity = Vector3.zero;
    }

    public override void UpdateState(MovementManager player)
    {

        // Idle state logic
        if (player.moveDirection != Vector3.zero)
        {
            player.SwitchState(player.moveState);
        }

        if (player.dashing > 0)
        {
            player.SwitchState(player.dashState);
        }
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Idle physics logic
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in idle state
    }
}
