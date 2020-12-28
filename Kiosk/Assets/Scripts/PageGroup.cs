using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;
using TMPro;

public class PageGroup : MonoBehaviour
{
    InteractionButton prevBtn;
    InteractionButton nextBtn;
    TextMeshPro pageText;

    int pageIdx;
    int pageCount;

    int PageIdx
    {
        get
        {
            return pageIdx;
        }

        set
        {
            if (value < 0 || value >= pageCount)
                return;
            pageIdx = value;
        }
    }

    private void OnEnable()
    {
        pageIdx = 0;
        SetPage();
    }

    void Awake()
    {
        // Get Button Ref
        prevBtn = transform.parent.Find("Btn_PrevPage").GetComponent<InteractionButton>();
        nextBtn = transform.parent.Find("Btn_NextPage").GetComponent<InteractionButton>();
        pageText = transform.parent.Find("Text_Page").GetComponent<TextMeshPro>();

        // Mapping Events...
        prevBtn.OnPress += PrevPage;
        nextBtn.OnPress += NextPage;

        pageCount = transform.childCount;
    }
    

    void PrevPage()
    {
        PageIdx--;
        SetPage();
    }

    void NextPage()
    {
        PageIdx++;
        SetPage();
    }

    void SetPage()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(pageIdx).gameObject.SetActive(true);

        SetPageText();
    }

    void SetPageText()
    {
        int nowPage = pageIdx + 1;
        pageText.text = nowPage.ToString() + " / " + pageCount.ToString();
    }
}
