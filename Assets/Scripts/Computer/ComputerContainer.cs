using UnityEngine;

public class ComputerContainer : MonoBehaviour
{
    public static ComputerContainer Instance;

    public Transform Ball;
    public Transform Gate;
    public float DistanceToStop;
    public float WaitTimeMin;
    public float WaitTimeMax;
    public Color CircleColorE;
    public Color CircleColorF;

    private void Awake()
    {
        Instance = this;
    }
}
