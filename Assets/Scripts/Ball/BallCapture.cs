using System;
using System.Collections;
using UnityEngine;

public class BallCapture : MonoBehaviour
{
    [NonSerialized] public Coroutine CaptureCoroutine;
    [NonSerialized] public int CaptureCount;
    
    public IEnumerator Capture(Rigidbody Rigidbody)
    {
        Vector3 SmoothVelocity = new Vector3();
        Vector3 RiseVelocity = new Vector3();
        
        while (BallInMotion(Rigidbody) || BallOnGround(Rigidbody))
        {
            float Distance = CharacterContainer.Instance.SphereCaptureRiseDistance;
            float Duration = CharacterContainer.Instance.SphereCaptureRiseDuration;
            
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, new Vector3(),
                ref SmoothVelocity, CharacterContainer.Instance.SphereCaptureTime);

            Rigidbody.transform.position = Vector3.SmoothDamp(Rigidbody.transform.position, new Vector3(
                Rigidbody.transform.position.x, Distance, Rigidbody.transform.position.z), ref RiseVelocity, Duration);

            yield return new WaitForFixedUpdate();
        }
    }
    
    private bool BallInMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
    
    private bool BallOnGround(Rigidbody Rigidbody)
    {
        float GroundDistance = 0.0f;
        
        if (Physics.Raycast(Rigidbody.transform.position, new Vector3(
            0.0f, -1.0f, 0.0f), out RaycastHit Hit)) GroundDistance = Hit.distance;
        
        return GroundDistance < CharacterContainer.Instance.SphereCaptureRiseDistance;
    }
}