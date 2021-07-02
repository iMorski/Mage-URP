using System;
using System.Collections;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    [NonSerialized] public float Charge01 = 1.0f;
    [NonSerialized] public float Charge02 = 1.0f;
    [NonSerialized] public float Charge03 = 1.0f;
    
    private void Start()
    {
        PlayerSphere Sphere = PlayerContainer.Instance.PlayerSphere;
        
        Sphere.CastBegin += OnCastBegin;
        Sphere.CastFinish += OnCastFinish;
    }

    private bool OnCast;

    private void OnCastBegin()
    {
        OnCast = !OnCast;
        
        StopAllCoroutines();
        
        if (!(Charge03 < 1.0f))
        {
            Charge03 = 0.0f;
        }
        else if (!(Charge02 < 1.0f))
        {
            Charge02 = Charge03;
            Charge03 = 0.0f;
        }
        else if (!(Charge01 < 1.0f))
        {
            Charge01 = Charge02;
            Charge02 = 0.0f;
        }
    }

    private void OnCastFinish()
    {
        OnCast = !OnCast;
        
        StopAllCoroutines();
        
        if (Charge01 < 1.0f) StartCoroutine(PowerUpCharge01());
        else if (Charge02 < 1.0f) StartCoroutine(PowerUpCharge02());
        else if (Charge03 < 1.0f) StartCoroutine(PowerUpCharge03());
    }

    private IEnumerator PowerUpCharge01()
    {
        while (Charge01 < 1.0f)
        {
            Charge01 = Charge01 + PlayerContainer.Instance.PowerUpRate * Time.fixedDeltaTime;
            
            yield return new WaitForFixedUpdate();
        }
        
        if (!OnCast) StartCoroutine(PowerUpCharge02());
    }
    
    private IEnumerator PowerUpCharge02()
    {
        while (Charge02 < 1.0f)
        {
            Charge02 = Charge02 + PlayerContainer.Instance.PowerUpRate * Time.fixedDeltaTime;
            
            yield return new WaitForFixedUpdate();
        }
        
        if (!OnCast) StartCoroutine(PowerUpCharge03());
    }
    
    private IEnumerator PowerUpCharge03()
    {
        while (Charge03 < 1.0f)
        {
            Charge03 = Charge03 + PlayerContainer.Instance.PowerUpRate * Time.fixedDeltaTime;
            
            yield return new WaitForFixedUpdate();
        }
    }
}
