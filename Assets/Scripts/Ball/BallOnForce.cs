using UnityEngine;

public class BallOnForce : MonoBehaviour
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

        float Speed = Rigidbody.velocity.magnitude;

        if (Speed > BallContainer.Instance.BallSpeedStep03) ColorChange = BallContainer.Instance.BallColorStep04;
        else if (Speed > BallContainer.Instance.BallSpeedStep02) ColorChange = BallContainer.Instance.BallColorStep03;
        else if (Speed > BallContainer.Instance.BallSpeedStep01) ColorChange = BallContainer.Instance.BallColorStep02;
        else ColorChange = BallContainer.Instance.BallColorStep01;
        
        MeshRenderer.material.color = Color.Lerp(ColorCurrent, ColorChange,
            BallContainer.Instance.BallColorChangeStep);
    }
}
