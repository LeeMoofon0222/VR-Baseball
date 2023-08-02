using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Data : MonoBehaviour
{
    public enum HandModelType { Left,Right};
    public HandModelType handtype;
    public Transform root;
    public Animator animator;
    public Transform[] fingerbones;
}
