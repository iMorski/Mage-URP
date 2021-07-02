using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    public static PlayerContainer Instance;

    public GameObject Player;
    public PlayerPower PlayerPower;
    public PlayerSphere PlayerSphere;
    public PlayerSpherePush PlayerSpherePush;
    public UiJoystick Joystick;
    public float JoystickNullDistance;
    public UiTouch TouchOnSphere;
    public UiTouch TouchOnDash;
    public float TouchTapDistance;
    public float PowerUpRate;

    private void Awake()
    {
        Instance = this;
    }
}
