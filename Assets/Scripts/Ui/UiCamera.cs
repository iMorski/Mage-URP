using UnityEngine;

public class UiCamera : MonoBehaviour
{
    private Vector3 Position;

    private void Awake()
    {
        Position = transform.position;
    }

    private Vector3 Velocity;

    private void FixedUpdate()
    {
        Vector3 PlayerPosition = PlayerContainer.Instance.Player.transform.position;
        Vector3 OnPlayerPosition = new Vector3(Position.x + PlayerPosition.x,
            Position.y, Position.z + PlayerPosition.z);
        Vector3 OnPlayerPositionSmooth = Vector3.SmoothDamp(transform.position,
            OnPlayerPosition, ref Velocity, UiContainer.Instance.CameraSmoothTime);
        
        transform.position = OnPlayerPositionSmooth;
    }
}
