using System;
using System.Collections;
using UnityEngine;

public class BallCapture : MonoBehaviour
{
    [NonSerialized] public Coroutine CaptureCoroutine;
    [NonSerialized] public int CaptureCount;
    
    public IEnumerator Capture(Rigidbody Rigidbody)
    {
        Vector3 Velocity = new Vector3();
        
        while (BallInMotion(Rigidbody))
        {
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, new Vector3(),
                ref Velocity, BallContainer.Instance.CaptureTime);

            yield return new WaitForFixedUpdate();
        }
    }
    
    private bool BallInMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
}