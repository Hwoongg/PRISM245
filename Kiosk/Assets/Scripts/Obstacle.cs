using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Renderer[] renderers;
    Material[] mtrl;

    bool isTranslucent; // 투명 상태 여부

    float lerpVal;

    Timer timer;

    private void Awake()
    {
        timer = new Timer(0.3f);
    }

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        mtrl = new Material[renderers.Length];

        for (int i = 0; i < mtrl.Length; i++)
            mtrl[i] = renderers[i].material;

        isTranslucent = false;
    }
    
    void Update()
    {
        // 주기적으로 반투명화 풀어주려고 시도
        timer.Update();
        if(timer.IsTimeOver())
        {
            isTranslucent = false;
        }

        if (isTranslucent)
        {
            if (lerpVal < 1)
            {
                lerpVal += Time.deltaTime;
                Debug.Log("반투명화 진행중");
            }
        }
        else
        {
            if (lerpVal > 0)
            {
                lerpVal -= Time.deltaTime;
                Debug.Log("반투명화 해제중");
            }
        }

        for (int i = 0; i < mtrl.Length; i++)
        {
            float alpha = Mathf.Lerp(1.0f, 0.5f, lerpVal);
            Color c = mtrl[i].GetColor("_Color");
            c.a = alpha;
            mtrl[i].SetColor("_Color", c);
        }
        //else
        //{
        //    float alpha = Mathf.Lerp(0.0f, 1.0f, lerpVal);

        //    for (int i = 0; i < mtrl.Length; i++)
        //    {
        //        Color c = mtrl[i].GetColor("_Color");
        //        c.a = alpha;
        //        mtrl[i].SetColor("_Color", c);
        //    }

        //    if (lerpVal < 1)
        //    {
        //        lerpVal += Time.deltaTime;
        //    }
        //}
    }


    public void ChangeTranslucent()
    {
        if (isTranslucent)
            OffTranslucent();
        else
            OnTranslucent();
    }

    public void OnTranslucent()
    {
        Debug.Log(gameObject.name + " 반투명화 활성화");
        isTranslucent = true;
        //lerpVal = 0;
    }

    public void OffTranslucent()
    {
        Debug.Log(gameObject.name + " 반투명화 해제");
        isTranslucent = false;
        lerpVal = 0;
    }
}
