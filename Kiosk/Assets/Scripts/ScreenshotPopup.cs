using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;
using TMPro;

public class ScreenshotPopup : MonoBehaviour
{
    //Canvas canvas;

    InteractionButton btn_Close;
    [HideInInspector] public Image img_Screenshot;
    [HideInInspector] public LanguageVariant text_Summary;

    private void Awake()
    {
        //canvas = GetComponent<Canvas>();
        //canvas.worldCamera = Camera.main;
        Transform box = transform.Find("Box");
        btn_Close = box.Find("Btn_Close").GetComponent<InteractionButton>();
        btn_Close.OnPress += Close;

        img_Screenshot = box.Find("Img_Screenshot").GetComponent<Image>();

        text_Summary = box.Find("Text_Summary").GetComponent<LanguageVariant>();

    }
    
    void Close()
    {
        UIManager.Instance().depth = 1;
        Destroy(gameObject);
    }
}
