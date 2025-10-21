using UnityEngine;

public abstract class MovementBaseState
{
    public abstract void EnterState(MovementManager player);

    public abstract void UpdateState(MovementManager player);

    public abstract void FixedUpdateState(MovementManager player);

    public abstract void OnCollisionEnter(MovementManager player);
}
