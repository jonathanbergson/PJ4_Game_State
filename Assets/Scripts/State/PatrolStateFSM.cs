using UnityEngine;

public class PatrolStateFSM : StateFSM
{
    PlayerMachineFSM player;
    float time;
    Vector3 dir;
    
    public PatrolStateFSM(PlayerMachineFSM player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("Enter Patrol State");
    }

    public void Update()
    {
        if (Time.time > time)
        {
            dir = Random.onUnitSphere;
            dir.y = 0;
            time = Time.time + 1;
        }

        player.Move(dir);

        if (player.energy < 0)
        {
            player.SetState(new SleepStateFSM(player));
        }
        if (player.IsNearTarget())
        {
            player.SetState(new FollowStateFSM(player));
        }
    }

    public void Exit() {}
}