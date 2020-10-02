using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySliderAttribute : PropertyAttribute
{
    public float minVal;
    public float maxVal;
    public bool symmetrical;

    public BodySliderAttribute(float minValue, float maxValue, bool symmetrical)
    {
        this.minVal = minValue;
        this.maxVal = maxValue;
        this.symmetrical = symmetrical;
    }
}