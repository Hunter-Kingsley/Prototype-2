using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        Debug.Log("Entering Idle State");

        // Stop player movement
        player.rb.linearVelocity = new Vector3(0, player.rb.linearVelocity.y, 0);
        player.rb.angularVelocity = new Vector3(0, player.rb.angularVelocity.y, 0);
    }

    public override void UpdateState(MovementManager player)
    {

        if (player.playerBounce.IsPressed())
        {
            player.SwitchState(player.bounceState);
        }

        // Idle state logic
        if (player.moveDirection != Vector2.zero)
        {
            player.SwitchState(player.moveState);
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
