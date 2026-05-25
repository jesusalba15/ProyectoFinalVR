using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Pistola : MonoBehaviour
{
    public Transform firePoint;
    public GameObject balaPrefab;

    void Start()
    {
        XRGrabInteractable grabInteract = GetComponent<XRGrabInteractable>();
        grabInteract.activated.AddListener(x => Disparando());
    }

    public void Disparando()
    {
        GameObject bala = Instantiate(balaPrefab, firePoint.position, firePoint.rotation);

        Bala scriptBala = bala.GetComponent<Bala>();
        scriptBala.Disparar(firePoint.forward);
    }

}
