using UnityEngine;

public class BallContainer : MonoBehaviour
{
    public static BallContainer Instance;

    public float BallSpeedStep01;
    public float BallSpeedStep02;
    public float BallSpeedStep03;
    
    public Color BallColorStep01;
    public Color BallColorStep02;
    public Color BallColorStep03;
    public Color BallColorStep04;
    public float BallColorChangeStep;
    
    private void Awake()
    {
        Instance = this;
    }
}
