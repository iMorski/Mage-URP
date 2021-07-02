public class UiButtonSphere : UiButton
{
    private void Start()
    {
        PlayerSpherePush SpherePush = PlayerContainer.Instance.PlayerSpherePush;
        
        SpherePush.SphereOnCollisionEnter += OnPlayerSphereOnCollisionEnter;
        SpherePush.SphereOnCollisionExit += OnPlayerSphereOnCollisionExit;
    }

    private void OnPlayerSphereOnCollisionEnter()
    {
        Animator.Play("Ui-Sphere-Arrow-In", 1);
    }
    
    private void OnPlayerSphereOnCollisionExit()
    {
        Animator.Play("Ui-Sphere-Arrow-Out", 1);
    }
}
