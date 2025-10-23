using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        //Debug.Log("Entering Move State");
    }

    public override void UpdateState(MovementManager player)
    {
        // Move state logic
        if (player.moveDirection == Vector3.zero)
        {
            player.SwitchState(player.idleState);
        }

        if (player.dashing > 0)
        {
            player.SwitchState(player.dashState);
        }

        if (player.dashMult > player.dashFloor)
        {
            player.dashMult -= Time.deltaTime * player.dashChargeSpeed;
        }

        /*if (player.playerBounce.IsPressed())
        {
            player.SwitchState(player.bounceState);
        }*/
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Move physics logic
        player.rb.linearVelocity = new Vector3(
            player.moveDirection.x * (player.horizontalMoveSpeed * player.dashMult),
            player.moveDirection.y * (player.verticalMoveSpeed * player.dashMult),
            player.moveDirection.z * (player.horizontalMoveSpeed * player.dashMult)
            );
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in move state
    }
}
