using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelPlaneController : MonoBehaviour
{

    public GameObject finalPlane;

    public Material unlockedMaterial;

    public void UnlockLevel() {

        //Changing object Y position
        finalPlane.transform.position = new Vector3(6f, 0f, -9.5f);

        //Enabling trigger
        GameObject platform = finalPlane.transform.Find("Platform").gameObject;
        if (platform != null) {
            GameObject trigger = platform.transform.Find("Trigger").gameObject;
            if (trigger != null) {
                trigger.GetComponent<LauncherController>().SetEnabled(true);

                //Changing Material
                trigger.GetComponent<Renderer>().material = unlockedMaterial;
            } else {
                Debug.Log("FinalLevelPlaneController: trigger is null");
            }
            
        } else {
            Debug.Log("FinalLevelPlaneController: platform is null");
        }
    }
}
