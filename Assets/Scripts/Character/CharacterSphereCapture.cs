using System;
using UnityEngine;

public class CharacterSphereCapture : MonoBehaviour
{
    [NonSerialized] public Collider Ball;
        
    public virtual void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            Ball = Other;
            
            BallCapture BallCapture = Ball.GetComponent<BallCapture>();
            BallCapture.CaptureCount = BallCapture.CaptureCount + 1;
            
            if (BallCapture.CaptureCount > 1) return;

            Rigidbody Rigidbody = Ball.GetComponent<Rigidbody>();
            Rigidbody.useGravity = false;
            
            BallCapture.CaptureCoroutine = StartCoroutine(BallCapture.Capture(Rigidbody));
        }
    }
    
    public virtual void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            if (!Ball) return;
            
            Release();
            
            Ball = null;
        }
    }

    public void Release()
    {
        BallCapture BallCapture = Ball.GetComponent<BallCapture>();
        BallCapture.CaptureCount = BallCapture.CaptureCount - 1;
        
        if (BallCapture.CaptureCount > 0) return;
            
        Rigidbody Rigidbody = Ball.GetComponent<Rigidbody>();
        Rigidbody.useGravity = true;
            
        if (BallCapture.CaptureCoroutine != null) StopCoroutine(BallCapture.CaptureCoroutine);
    }
}
