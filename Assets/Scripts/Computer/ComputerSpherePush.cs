using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComputerSpherePush : CharacterSpherePush
{
    private bool OnWait;

    private void FixedUpdate()
    {
        if (Ball && !OnWait)
        {
            StartCoroutine(Push());
        }
    }
    
    private IEnumerator Push()
    {
        OnWait = !OnWait;
        
        yield return new WaitForSeconds(Random.Range(
            ComputerContainer.Instance.WaitTimeMin, ComputerContainer.Instance.WaitTimeMax));

        Vector3 PushPosition = new Vector3();
        Vector3 Position = transform.position;
        
        if (transform.parent.CompareTag("Computer [F]"))
        {
            PushPosition = PlayerContainer.Instance.Player.transform.position;
        }
        else
        {
            foreach (GameObject Computer in GameObject.FindGameObjectsWithTag("Computer [E]"))
            {
                Vector3 ComputerPosition = Computer.transform.position;
                
                if (ComputerPosition.x < Position.x)
                {
                    PushPosition = ComputerPosition;

                    break;
                }
            }

            if (!(PushPosition != new Vector3()))
            {
                PushPosition = ComputerContainer.Instance.Gate.position;
            }
        }
                
        Push(new Vector3(PushPosition.x - Position.x, 0.0f,
            PushPosition.z - Position.z));
        
        OnWait = !OnWait;
    }
}
