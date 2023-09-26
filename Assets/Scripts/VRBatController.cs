using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBatController : MonoBehaviour
{
    public float hitForce = 500f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 當碰撞到球時，施加一個力，模擬揮棒
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.isKinematic = true;
                ballRigidbody.isKinematic = false;
                Vector3 hitDirection = transform.forward; // 擊打方向可以根據您的需要調整
                ballRigidbody.AddForce(hitDirection * hitForce);
            }
        }
    }
}
