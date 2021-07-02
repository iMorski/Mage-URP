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
        if (BallOnGround(Rigidbody))
        {
            float RiseForce = CharacterContainer.Instance.SphereCaptureRiseForce;
            float RiseDuration = CharacterContainer.Instance.SphereCaptureRiseDuration;

            Rigidbody.AddForce(new Vector3(
                0.0f, 1.0f, 0.0f) * RiseForce);
            
            yield return new WaitForSeconds(RiseDuration);
        }
        
        Vector3 Velocity = new Vector3();
        
        while (BallInMotion(Rigidbody))
        {
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity,
            new Vector3(), ref Velocity, CharacterContainer.Instance.SphereCaptureTime);

            yield return new WaitForFixedUpdate();
        }
    }

    private bool BallOnGround(Rigidbody Rigidbody)
    {
        float GroundDistance = 0.0f;
        
        if (Physics.Raycast(Rigidbody.transform.position, new Vector3(
            0.0f, -1.0f, 0.0f), out RaycastHit Hit)) GroundDistance = Hit.distance;
        
        return GroundDistance < CharacterContainer.Instance.SphereCaptureRiseDistance;
    }

    private bool BallInMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
}
