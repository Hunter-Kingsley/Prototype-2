using UnityEngine;
using UnityEngine.InputSystem;

public class DashState : MovementBaseState
{
    public MovementManager player;

    public override void EnterState(MovementManager player)
    {
        //Debug.Log("Entering Dash State");
        player.dashMult = player.dashFloor;
    }

    public override void UpdateState(MovementManager player)
    {
        // Dash state logic
        if (player.dashMult < player.dashCeiling)
        {
            player.dashMult += Time.deltaTime * player.dashChargeSpeed;
        }

        if (player.dashing == 0)
        {
            player.SwitchState(player.moveState);
        }
    }

    public override void FixedUpdateState(MovementManager player)
    {
        // Dash physics logic
        player.rb.linearVelocity = new Vector3(
            player.moveDirection.x * (player.horizontalMoveSpeed * player.dashSlowdown),
            player.moveDirection.y * (player.verticalMoveSpeed * player.dashSlowdown),
            player.moveDirection.z * (player.horizontalMoveSpeed * player.dashSlowdown)
            );
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in dash state
    }
}
