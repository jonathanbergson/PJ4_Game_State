using UnityEngine;

public class PlayerMachineFSM : MonoBehaviour
{
    StateFSM state;
    public Transform target;
    public float energy;
    public float speed;

    void Start()
    {
        SetState(new SleepStateFSM(this));
        energy = 3;
    }

    void FixedUpdate()
    {
        state?.Update();
    }

    public void SetState(StateFSM state)
    {
        state?.Exit();
        this.state = state;
        state?.Enter();
    }

    public Vector3 TargetDir()
    {
        Vector3 dir = target.position - transform.position;
        return dir;
    }

    public bool IsNearTarget()
    {
        return TargetDir().magnitude < 6.0f;
    }

    public void Move(Vector3 dir)
    {
        energy -= Time.fixedDeltaTime;
        transform.position += dir * speed * Time.fixedDeltaTime;
    }
}
