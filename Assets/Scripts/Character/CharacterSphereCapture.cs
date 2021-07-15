using System;
using System.Collections;
using UnityEngine;

public class CharacterSphereCapture : MonoBehaviour
{
    [NonSerialized] public Collider Ball;
    [NonSerialized] public Coroutine BallCoroutine;
        
    public virtual void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            Rigidbody Rigidbody = Other.GetComponent<Rigidbody>();
            Rigidbody.useGravity = false;

            Ball = Other;
            BallCoroutine = StartCoroutine(Capture(Rigidbody));
        }
    }
    
    public virtual void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            Rigidbody Rigidbody = Other.GetComponent<Rigidbody>();
            Rigidbody.useGravity = true;

            Ball = null;
            if (BallCoroutine != null) StopCoroutine(BallCoroutine);
        }
    }
    
    private IEnumerator Capture(Rigidbody Rigidbody)
    {
        Vector3 Velocity = new Vector3();
        
        while (BallInMotion(Rigidbody))
        {
            float CaptureTime = CharacterContainer.Instance.SphereCaptureTime;
            float CaptureTimeOnForce = CaptureTime * (Rigidbody.velocity.magnitude / 100);
            
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, new Vector3(),
                ref Velocity, CaptureTimeOnForce);
            
            yield return new WaitForFixedUpdate();
        }
    }
    
    private bool BallInMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
}
