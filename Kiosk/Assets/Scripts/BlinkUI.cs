using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlinkUI : MonoBehaviour
{
    Graphic[] uiGraphics;

    float alphaVal;
    [SerializeField] float blinkSpeed = 1.0f;
    int blinkDir;

    Color[] startColors;

    private void OnEnable()
    {
        SetupBlinkValue();
        InitAlphaValue();
    }

    private void OnDisable()
    {
        SetupBlinkValue();
        InitAlphaValue();
    }

    private void Awake()
    {
        SetupBlinkValue();
        uiGraphics = GetComponentsInChildren<Graphic>();
        startColors = new Color[uiGraphics.Length];
        for(int i=0; i<uiGraphics.Length; i++)
        {
            startColors[i] = uiGraphics[i].color;
        }
    }
    
    void Update()
    {
        alphaVal += Time.deltaTime * blinkSpeed * blinkDir;

        if (alphaVal < 0 || alphaVal > 1)
            blinkDir *= -1;

        for(int i=0; i<uiGraphics.Length; i++)
        {
            Color nowColor = startColors[i];
            nowColor.a = alphaVal;
            uiGraphics[i].color = nowColor;
        }
    }

    void SetupBlinkValue()
    {
        alphaVal = 0;
        blinkDir = 1;
    }

    void InitAlphaValue()
    {
        for (int i = 0; i < uiGraphics.Length; i++)
        {
            Color nowColor = startColors[i];
            nowColor.a = 0;
            uiGraphics[i].color = nowColor;
        }
    }
}
