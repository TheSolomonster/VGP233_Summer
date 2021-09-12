using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    public void setValue(float val)
    {
        slider.value = val;
    }
   public void setMaxMin(float start, float end)
    {
        slider.minValue = start;
        slider.maxValue = end;
    }
}
