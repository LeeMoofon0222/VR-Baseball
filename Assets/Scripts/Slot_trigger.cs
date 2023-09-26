using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Slot_trigger : MonoBehaviour
{
    private Animator animator;
    public TMP_Text your_score;
    public TMP_Text highest_score;
    public int iys;
    public int ihs;
    private bool add=false;
    public int count = 0;
    void Awake()
    {
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if(count == 0)
            {
                add = true;
            }
            OpenDoor();
            count++;
        }
    }
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
    private void Update()
    {
        iys = Int32.Parse(your_score.text);
        ihs = Int32.Parse(highest_score.text);
        if (add)
        {
            iys += 3;
            if (iys > ihs)
            {
                ihs = iys;
            }
            your_score.text = iys.ToString();
            highest_score.text = ihs.ToString();
            add = false;
        }
    }
}
