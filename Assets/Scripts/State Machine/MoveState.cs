using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        Debug.Log("Entering Move State");
    }

    public override void UpdateState(MovementManager player)
    {
        // Move state logic
        if (player.moveDirection == Vector2.zero)
        {
            player.SwitchState(player.idleState);
        }
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Move physics logic
        player.rb.linearVelocity = new Vector3(player.moveDirection.x * player.moveSpeed, player.rb.linearVelocity.y, player.moveDirection.y * player.moveSpeed);
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in move state
    }
}
