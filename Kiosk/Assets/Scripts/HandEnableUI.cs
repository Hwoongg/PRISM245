using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class HandEnableUI : MonoBehaviour
{
    GameObject leftHand;
    GameObject rightHand;

    [SerializeField] GameObject canvas = null;

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
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
