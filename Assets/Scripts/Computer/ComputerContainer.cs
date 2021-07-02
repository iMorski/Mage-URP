using UnityEngine;

public class ComputerContainer : MonoBehaviour
{
    public static ComputerContainer Instance;

    public Transform Ball;
    public float DistanceToStop;
    public float WaitTimeMin;
    public float WaitTimeMax;

    private void Awake()
    {
        Instance = this;
    }
}
