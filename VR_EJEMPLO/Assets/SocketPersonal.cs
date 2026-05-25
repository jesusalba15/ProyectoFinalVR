using UnityEngine;  
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketPersonal : XRSocketInteractor
{
    public string targetTag; // Etiqueta que el objeto debe tener para ser aceptado

    public override bool CanHover(IXRHoverInteractable interactable)
    {
      return base.CanHover(interactable) && interactable.transform.tag == targetTag;

    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.tag == targetTag;
    }
}