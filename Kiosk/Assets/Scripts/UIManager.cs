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
    // Start is called before the first frame update
    void Start()
    {
        anchor_3dMode = anchorGroup.GetChild(0);
        anchor_2dMode = anchorGroup.GetChild(1);

        handTf = FindObjectOfType<LeapServiceProvider>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
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
