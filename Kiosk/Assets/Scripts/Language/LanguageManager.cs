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
    [HideInInspector] public LanguageType nowLanguageType = LanguageType.KOREAN;

    List<ILanguageVariant> languageVariants;

    private void Awake()
    {
        languageVariants = new List<ILanguageVariant>();
    }


    public override void Start()
    {
        base.Start();
    }
    

    public void AddList(ILanguageVariant _lvar)
    {
        languageVariants.Add(_lvar);
        _lvar.SetLanguage(nowLanguageType);
    }

    public void RemoveVariant(ILanguageVariant _lvar)
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
