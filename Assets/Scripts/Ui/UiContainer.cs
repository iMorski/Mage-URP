using UnityEngine;

public class UiContainer : MonoBehaviour
{
    public static UiContainer Instance;

    public Camera Camera;
    public float CameraSmoothTime;
    public float BarDistance;
    public Color BarColorMain;
    public Color BarColorOnCharge;
    public Color ButtonColorMain;
    public Color ButtonColorOnCharge;

    private void Awake()
    {
        Instance = this;
    }
}
