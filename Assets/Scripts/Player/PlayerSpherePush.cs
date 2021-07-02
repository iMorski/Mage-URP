using UnityEngine;

public class PlayerSpherePush : CharacterSpherePush
{
    public delegate void OnBallEnter();
    public event OnBallEnter BallEnter;
    
    public delegate void OnBallExit();
    public event OnBallExit BallExit;
    
    private void Start()
    {
        PlayerContainer.Instance.TouchOnSphere.SwipeByRelease += OnSwipeByRelease;
    }

    public override void OnTriggerEnter(Collider Other)
    {
        base.OnTriggerEnter(Other);

        if (Other.CompareTag("Ball")) BallEnter?.Invoke();
    }

    public override void OnTriggerExit(Collider Other)
    {
        base.OnTriggerExit(Other);
        
        if (Other.CompareTag("Ball")) BallExit?.Invoke();
    }

    private void OnSwipeByRelease(Vector2 Direction)
    {
        Push(new Vector3(Direction.x, 0.0f, Direction.y));
    }
}
