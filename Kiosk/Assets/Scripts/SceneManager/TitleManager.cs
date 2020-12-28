using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //[SerializeField] GameObject _2dgroup;

    //[SerializeField] Transform anchorGroup = null;
    //Transform anchor_3dMode;
    //Transform anchor_2dMode;

    //Transform handTf;

    string sceneName2D = "UI_2D";

    bool isAnimating = false;

    int myLayerNum = 0;

    Coroutine nowRoutine;

    [SerializeField] Animation panelAnim;

    bool isOpen2D = false;

    private void Start()
    {
        //anchor_3dMode = anchorGroup.GetChild(0);
        //anchor_2dMode = anchorGroup.GetChild(1);

        //handTf = FindObjectOfType<LeapServiceProvider>().transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Open2DUI();
    }
    public void ChangeLanguage(int _iVal)
    {
        LanguageManager.LanguageType lt = (LanguageManager.LanguageType)_iVal;
        LanguageManager.Instance().ChangeLanguage(lt);
    }

    public void Open2DUI()
    {
        //if (myLayerNum == UIManager.Instance().depth)
        //{
        //    UIManager.Instance().depth = 1;
        //    if (!isAnimating)
        //    {
        //        isAnimating = true;
        //        nowRoutine = StartCoroutine(moveAndActiveRoutine(anchor_2dMode, true));
        //    }
        //}
        if (!isOpen2D)
        {
            if (!panelAnim.isPlaying)
            {
                UIManager.Instance().depth = 1;
                panelAnim.clip = panelAnim.GetClip("InToDepth1");
                isOpen2D = true;

                panelAnim.Play();
            }
        }
    }

    public void Close2D()
    {
        //UIManager.Instance().depth = 0;

        //if (!isAnimating)
        //{
        //    isAnimating = true;
        //    StartCoroutine(moveAndActiveRoutine(anchor_3dMode, false));
        //}
        if (UIManager.Instance().depth != 1)
            return;

        if (isOpen2D)
        {
            if (!panelAnim.isPlaying)
            {
                UIManager.Instance().depth = 0;
                panelAnim.clip = panelAnim.GetClip("InToDepth0");
                isOpen2D = false;

                panelAnim.Play();
            }
        }

        
    }

    //IEnumerator moveAndActiveRoutine(Transform _anchor, bool _isActive)
    //{
    //    float lerpVal = 0;

    //    while (true)
    //    {
    //        handTf.position = Vector3.Lerp(handTf.position, _anchor.position, lerpVal);

    //        if (lerpVal > 0.5f)
    //        {
    //            //_2dgroup.SetActive(_isActive);
    //            if (_isActive)
    //            {
    //                if (!SceneManager.GetSceneByName(sceneName2D).isLoaded)
    //                    SceneManager.LoadScene(sceneName2D, LoadSceneMode.Additive);
    //            }
    //            else
    //            {
    //                if (SceneManager.GetSceneByName(sceneName2D).isLoaded)
    //                    SceneManager.UnloadSceneAsync(sceneName2D);
    //            }
    //        }
    //        if (lerpVal >= 1)
    //        {
    //            isAnimating = false;
    //            break;
    //        }

    //        lerpVal += Time.deltaTime * 3.0f;

    //        yield return null;
    //    }

    //    yield break;
    //}
}
