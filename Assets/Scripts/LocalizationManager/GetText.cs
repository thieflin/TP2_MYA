using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetText : MonoBehaviour
{
    public string textTyep;
    public void Start()
    {
        LocalizationManager.Instance.GetText(textTyep);
    }
}
