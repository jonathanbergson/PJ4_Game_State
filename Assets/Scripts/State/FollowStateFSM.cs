using UnityEngine;

public class FollowStateFSM : StateFSM
{
    PlayerMachineFSM player;

    public FollowStateFSM(PlayerMachineFSM player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("Enter Follow State");
    }

    public void Update()
    {
        player.Move(player.TargetDir().normalized);

        if (player.energy < 0)
        {
            player.SetState(new SleepStateFSM(player));
        }
        if (player.IsNearTarget() == false)
        {
            player.SetState(new FollowStateFSM(player));
        }
    }

    public void Exit() {}
}
