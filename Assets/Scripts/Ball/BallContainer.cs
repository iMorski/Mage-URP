using UnityEngine;

public class BallContainer : MonoBehaviour
{
    public static BallContainer Instance;
    
    public float CaptureTime;

    private void Awake()
    {
        Instance = this;
    }
}