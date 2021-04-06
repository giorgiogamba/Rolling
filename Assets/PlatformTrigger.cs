using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "platform"){
            //transform.parent.parent = other.transform;

            Transform child = other.transform.Find("Trig");
            if (child == null) {
                Debug.Log("Nullo");    
            }
            transform.parent.parent = child;

        }
    }
 
    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "platform"){
            transform.parent.parent = null;
        }
    } 
}
