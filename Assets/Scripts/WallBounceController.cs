using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceController : MonoBehaviour
{

    public float repulsion = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (string.Equals("Wall", collision.gameObject.tag))
        {
            Debug.Log("Dentro");
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = -direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * repulsion);
            Debug.Log("fatto");
        }
    }
}
