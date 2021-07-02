public class PlayerSphere : CharacterSphere
{
    public delegate void OnCastBegin();
    public event OnCastBegin CastBegin;
    
    public delegate void OnCastFinish();
    public event OnCastFinish CastFinish;

    private void Start()
    {
        UiTouch Touch = PlayerContainer.Instance.TouchOnSphere;
        
        Touch.TapBegin += OnTapBegin;
        Touch.TapFinish += OnTapFinish;
    }

    private bool Cast;
    
    private void OnTapBegin()
    {
        if (!(PlayerContainer.Instance.PlayerPower.Charge01 < 1.0f))
        {
            CastBegin?.Invoke();
            
            ChangeState();

            Cast = !Cast;
        }
    }

    private void OnTapFinish()
    {
        if (OnCast)
        {
            CastFinish?.Invoke();
            
            ChangeState();
            
            Cast = !Cast;
        }
    }
}
