using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _2dgroup;

    [SerializeField] Transform anchorGroup;
    Transform anchor_3dMode;
    Transform anchor_2dMode;

    Transform handTf;

    // 버튼 관리용 이중 리스트
    // 0 : 타이틀
    // 1 : 1차 2D 메뉴
    // 2 : 2차 2D 메뉴
    // 3~ : ...위와 같은 형태로 반복
    List<List<GameObject>> buttonObjects;
    int depth; // 현재 UI 깊이값. 이 값을 통해 활성화 될 버튼을 관리


    void Start()
    {
        anchor_3dMode = anchorGroup.GetChild(0);
        anchor_2dMode = anchorGroup.GetChild(1);

        handTf = FindObjectOfType<LeapServiceProvider>().transform;
    }
    
    public void Open2DUI()
    {
        StartCoroutine(moveAndActiveRoutine(anchor_2dMode, true));
    }
    
    public void Close2D()
    {
        StartCoroutine(moveAndActiveRoutine(anchor_3dMode, false));
    }

    IEnumerator moveAndActiveRoutine(Transform _anchor, bool _isActive)
    {
        float lerpVal = 0;

        while(true)
        {
            handTf.position = Vector3.Lerp(handTf.position, _anchor.position, lerpVal);

            if (lerpVal > 0.5f)
            {
                _2dgroup.SetActive(_isActive);
            }
            if (lerpVal >= 1)
            {
                break;
            }
            
            lerpVal += Time.deltaTime * 3.0f;
            
            yield return null;
        }

        yield break;
    }
}
