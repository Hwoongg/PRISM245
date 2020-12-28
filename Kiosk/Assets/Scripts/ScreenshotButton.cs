using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ScreenshotButton : MonoBehaviour
{
    InteractionButton myButton;
    [SerializeField] Sprite screenshot;
    [SerializeField] string summary_kor;
    [SerializeField] string summary_eng;
    [SerializeField] string summary_chi;
    private void Awake()
    {
        myButton = GetComponent<InteractionButton>();
        myButton.OnPress += OnPressEvent;
    }

    void OnPressEvent()
    {
        PopupSpawner.Instance().Spawn(
            screenshot, summary_kor, summary_eng, summary_chi);
    }
}
