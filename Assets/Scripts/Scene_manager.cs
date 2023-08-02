using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scene_manager : MonoBehaviour
{
    public string scene = "";
    public void TeleportQueued(TeleportingEventArgs args)
    {
        scene = args.interactableObject.transform.name;
    }
}
