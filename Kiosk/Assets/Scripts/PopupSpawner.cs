using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSpawner : Singleton<PopupSpawner>
{
    GameObject prf_PopupCanvas;

    private void Awake()
    {
        prf_PopupCanvas = Resources.Load(
            "Prefabs/Canvas_ScreenshotPopup", typeof(GameObject)) as GameObject;
    }

    public void Spawn(Sprite _image, string _textKor, string _textEng, string _textChi)
    {
        GameObject popup = GameObject.Instantiate(prf_PopupCanvas);
        ScreenshotPopup screenshotPopup = popup.GetComponent<ScreenshotPopup>();
        screenshotPopup.img_Screenshot.sprite = _image;
        screenshotPopup.text_Summary.korean = _textKor;
        screenshotPopup.text_Summary.english = _textEng;
        screenshotPopup.text_Summary.chinese = _textChi;
        screenshotPopup.text_Summary.SetLanguage(LanguageManager.Instance().nowLanguageType);
    }
}
