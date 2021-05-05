using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController
{
    private static bool enabled = true;

    public static void EnablePause() {
        enabled = true;
    }

    public static void DisablePause() {
        enabled = false;
    }

    public static bool isEnabled() {
        return enabled;
    }
}
