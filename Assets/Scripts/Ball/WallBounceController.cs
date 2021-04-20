using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceController : MonoBehaviour
{

    public float repulsion = 500f;

    private void OnCollisionEnter(Collision collision)
    {
        if (string.Equals("Wall", collision.gameObject.tag))
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = -direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * repulsion);
        }
    }
}
