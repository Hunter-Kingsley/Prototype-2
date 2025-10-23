using UnityEngine;
using UnityEngine.InputSystem;

public class BounceState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        /*//Debug.Log("Entering Bounce State");

        if (player.bounceTimer > player.bounceCooldown)
        {
            player.rb.linearVelocity = (new Vector3(0, player.bounceStrength, 0));
            player.bounceTimer = 0;
        } else
        {
            if (player.moveDirection != Vector2.zero)
            {
                player.SwitchState(player.moveState);
            } else
            {
                player.SwitchState(player.idleState);
            }
        }*/
    }

    public override void UpdateState(MovementManager player)
    {
        /*// Bounce state logic
        if (player.moveDirection != Vector2.zero)
        {
            player.SwitchState(player.moveState);
        }
        else
        {
            player.SwitchState(player.idleState);
        }*/
    }

    public override void FixedUpdateState(MovementManager player)
    {
        /*// Bounce physics logic

        // apply gravity
        player.rb.AddForce(new Vector3(0, player.gravityValue, 0), ForceMode.Acceleration);
        //Debug.Log(player.rb.linearVelocity.y);

        if (player.rb.linearVelocity.y < player.maxGravity)
        {
            player.rb.linearVelocity = new Vector3(0, player.maxGravity, 0);
        }*/
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in bounce state
    }
}
