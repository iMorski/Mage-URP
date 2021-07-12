using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComputerMovement : CharacterMovement
{
    private bool OnWait;
    private bool OnWaitCoroutine;

    private ComputerArea Area;

    public override void Awake()
    {
        base.Awake();
        
        Area = GetComponentInParent<ComputerArea>();
    }
    
    private void FixedUpdate()
    {
        Vector3 BallPosition = ComputerContainer.Instance.Ball.position;
        Vector3 Position = transform.position;
        
        float DistanceToBall = Vector3.Distance(BallPosition, Position);
        float DistanceToStop = ComputerContainer.Instance.DistanceToStop;

        Vector3 Direction = new Vector3();

        if (Area.BallIn && DistanceToBall > DistanceToStop)
        {
            if (OnWait && !OnWaitCoroutine)
            {
                StartCoroutine(Wait());
            }
            else if (!OnWait)
            {
                Direction = new Vector3(BallPosition.x - Position.x,
                    0.0f, BallPosition.z - Position.z);
            }
        }
        else if (!OnWait)
        {
            OnWait = true;
        }
        
        ChangePosition(Direction);
    }

    private IEnumerator Wait()
    {
        OnWaitCoroutine = !OnWaitCoroutine;
        
        yield return new WaitForSeconds(Random.Range(
            ComputerContainer.Instance.WaitTimeMin, ComputerContainer.Instance.WaitTimeMax));

        OnWait = !OnWait;
        OnWaitCoroutine = !OnWaitCoroutine;
    }
}
