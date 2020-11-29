using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogger : MonoBehaviour
{
    public void OnLog(int _i)
    {
        Debug.Log("Press Button : " + _i.ToString());
    }
}
