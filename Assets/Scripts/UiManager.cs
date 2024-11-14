using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextComponent;

    public void UpdateText(string txt)
    {
        TextComponent.text = txt;
    }
}
