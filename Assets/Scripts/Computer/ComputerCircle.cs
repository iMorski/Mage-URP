using UnityEngine;

public class ComputerCircle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SpriteRenderer;
    
    private void Start()
    {
        if (CompareTag("Computer [F]")) SpriteRenderer.color = ComputerContainer.Instance.CircleColorF;
        else SpriteRenderer.color = ComputerContainer.Instance.CircleColorE;
    }
}
