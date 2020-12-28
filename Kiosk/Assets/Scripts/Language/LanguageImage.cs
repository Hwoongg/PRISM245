using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageImage : MonoBehaviour, ILanguageVariant
{
    public Sprite img_korean = null;
    public Sprite img_english = null;
    public Sprite img_chinese = null;

    SpriteRenderer myRenderer = null;

    LanguageManager lm;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();

        lm = LanguageManager.Instance();
        lm.AddList(this);
    }

    public void SetLanguage(LanguageManager.LanguageType _lt)
    {
        switch(_lt)
        {
            case LanguageManager.LanguageType.KOREAN:
                myRenderer.sprite = img_korean;
                break;

            case LanguageManager.LanguageType.ENGLISH:
                myRenderer.sprite = img_english;
                break;

            case LanguageManager.LanguageType.CHINESE:
                myRenderer.sprite = img_chinese;
                break;
        }
    }

    private void OnDestroy()
    {
        lm.RemoveVariant(this);
    }
}
