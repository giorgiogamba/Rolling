using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CouplesController))]
public class RotationController : MonoBehaviour
{

    public bool enabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (enabled)
        {
            transform.parent.Rotate(new Vector3(180, 0, 0));
            enabled = false;

            //notificare che la mattonella si è girata
            Camera.main.GetComponent<CouplesController>().InsertInBuffer(transform.parent.gameObject);
        }
    }

    public void BackRotation() {
        transform.parent.Rotate(new Vector3(-180, 0, 0));
        enabled = true;
    }
}
