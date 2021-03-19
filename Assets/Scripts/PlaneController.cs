using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //controlla che materiale possiede correntnemente
        Material currentMat = GetComponent<Renderer>().material;
        if (currentMat.color == Color.red)
        {
            currentMat.color = Color.black;
        }
        else {
            currentMat.color = Color.red;
        }
    }
}
