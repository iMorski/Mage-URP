public class UiButtonSphere : UiButton
{
    private void Start()
    {
        PlayerSpherePush SpherePush = PlayerContainer.Instance.PlayerSpherePush;
        
        SpherePush.BallEnter += OnPlayerBallEnter;
        SpherePush.BallExit += OnPlayerBallExit;
    }

    private void OnPlayerBallEnter()
    {
        Animator.Play("Ui-Sphere-Arrow-In", 1);
    }
    
    private void OnPlayerBallExit()
    {
        Animator.Play("Ui-Sphere-Arrow-Out", 1);
    }
}
