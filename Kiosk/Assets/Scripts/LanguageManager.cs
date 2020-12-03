using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : Singleton<LanguageManager>
{
    public enum LanguageType
    {
        KOREAN,
        ENGLISH,
        CHINESE
    }
    LanguageType nowLanguageType = LanguageType.KOREAN;

    List<LanguageVariant> languageVariants;

    private void Awake()
    {
        languageVariants = new List<LanguageVariant>();
    }


    public override void Start()
    {
        base.Start();
    }
    

    public void AddList(LanguageVariant _lvar)
    {
        languageVariants.Add(_lvar);
        _lvar.SetLanguage(nowLanguageType);
    }

    public void RemoveVariant(LanguageVariant _lvar)
    {
        languageVariants.Remove(_lvar);
    }

    public void ChangeLanguage(LanguageType _lt)
    {
        nowLanguageType = _lt;
        for(int i=0; i<languageVariants.Count; i++)
        {
            languageVariants[i].SetLanguage(nowLanguageType);
        }
    }
}
