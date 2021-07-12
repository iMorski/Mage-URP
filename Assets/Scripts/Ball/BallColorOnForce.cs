using UnityEngine;

public class BallColorOnForce : MonoBehaviour
{
    [SerializeField] private MeshRenderer MeshRenderer;
    
    private Rigidbody Rigidbody;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Color ColorChange;
        Color ColorCurrent = MeshRenderer.material.color;
        Color ColorStep01 = BallContainer.Instance.BallColorStep01;
        Color ColorStep02 = BallContainer.Instance.BallColorStep02;
        Color ColorStep03 = BallContainer.Instance.BallColorStep03;
        Color ColorStep04 = BallContainer.Instance.BallColorStep04;

        float Speed = Rigidbody.velocity.magnitude;
        float SpeedStep01 = BallContainer.Instance.BallSpeedStep01;
        float SpeedStep02 = BallContainer.Instance.BallSpeedStep02;
        float SpeedStep03 = BallContainer.Instance.BallSpeedStep03;

        if (Speed > SpeedStep03) ColorChange = ColorStep04;
        else if (Speed > SpeedStep02) ColorChange = ColorStep03;
        else if (Speed > SpeedStep01) ColorChange = ColorStep02;
        else ColorChange = ColorStep01;
        
        MeshRenderer.material.color = Color.Lerp(ColorCurrent, ColorChange,
            BallContainer.Instance.BallColorChangeStep);
    }
}
