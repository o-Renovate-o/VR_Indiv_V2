using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GravirtyOnOff : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider ActionBasedContinuousMoveProvider;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    // Update is called once per frame
    void Update()
    {
        ActionBasedContinuousMoveProvider.useGravity = !(rightActivate.action.ReadValue<float>() > 0.1f || leftActivate.action.ReadValue<float>() > 0.1);
        Debug.Log(ActionBasedContinuousMoveProvider.useGravity);
    }
}
