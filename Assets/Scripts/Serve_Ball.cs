using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Serve_Ball : MonoBehaviour
{
    public InputActionProperty servebutton;
    public GameObject Ball;
    public Transform emission_point;
    void Update()
    {
        if (servebutton.action.WasPressedThisFrame())
        {
            serve_ball(Ball);
        }
    }

    public void serve_ball(GameObject ball)
    {
        GameObject new_ball =Instantiate(ball, emission_point.position, emission_point.rotation);
        new_ball.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 75, -500));
        Destroy(new_ball, 5);
    }
}
