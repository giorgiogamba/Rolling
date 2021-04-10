using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagement : MonoBehaviour
{
    public static bool enabled = true;

    public static void EnableInput() {
        enabled = true;
    }

    public static void DisableInput() {
        enabled = false;
    }

    public static bool IsEnabled() {
        return enabled;
    }
}
