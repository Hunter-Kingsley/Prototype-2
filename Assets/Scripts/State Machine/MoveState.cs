using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : MovementBaseState
{
    
    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
            audioManager.PlaySFX(audioManager.dash);
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
        player.rb.AddForce(new Vector3(
            player.moveDirection.x * (player.horizontalMoveSpeed * player.dashMult),
            0,
            player.moveDirection.z * (player.horizontalMoveSpeed * player.dashMult)
            ), ForceMode.Acceleration);
    }

    public override void OnCollisionEnter(MovementManager player)
    {
        // Handle collision in move state
    }
}
