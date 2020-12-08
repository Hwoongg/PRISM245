using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI2DManager : MonoBehaviour
{
    TitleManager tm;

    //Canvas[] canvasArr;

    [SerializeField] LanguageVariant headText;
    [SerializeField] Transform contentsGroup;

    void Start()
    {
        // 캔버스 카메라 지정 (Camera Space Canvas)
        tm = FindObjectOfType<TitleManager>();
        //canvasArr = FindObjectsOfType<Canvas>();
        //for(int i=0; i<canvasArr.Length;i++)
        //{
        //    canvasArr[i].worldCamera = Camera.main;
        //    canvasArr[i].planeDistance = 0.4f;
        //}

        //InitMenu(UIManager.Instance().open2DMenuIdx);
    }
    
    public void Close2D()
    {
        tm.Close2D();
    }

    // Title Manager의 것과 같음
    public void Event_ChangeLanguage(int _iVal)
    {
        LanguageManager.LanguageType lt = (LanguageManager.LanguageType)_iVal;
        LanguageManager.Instance().ChangeLanguage(lt);
    }

    // 초기 메뉴 열기
    public void InitMenu(int idx)
    {
        if (UIManager.Instance().depth != 1)
            return;

        switch(idx)
        {
            case 0: // 상호작용
                headText.korean = "상호작용";
                headText.english = "Interaction";
                headText.chinese = "相互作用";
                headText.SetLanguage(LanguageManager.Instance().nowLanguageType);
                OpenContents(idx);
                break;

            case 1: // 미디어
                headText.korean = "미디어";
                headText.english = "Media";
                headText.chinese = "媒体";
                headText.SetLanguage(LanguageManager.Instance().nowLanguageType);
                OpenContents(idx);
                break;

            case 2: // 상영시간표
                headText.korean = "상영시간표";
                headText.english = "Timetable";
                headText.chinese = "时间表";
                headText.SetLanguage(LanguageManager.Instance().nowLanguageType);
                OpenContents(idx);
                break;
        }
    }
    
    public void OpenContents(int _idx)
    {
        for (int i=0; i<contentsGroup.childCount; i++)
        {
            contentsGroup.GetChild(i).gameObject.SetActive(false);
        }

        if(_idx < contentsGroup.childCount)
            contentsGroup.GetChild(_idx).gameObject.SetActive(true);
    }
}
