using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class SettingsPropertyController : MonoBehaviour
{
    public Volume volume;
    private WhiteBalance whiteBalance = null;
    private DepthOfField depthOfField = null;
    public Slider propertySlider;



    public void Start()
    {
        volume.profile.TryGet<WhiteBalance>(out whiteBalance);
        volume.profile.TryGet<DepthOfField>(out depthOfField);

    }
    public void ChangeTemprature()
    {
        whiteBalance.temperature.value = (propertySlider.value * 200f) - 100f;
    }

    public void ChangeTint()
    {
        whiteBalance.tint.value = (propertySlider.value * 200f) - 100f;
    }

    //FOCAL LENGTH
    public void ChangeFocusDistance()
    {
        depthOfField.focusDistance.value = propertySlider.value;
    }

    public void ChangeFocalLength()
    {
        depthOfField.focalLength.value = propertySlider.value;
    }

    public void ChangeAparture()
    {
        depthOfField.aperture.value = propertySlider.value;
    }
}