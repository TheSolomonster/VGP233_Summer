using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    public void setReloadTime(float time)
    {
        slider.value = time;
    }
   public void setMaxMin(float start, float end)
    {
        slider.minValue = start;
        slider.maxValue = end;
    }
}
