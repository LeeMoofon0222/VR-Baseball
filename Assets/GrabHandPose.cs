using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GrabHandPose : MonoBehaviour
{
    public Hand_Data rightHandPose;
    public Hand_Data leftHandPose;
    public float poseTransitionDuration = 0.2f;
    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startingFingerRotations;
    private Quaternion[] finalFingerRotations;



    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetupPose);
        grabInteractable.selectExited.AddListener(UnSetPose);

        rightHandPose.gameObject.SetActive(false);
        leftHandPose.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            Hand_Data handData = arg.interactorObject.transform.GetComponentInChildren<Hand_Data>();
            handData.animator.enabled = false;

            if(handData.handtype == Hand_Data.HandModelType.Right)
            {
                SetHandDataValues(handData, rightHandPose);
            }
            else
            {
                SetHandDataValues(handData, leftHandPose);
            }
            StartCoroutine(SetHandDataRoutine(handData, finalHandPosition, finalHandRotation, finalFingerRotations, startingHandPosition, startingHandRotation, startingFingerRotations));
        }
    }

    public void UnSetPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            Hand_Data handData = arg.interactorObject.transform.GetComponentInChildren<Hand_Data>();
            handData.animator.enabled = true;

            StartCoroutine(SetHandDataRoutine(handData, finalHandPosition, finalHandRotation, finalFingerRotations, finalHandPosition, finalHandRotation, finalFingerRotations));
        }
    }
    public void SetHandDataValues(Hand_Data h1, Hand_Data h2)
    {
        /*
        startingHandPosition = new Vector3(h1.root.localPosition.x / h1.root.localScale.x,
            h1.root.localPosition.y / h1.root.localScale.y, h1.root.localPosition.z / h1.root.localScale.z);
        finalHandPosition = new Vector3(h2.root.localPosition.x / h2.root.localScale.x,
            h2.root.localPosition.y / h2.root.localScale.y, h2.root.localPosition.z / h2.root.localScale.z);*/
        startingHandPosition = h1.root.localPosition;
        finalHandPosition = h2.root.localPosition;

        startingHandRotation = h1.root.localRotation;
        finalHandRotation = h2.root.localRotation;

        startingFingerRotations = new Quaternion[h1.fingerbones.Length];
        finalFingerRotations = new Quaternion[h1.fingerbones.Length];

        for (int i = 0; i < h1.fingerbones.Length; i++)
        {
            startingFingerRotations[i] = h1.fingerbones[i].localRotation;
            finalFingerRotations[i] = h2.fingerbones[i].localRotation;
        }
    }
    public void SendHandData(Hand_Data h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerbones[i].localRotation = newBonesRotation[i];
        }
    }
    public IEnumerator SetHandDataRoutine(Hand_Data h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation, Vector3 startingPosition, Quaternion startingRotation, Quaternion[] startingBonesRotation)
    {
        float timer = 0;

        while (timer < poseTransitionDuration)
        {
            Vector3 p = Vector3.Lerp(startingPosition, newPosition, timer / poseTransitionDuration);
            Quaternion r = Quaternion.Lerp(startingRotation, newRotation, timer / poseTransitionDuration);

            h.root.localPosition = p;
            h.root.localRotation = r;

            for (int i = 0; i < newBonesRotation.Length; i++)
            {

                h.fingerbones[i].localRotation = Quaternion.Lerp(startingBonesRotation[i], newBonesRotation[i], timer / poseTransitionDuration);
            }

            timer += Time.deltaTime;
            yield return null;
        }
    }

    #if UNITY_EDITOR

    [MenuItem("Tools/Mirror Selected Right Grab Pose")]
    public static void MirrorRightPose()
    {
        Debug.Log("MIRROR RIGHT POSE");
        GrabHandPose handPose = Selection.activeGameObject.GetComponent<GrabHandPose>();
        handPose.MirrorPose(handPose.leftHandPose, handPose.rightHandPose);
    }

    #endif

    public void MirrorPose(Hand_Data poseToMirror, Hand_Data poseUsedToMirror)
    {
        Vector3 mirroredPosition = poseUsedToMirror.root.localPosition;
        mirroredPosition.x *= -1;

        Quaternion mirroredQuaternion = poseUsedToMirror.root.localRotation;
        mirroredQuaternion.y *= -1;
        mirroredQuaternion.z *= -1;

        poseToMirror.root.localPosition = mirroredPosition;
        poseToMirror.root.localRotation = mirroredQuaternion;

        for (int i = 0; i < poseUsedToMirror.fingerbones.Length; i++)
        {
            poseToMirror.fingerbones[i].localRotation = poseUsedToMirror.fingerbones[i].localRotation;
        }
    }
}