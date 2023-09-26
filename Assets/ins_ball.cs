using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ins_ball : MonoBehaviour
{
    public bool isball = false;
    public Transform ins_point;
    void Update()
    {
        if (isball)
        {
            StartCoroutine("InsBall");
            isball = false;
        }
    }
    
    IEnumerator InsBall()
    {
        yield return new WaitForSeconds(2);
        GameObject new_ball = Instantiate(GameObject.FindWithTag("Ball"), ins_point.position, ins_point.rotation);
        new_ball.GetComponent<Rigidbody>().isKinematic = true;
        new_ball.GetComponent<Rigidbody>().isKinematic = false;
    }
}
