using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawndistance = 2;
    public GameObject menu;
    public InputActionProperty showbutton;
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
