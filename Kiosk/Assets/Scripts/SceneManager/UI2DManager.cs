using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI2DManager : MonoBehaviour
{
    TitleManager tm;

    Canvas[] canvasArr;
    
    void Start()
    {
        // 캔버스 카메라 지정 (Camera Space Canvas)
        tm = FindObjectOfType<TitleManager>();
        canvasArr = FindObjectsOfType<Canvas>();
        for(int i=0; i<canvasArr.Length;i++)
        {
            canvasArr[i].worldCamera = Camera.main;
            canvasArr[i].planeDistance = 0.4f;
        }
    }
    
    public void Close2D()
    {
        tm.Close2D();
    }
}
