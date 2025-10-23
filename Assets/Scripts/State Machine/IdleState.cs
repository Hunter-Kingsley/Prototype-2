using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        //Debug.Log("Entering Idle State");

        // Stop player movement
        player.rb.linearVelocity = Vector3.zero;
        player.rb.angularVelocity = Vector3.zero;
    }

    public override void UpdateState(MovementManager player)
    {

        /*if (player.playerBounce.IsPressed())
        {
            player.SwitchState(player.bounceState);
        }*/

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
