using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    public static CharacterContainer Instance;
    
    public float MoveSpeed;
    public float MoveSmoothTime;
    
    public float SphereRadius;
    public float SphereTime;

    public float SphereCaptureRiseDistance;
    public float SphereCaptureRiseDuration;
    
    public float SphereCaptureTime;

    public float SpherePushForce;

    private void Awake()
    {
        Instance = this;
    }
}
