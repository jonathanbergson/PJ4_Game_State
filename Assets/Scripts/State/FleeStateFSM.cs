using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeStateFSM : StateFSM
{
    PlayerMachineFSM player;

    public FleeStateFSM(PlayerMachineFSM player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("Enter Flee State");
    }

    public void Update()
    {
        player.Move(player.TargetFlee().normalized);

        if (player.energy < 0)
        {
            player.SetState(new SleepStateFSM(player));
        }
        if (player.IsNearTargetFlee() == false)
        {
            player.SetState(new FleeStateFSM(player));
        }
    }

    public void Exit() { }
}
