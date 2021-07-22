using System;
using UnityEngine;

public class ComputerOuterCheck : MonoBehaviour
{
    [NonSerialized] public bool Ball;

    private void OnTriggerEnter(Collider Other) { if (Other.CompareTag("Ball")) Ball = true; }
    private void OnTriggerExit(Collider Other) { if (Other.CompareTag("Ball")) Ball = false; }
}
