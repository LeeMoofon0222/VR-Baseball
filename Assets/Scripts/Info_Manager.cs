using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Info_Manager : MonoBehaviour
{
    public TMP_Dropdown dp;
    public List<TMP_Text> texts = new List<TMP_Text>();
    private List<string> Etexts_str = new List<string>();
    public List<string> Ctexts_str = new List<string>();
    void Start()
    {
        dp.onValueChanged.AddListener(DropdownValue);
        for(int i = 0; i < texts.Count; i++)
        {
            Etexts_str.Add(texts[i].text);
        }
    }
    void DropdownValue(int index)
    {
        if (index == 0)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                texts[i].text = Etexts_str[i];
            }
        }
        else
        {
            for (int i = 0; i < texts.Count; i++)
            {
                texts[i].text = Ctexts_str[i];
            }
        }
    }
}
