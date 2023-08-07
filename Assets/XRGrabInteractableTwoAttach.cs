using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttached : XRGrabInteractable
{

    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            leftAttachTransform = rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }
}
