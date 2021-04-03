using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, speed, 0f, Space.World);
    }
}
