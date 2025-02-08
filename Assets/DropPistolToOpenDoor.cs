using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DropPistolToOpenDoor : MonoBehaviour
{
    [SerializeField] Animator door;

    public void OpenDoor()
    {
        door.SetTrigger("Open");
    }
}
