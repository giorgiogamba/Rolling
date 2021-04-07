using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int tries = 3;

    public static void SetTries(int newValue) {
        tries = newValue;
    }

    public static int GetTries() {
        return tries;
    }

    public static void ResetTries() {
        tries = 3;
    }

    public static void LoseTry() {
        if (tries > 0) {
            tries --;
        }
    }
}
