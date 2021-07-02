using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSphereCapture : MonoBehaviour
{
    [NonSerialized] public List<Collider> BlockInSphereCollider = new List<Collider>();
    [NonSerialized] public List<Coroutine> BlockInSphereCoroutine = new List<Coroutine>();
    
    public virtual void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Sphere"))
        {
            Rigidbody Rigidbody = Other.GetComponent<Rigidbody>();
            
            Rigidbody.useGravity = false;

            BlockInSphereCollider.Add(Other);
            BlockInSphereCoroutine.Add(StartCoroutine(Capture(Rigidbody)));
        }
    }
    
    public virtual void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Sphere"))
        {
            Rigidbody Rigidbody = Other.GetComponent<Rigidbody>();
            Coroutine Coroutine = BlockInSphereCoroutine[
                BlockInSphereCollider.IndexOf(Other)];

            Rigidbody.useGravity = true;
            
            if (Coroutine != null) StopCoroutine(Coroutine);

            BlockInSphereCollider.Remove(Other);
            BlockInSphereCoroutine.Remove(Coroutine);
        }
    }
    
    private IEnumerator Capture(Rigidbody Rigidbody)
    {
        if (BlockOnGround(Rigidbody))
        {
            float Force = CharacterContainer.Instance.SphereCaptureRiseForce;
            float Time = CharacterContainer.Instance.SphereCaptureRiseTime;

            Rigidbody.AddForce(new Vector3(
                0.0f, 1.0f, 0.0f) * Force);
            
            yield return new WaitForSeconds(Time);
        }
        
        Vector3 Velocity = new Vector3();
        
        while (BlockInMotion(Rigidbody))
        {
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity,
            new Vector3(), ref Velocity, CharacterContainer.Instance.SphereCaptureTime);

            yield return new WaitForFixedUpdate();
        }
    }

    private bool BlockOnGround(Rigidbody Rigidbody)
    {
        float GroundDistance = 0.0f;
        
        if (Physics.Raycast(Rigidbody.transform.position, new Vector3(
            0.0f, -1.0f, 0.0f), out RaycastHit Hit)) GroundDistance = Hit.distance;
        
        return GroundDistance < CharacterContainer.Instance.SphereCaptureRiseDistance;
    }

    private bool BlockInMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
}
