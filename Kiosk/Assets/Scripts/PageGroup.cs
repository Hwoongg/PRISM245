using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;

public class PageGroup : MonoBehaviour
{
    InteractionButton prevBtn;
    InteractionButton nextBtn;

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

    void Start()
    {
        // Get Button Ref
        prevBtn = transform.parent.Find("Btn_PrevPage").GetComponent<InteractionButton>();
        nextBtn = transform.parent.Find("Btn_NextPage").GetComponent<InteractionButton>();

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
    }
}
