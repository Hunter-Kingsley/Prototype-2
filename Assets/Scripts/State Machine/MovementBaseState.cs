using UnityEngine;

public abstract class MovementBaseState
{
    public float gravityValue = -5.0f;
    public float maxGravity = -7.0f;
    public float bounceStrength = 5.0f;

    public abstract void EnterState(MovementManager player);

    public abstract void UpdateState(MovementManager player);

    public abstract void FixedUpdateState(MovementManager player);

    public abstract void OnCollisionEnter(MovementManager player);
}
