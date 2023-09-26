using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_controller : MonoBehaviour
{
    public GameObject Ball;
    public Transform ins_point;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Bat")))
        {
            Destroy(gameObject,4);
            ins_point.GetComponent<ins_ball>().isball = true;
        }
    }
    
}
