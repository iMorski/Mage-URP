using System.Collections;
using UnityEngine;

public class ComputerSpherePush : CharacterSpherePush
{
    private bool OnWait;

    private void FixedUpdate()
    {
        if (Ball && !OnWait)
        {
            StartCoroutine(OnPush());
        }
    }
    
    private IEnumerator OnPush()
    {
        OnWait = !OnWait;
        
        yield return new WaitForSeconds(Random.Range(
            ComputerContainer.Instance.WaitTimeMin, ComputerContainer.Instance.WaitTimeMax));
        
        Vector3 PlayerPosition = PlayerContainer.Instance.Player.transform.position;
        Vector3 Position = transform.position;
        
        Push(new Vector3(PlayerPosition.x - Position.x, 0.0f,
            PlayerPosition.z - Position.z));
        
        OnWait = !OnWait;
    }
}
