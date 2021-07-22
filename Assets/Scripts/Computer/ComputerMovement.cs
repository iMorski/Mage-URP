using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComputerMovement : CharacterMovement
{
    [SerializeField] private BehaviourGroup Behaviour;
    [SerializeField] private ComputerOuterCheck Check;
    
    private enum BehaviourGroup { Goalkeeper }

    private bool OnWait;
    private bool OnWaitCoroutine;

    private void FixedUpdate()
    {
        Vector3 BallPosition = ComputerContainer.Instance.Ball.position;
        Vector3 Position = transform.position;
        
        float DistanceToBall = Vector3.Distance(BallPosition, Position);
        float DistanceToStop = ComputerContainer.Instance.DistanceToStop;

        Vector3 Direction = new Vector3();
        
        switch (Behaviour)
        {
            case BehaviourGroup.Goalkeeper:

                if (DistanceToBall > DistanceToStop)
                {
                    if (Check.Ball)
                    {
                        Direction = new Vector3(BallPosition.x - Position.x,
                            0.0f, BallPosition.z - Position.z);
                    }
                    else if (Position.z != BallPosition.z)
                    {
                        Direction = new Vector3(0.0f,
                            0.0f, BallPosition.z - Position.z);
                    }
                }

                break;
        }
        
        ChangePosition(Direction);
        
        /*

        if (Check.Ball && DistanceToBall > DistanceToStop)
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
        else if (!(Behaviour != BehaviourGroup.Goalkeeper))
        {
            OnWait = true;
        }
        
        ChangePosition(Direction);
        
        */
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
