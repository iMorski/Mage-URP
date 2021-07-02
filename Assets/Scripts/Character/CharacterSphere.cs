using System;
using System.Collections;
using UnityEngine;

public class CharacterSphere : MonoBehaviour
{
    [SerializeField] private Transform Sphere;
    [SerializeField] private Transform SphereMesh;

    [NonSerialized] public bool OnCast;

    public void ChangeState()
    {
        StopAllCoroutines();

        if (!OnCast)
        {
            StartCoroutine(ChangeScale(
                CharacterContainer.Instance.SphereRadius));
        }
        else
        {
            StartCoroutine(ChangeScale(
                0.0f));
        }

        OnCast = !OnCast;
    }
    
    private Vector3 Velocity;
    private Vector3 MeshVelocity;
    
    private IEnumerator ChangeScale(float Value)
    {
        Vector3 Scale = new Vector3(Value, Value, Value);
        
        while (Sphere.localScale != Scale ||
               SphereMesh.localScale != Scale)
        {
            float Time = CharacterContainer.Instance.SphereTime;
            
            Sphere.localScale = Vector3.SmoothDamp(
                Sphere.localScale, Scale, ref Velocity, Time);

            SphereMesh.localScale = Vector3.SmoothDamp(
                SphereMesh.localScale, Scale, ref MeshVelocity, Time);
            
            yield return new WaitForFixedUpdate();
        }
    }
}
