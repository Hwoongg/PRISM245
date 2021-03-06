﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ///////////////////////////////////////////////////////
//
// 국가 언어별 다른 텍스트를 출력하도록 설정하는 컴포넌트
//
// ///////////////////////////////////////////////////////
public class LanguageVariant : MonoBehaviour, ILanguageVariant
{
    public string korean = "Default Korean";
    public string english = "Default English";
    public string chinese = "Default Chinese";

    TextMeshProUGUI textUI;
    TextMeshPro textMesh; // 2D UI가 아닐 경우에 사용

    LanguageManager lm;
    void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        if(textUI == null) // 2D UI가 아닐 경우
        {
            textMesh = GetComponent<TextMeshPro>();
        }

        // Language Manager에 자신을 추가하며 초기화 진행
        lm = LanguageManager.Instance();
        lm.AddList(this);
    }
    

    public void SetLanguage(LanguageManager.LanguageType _lt)
    {
        switch(_lt)
        {
            case LanguageManager.LanguageType.KOREAN:
                if (textUI)
                    textUI.text = korean;
                else
                    textMesh.text = korean;
                break;

            case LanguageManager.LanguageType.ENGLISH:
                if (textUI)
                    textUI.text = english;
                else
                    textMesh.text = english;
                break;

            case LanguageManager.LanguageType.CHINESE:
                if (textUI)
                    textUI.text = chinese;
                else
                    textMesh.text = chinese;
                break;
        }
    }

    private void OnDestroy()
    {
        lm.RemoveVariant(this);
    }
}
