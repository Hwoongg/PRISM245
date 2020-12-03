using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //[SerializeField] GameObject _2dgroup;

    [SerializeField] Transform anchorGroup;
    Transform anchor_3dMode;
    Transform anchor_2dMode;

    Transform handTf;

    string sceneName2D = "UI_2D";

    bool isAnimating = false;

    int myLayerNum = 0;

    Coroutine nowRoutine;

    private void Start()
    {
        anchor_3dMode = anchorGroup.GetChild(0);
        anchor_2dMode = anchorGroup.GetChild(1);

        handTf = FindObjectOfType<LeapServiceProvider>().transform;
    }
    public void ChangeLanguage(int _iVal)
    {
        LanguageManager.LanguageType lt = (LanguageManager.LanguageType)_iVal;
        LanguageManager.Instance().ChangeLanguage(lt);
    }

    public void Open2DUI()
    {
        if (myLayerNum == UIManager.Instance().depth)
        {
            UIManager.Instance().depth = 1;
            if (!isAnimating)
            {
                isAnimating = true;
                nowRoutine = StartCoroutine(moveAndActiveRoutine(anchor_2dMode, true));
            }
        }
    }

    public void Close2D()
    {
        UIManager.Instance().depth = 0;

        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(moveAndActiveRoutine(anchor_3dMode, false));
        }
    }

    IEnumerator moveAndActiveRoutine(Transform _anchor, bool _isActive)
    {
        float lerpVal = 0;

        while (true)
        {
            handTf.position = Vector3.Lerp(handTf.position, _anchor.position, lerpVal);

            if (lerpVal > 0.5f)
            {
                //_2dgroup.SetActive(_isActive);
                if (_isActive)
                {
                    if (!SceneManager.GetSceneByName(sceneName2D).isLoaded)
                        SceneManager.LoadScene(sceneName2D, LoadSceneMode.Additive);
                }
                else
                {
                    if (SceneManager.GetSceneByName(sceneName2D).isLoaded)
                        SceneManager.UnloadSceneAsync(sceneName2D);
                }
            }
            if (lerpVal >= 1)
            {
                isAnimating = false;
                break;
            }

            lerpVal += Time.deltaTime * 3.0f;

            yield return null;
        }

        yield break;
    }
}
