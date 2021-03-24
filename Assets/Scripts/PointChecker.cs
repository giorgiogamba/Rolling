using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointChecker : MonoBehaviour
{
    public StrikesCounterController scc;

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Colpito!");
        scc.UpdateStrike();
        
    }
}
