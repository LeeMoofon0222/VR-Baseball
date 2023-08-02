using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat_Pos : MonoBehaviour
{
    // Update is called once per frame
    public int judge = 0;
    void Update()
    {
        GameObject scenes_manager = GameObject.Find("Scenes_Manager");
        GameObject bat = GameObject.Find("baseballBat");
        GameObject left_hand = GameObject.Find("Left Hand Model");
        GameObject right_hand = GameObject.Find("Right Hand Model");
        if (scenes_manager.GetComponent<Scene_manager>().scene == "9Slots_Anchor" && judge == 0)
        {
            left_hand.transform.Rotate(new Vector3(0, 0, 45));
            right_hand.transform.Rotate(new Vector3(0, 0, -45));
            judge = 1;
        }
    }
}
