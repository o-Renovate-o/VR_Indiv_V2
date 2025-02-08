using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
{
    [Header("Grab interactable")]
    [SerializeField] XRGrabInteractable grabInteractable;

    [Header("Raycasting info")]
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;

    [Header("Target hit graphic")]
    [SerializeField] GameObject hitGraphic;

    private void OnEnable() => grabInteractable.activated.AddListener(TriggerPulled);

    private void OnDisable() => grabInteractable.activated.RemoveListener(TriggerPulled);

    private void TriggerPulled(ActivateEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

        FireRaycastIntoScene();
    }
   
    private void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            if (hit.transform.GetComponent<ITargetInterface>() != null)
            {
                hit.transform.GetComponent<ITargetInterface>().TargetShot(hit.point);

                //CreateHitGraphicOnTarget(hit.point);
            }
            else
            {
                if (hit.transform.GetComponent<GameStartUIController>() != null)
                {
                    hit.transform.GetComponent<GameStartUIController>().TargetHit();
                }
            }
        }
    }

    private void CreateHitGraphicOnTarget(Vector3 hitLocation)
    {
        GameObject hitMarker = Instantiate(hitGraphic, hitLocation, Quaternion.identity);
    }
}
