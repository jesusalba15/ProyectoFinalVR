using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ControladorCapasPapel : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

       
        grabInteractable.selectEntered.AddListener(AlSerAgarrado);
        grabInteractable.selectExited.AddListener(AlSerSoltado);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(AlSerAgarrado);
            grabInteractable.selectExited.RemoveListener(AlSerSoltado);
        }
    }

    private void AlSerAgarrado(SelectEnterEventArgs args)
    {
      
        if (args.interactorObject is XRSocketInteractor)
        {
          
            grabInteractable.interactionLayers = InteractionLayerMask.GetMask("Default");
        }
        else
        {
           
            grabInteractable.interactionLayers = InteractionLayerMask.GetMask("Default", "Marcador");
        }
    }

    private void AlSerSoltado(SelectExitEventArgs args)
    {
       
        grabInteractable.interactionLayers = InteractionLayerMask.GetMask("Default", "Marcador");
    }
}