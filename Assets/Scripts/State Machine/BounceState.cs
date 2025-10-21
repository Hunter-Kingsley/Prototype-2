using UnityEngine;
using UnityEngine.InputSystem;

public class BounceState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        Debug.Log("Entering Bounce State");

        player.rb.AddForce(new Vector3(0, bounceStrength, 0), ForceMode.Impulse);
    }

    public override void UpdateState(MovementManager player)
    {
        // Bounce state logic
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Bounce physics logic

        // apply gravity
        player.rb.AddForce(new Vector3(0, gravityValue, 0), ForceMode.Acceleration);
        Debug.Log(player.rb.linearVelocity.y);

        if (player.rb.linearVelocity.y < maxGravity)
        {
            player.rb.linearVelocity = new Vector3(0, maxGravity, 0);
        }
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in bounce state
    }
}
