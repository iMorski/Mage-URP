using UnityEngine;

public class ComputerSphere : CharacterSphere
{
    private void FixedUpdate()
    {
        Vector3 BallPosition = ComputerContainer.Instance.Ball.position;
        Vector3 Position = transform.position;

        float Distance = Vector3.Distance(BallPosition, Position);
        float DistanceToStop = ComputerContainer.Instance.DistanceToStop;

        if (Distance > DistanceToStop && OnCast || Distance < DistanceToStop && !OnCast)
        {
            ChangeState();
        }
    }
}
