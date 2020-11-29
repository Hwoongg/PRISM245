using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ///////////////////////////////////////////////////////
//
// 국가 언어별 다른 텍스트를 출력하도록 설정하는 컴포넌트
//
// ///////////////////////////////////////////////////////
public class LanguageVariant : MonoBehaviour
{
    [SerializeField] string korean = "Default Korean";
    [SerializeField] string english = "Default English";
    [SerializeField] string chinese = "Default Chinese";

    Text textUI;
    TextMesh textMesh; // 2D UI가 아닐 경우에 사용
    
    void Start()
    {
        textUI = GetComponent<Text>();
        if(textUI == null) // 2D UI가 아닐 경우
        {
            textMesh = GetComponent<TextMesh>();
        }

        // Language Manager에 자신을 추가하며 초기화 진행
        LanguageManager.Instance().AddList(this);
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
}
