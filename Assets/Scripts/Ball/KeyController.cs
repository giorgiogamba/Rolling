using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    public GameObject door;
    public Material completedMaterial;

    void OnTriggerEnter(Collider other) {
        //Disabling trigger
        GetComponent<KeyController>().enabled = false;

        //Changing "door" position
        Vector3 newDoorPosition = new Vector3 (door.transform.position.x, -1f, door.transform.position.z);
        door.transform.position = newDoorPosition;

        //Changing "key" material
        transform.parent.gameObject.GetComponent<Renderer>().material = completedMaterial;
        transform.gameObject.GetComponent<Renderer>().material = completedMaterial;
    }
}
