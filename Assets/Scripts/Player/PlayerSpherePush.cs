using UnityEngine;

public class PlayerSpherePush : CharacterSpherePush
{
    public delegate void OnSphereOnCollisionEnter();
    public event OnSphereOnCollisionEnter SphereOnCollisionEnter;
    
    public delegate void OnSphereOnCollisionExit();
    public event OnSphereOnCollisionExit SphereOnCollisionExit;
    
    private void Start()
    {
        PlayerContainer.Instance.TouchOnSphere.SwipeByRelease += OnSwipeByRelease;
    }

    public override void OnTriggerEnter(Collider Other)
    {
        base.OnTriggerEnter(Other);

        if (Other.CompareTag("Sphere"))
        {
            SphereOnCollisionEnter?.Invoke();
        }
    }

    public override void OnTriggerExit(Collider Other)
    {
        base.OnTriggerEnter(Other);
        
        if (Other.CompareTag("Sphere"))
        {
            SphereOnCollisionExit?.Invoke();
        }
    }

    private void OnSwipeByRelease(Vector2 Direction) { Push(Direction); }
}
