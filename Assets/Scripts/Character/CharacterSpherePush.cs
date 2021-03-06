using UnityEngine;

public class CharacterSpherePush : CharacterSphereCapture
{
    public void Push(Vector3 Direction)
    {
        if (!Ball) return;
        
        Release();
        
        Rigidbody Rigidbody = Ball.GetComponent<Rigidbody>();
        Rigidbody.AddForce(Vector3.Normalize(new Vector3(Direction.x, 0.0f,
            Direction.z)) * CharacterContainer.Instance.SpherePushForce);
        
        Ball = null;
    }
}