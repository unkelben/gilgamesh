using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour {

    bool saw;
    bool paint;
    bool ferrule;

    public bool IsSaw() {
        return saw;
    }

    public bool IsPaint() {
        return paint;
    }

    public bool IsFerrule() {
        return ferrule;
    }

    public void Saw() {
        saw = true;
    }

    public void Paint() {
        paint = true;
    }

    public void Ferrule() {
        ferrule = true;
    }

}
