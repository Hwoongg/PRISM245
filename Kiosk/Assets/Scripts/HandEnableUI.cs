using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityEngine.UI;

public class HandEnableUI : MonoBehaviour
{
    GameObject leftHand;
    GameObject rightHand;

    [SerializeField] GameObject canvas = null;

    Timer closeTimer;

    [SerializeField] Image handCover;

    private void Awake()
    {
        closeTimer = new Timer(2.0f);
    }
    void Start()
    {
        try
        {
            var lsp = FindObjectOfType<LeapServiceProvider>();
            var handGroup = lsp.transform.Find("Hand Models");
            leftHand = handGroup.transform.GetChild(0).gameObject;
            rightHand = handGroup.transform.GetChild(1).gameObject;
        }
        catch
        {
            Debug.Log("손 활성화 UI 초기화 실패");
        }
    }
    
    void Update()
    {
        if(!leftHand.activeSelf && !rightHand.activeSelf)
        {
            canvas.SetActive(true);
            Color newCollor = Color.yellow;
            newCollor.a = 0.5f;
            handCover.color = newCollor;
        }
        else
        {
            Color newCollor = Color.green;
            newCollor.a = 0.5f;
            handCover.color = newCollor;

            closeTimer.Update();
            if(closeTimer.IsTimeOver())
                canvas.SetActive(false);
        }
    }
}
