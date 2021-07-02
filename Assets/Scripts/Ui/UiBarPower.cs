using UnityEngine;
using UnityEngine.UI;

public class UiBarPower : MonoBehaviour
{
    [SerializeField] private Image Bar01Amount;
    [SerializeField] private Image Bar02Amount;
    [SerializeField] private Image Bar03Amount;

    private bool Bar01ColorChange;
    private bool Bar02ColorChange;
    private bool Bar03ColorChange;

    private void FixedUpdate()
    {
        Camera Camera = UiContainer.Instance.Camera;
        
        float DistanceInView = Camera.ViewportToScreenPoint(
            new Vector3(0.0f, UiContainer.Instance.BarDistance, 0.0f)).y;
        
        transform.position = Camera.WorldToScreenPoint(
            PlayerContainer.Instance.Player.transform.position) + new Vector3(0.0f, DistanceInView, 0.0f);

        float Charge01 = PlayerContainer.Instance.PlayerPower.Charge01;
        float Charge02 = PlayerContainer.Instance.PlayerPower.Charge02;
        float Charge03 = PlayerContainer.Instance.PlayerPower.Charge03;
        
        Bar01Amount.fillAmount = Charge01;
        Bar02Amount.fillAmount = Charge02;
        Bar03Amount.fillAmount = Charge03;

        Color ColorMain = UiContainer.Instance.BarColorMain;
        Color ColorOnChange = UiContainer.Instance.BarColorOnCharge;

        if (Charge03 < 1.0f && !Bar03ColorChange)
        {
            Bar03Amount.color = ColorOnChange;
            
            Bar03ColorChange = !Bar03ColorChange;
        }
        else if (!(Charge03 < 1.0f) && Bar03ColorChange)
        {
            Bar03Amount.color = ColorMain;
            
            Bar03ColorChange = !Bar03ColorChange;
        }
        
        if (Charge02 < 1.0f && !Bar02ColorChange)
        {
            Bar02Amount.color = ColorOnChange;
            
            Bar02ColorChange = !Bar02ColorChange;
        }
        else if (!(Charge02 < 1.0f) && Bar02ColorChange)
        {
            Bar02Amount.color = ColorMain;
            
            Bar02ColorChange = !Bar02ColorChange;
        }
        
        if (Charge01 < 1.0f && !Bar01ColorChange)
        {
            Bar01Amount.color = ColorOnChange;
            
            Bar01ColorChange = !Bar01ColorChange;
        }
        else if (!(Charge01 < 1.0f) && Bar01ColorChange)
        {
            Bar01Amount.color = ColorMain;
            
            Bar01ColorChange = !Bar01ColorChange;
        }
    }
}
