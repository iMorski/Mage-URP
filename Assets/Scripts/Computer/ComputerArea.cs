using System;
using UnityEngine;

public class ComputerArea : MonoBehaviour
{
    [NonSerialized] public bool BallIn;
    
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            BallIn = true;
        }
    }
    
    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Ball"))
        {
            BallIn = false;
        }
    }
}
