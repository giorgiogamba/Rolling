using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigController : MonoBehaviour
{
    public TextMesh text;

    private void OnTriggerEnter(Collider other)
    {
        string letter = text.text;
        if (letter.Equals("O"))
        {
            Debug.Log("Corretto!");
        }
        else {
            Debug.Log("Sbagliato!");
        }
    }
}
