using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{
    public Vector3 edgeA;
    public Vector3 edgeB;

    private float phase = 0.5f;
    public float speed = 5f;

    private float phaseDirection = 1f;

    // Update is called once per frame
    void Update()
    {
        //Phase setermines in which point of the line the object has to be
        transform.position = Vector3.Lerp(edgeA, edgeB, phase);
        phase += speed * phaseDirection * Time.fixedDeltaTime;

        if (phase >= 1f || phase <= 0f) {
            phaseDirection *= -1f;
        }

    }
}
