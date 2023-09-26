using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawndistance = 2;
    public GameObject menu;
    public InputActionProperty showbutton;
    public TMP_Dropdown dp;
    public TMP_Text setting;
    public TMP_Text voice;
    public TMP_Text bright;
    public TMP_Text language;
    void Start()
    {
        dp.onValueChanged.AddListener(DropdownValue);
    }
    void DropdownValue(int index)
    {
        if(index == 0)
        {
            setting.text = "Setting";
            voice.text = "Voice";
            bright.text = "Bright";
            language.text = "Language";
        }
        else
        {
            setting.text = "設置";
            voice.text = "音量";
            bright.text = "亮度";
            language.text = "語言";
        }
    }
    void Update()
    {
        if (showbutton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawndistance;
        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        //menu.transform.forward *= -1;
    }
}
