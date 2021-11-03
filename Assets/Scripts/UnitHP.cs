

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{
    public Color myColor;
    public float vSliderValue = 0f;

    void OnGUI()
    {
        vSliderValue = GUI.VerticalSlider(new Rect(Screen.width - 40, Screen.height - 110, 100, 100), vSliderValue, vSliderValue, 0.0f);
        myColor = RGBSlider(new Rect(10, 10, 200, 20), myColor);
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 100.0f, 0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 100.0f, 0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 100.0f, 0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 100.0f, 0f, "xz");
        
        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, float sliderMinValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;


    }
}
