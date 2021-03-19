using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public Rigidbody projectile;
    public Transform cursor;
    public Transform shootPoint;
    public LayerMask layer;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Launch();
    }

    void Launch() {
        Vector3 pos = Camera.main.WorldToScreenPoint(cursor.position);
        Ray camRay = cam.ScreenPointToRay(pos);

        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit, 100f)) {
            //Prendiamo la posizione del cursor e la alziamo leggermente dal piano
            cursor.transform.position = hit.point;
            Vector3 velocity = CalculateVelocity(hit.point, transform.position, 1f);

            //Modify cannon rotation in order to follow cursor
            transform.rotation = Quaternion.LookRotation(velocity);

            if (Input.GetButtonDown("Fire1")) {
                Rigidbody bullet = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                bullet.velocity = velocity;

            }
         
        }
    }

    //time: time to go from start to end od the path
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) {

        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        //Velocity on X and Y
        //Vx = x / t
        float Vxz = Sxz / time;

        //Vy0 = y / t + 1/2 * g * t
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        //Vector3 res = distanceXZ.normalized;
        //res *= Vxz;
        Vector3 res = distanceXZ.normalized * Vxz;
        res.y = Vy;

        return res;

    }
}
