using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void ChangeLanguage(int _iVal)
    {
        LanguageManager.LanguageType lt = (LanguageManager.LanguageType)_iVal;
        LanguageManager.Instance().ChangeLanguage(lt);
    }
}
