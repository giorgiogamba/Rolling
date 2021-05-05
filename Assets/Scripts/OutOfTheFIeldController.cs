using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheFIeldController : MonoBehaviour
{
    public Transform playerSphere;
    public LevelLoader ll;

    void Update()
    {
        if (playerSphere != null && (playerSphere.position.y < -5f)) {
            ll.ReloadHUB();
        }
    }
}
