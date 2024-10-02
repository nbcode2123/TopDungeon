
using UnityEngine;

public class PlayerState
{
    // Start is called before the first frame update
    public Player Player;
    public PlayerStateMachine playerStateMachine;
    public PlayerState(Player Player, PlayerStateMachine playerStateMachine)
    {
        this.Player = Player;
        this.playerStateMachine = playerStateMachine;
    }
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicalUpdate() { }
}
