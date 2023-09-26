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
            // ��I����y�ɡA�I�[�@�ӤO�A��������
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.isKinematic = true;
                ballRigidbody.isKinematic = false;
                Vector3 hitDirection = transform.forward; // ������V�i�H�ھڱz���ݭn�վ�
                ballRigidbody.AddForce(hitDirection * hitForce);
            }
        }
    }
}
