using System;
using UnityEngine;
using UnityEngine.UI;

public class UiButton : MonoBehaviour
{
    public Image Stroke;
    [NonSerialized] public Animator Animator;
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        
        UiTouch Touch = GetComponentInChildren<UiTouch>();
        Touch.TapBegin += OnTouchTapBegin;
        Touch.TapFinish += OnTouchTapFinish;
    }

    private void OnTouchTapBegin()
    {
        Color ColorMain = UiContainer.Instance.ButtonColorMain;
        Color ColorOnCharge = UiContainer.Instance.ButtonColorOnCharge;

        if (PlayerContainer.Instance.PlayerPower.Charge01 < 1.0f) Stroke.color = ColorOnCharge;
        else Stroke.color = ColorMain;
        
        Animator.Play("Ui-Push-In");
    }
    
    private void OnTouchTapFinish()
    {
        Animator.Play("Ui-Push-Out");
    }
}
