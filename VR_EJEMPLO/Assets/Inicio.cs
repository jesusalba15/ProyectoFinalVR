using UnityEngine;
using Unity.XR.CoreUtils;

public class SetXROriginPosition : MonoBehaviour
{
    public XROrigin xrOrigin;        // Referencia al XR Origin
    public Transform puntoInicio;    // Objeto vacío donde quieres que aparezca

    void Start()
    {
        if (xrOrigin == null || puntoInicio == null)
        {
            Debug.LogWarning("Faltan referencias en SetXROriginPosition");
            return;
        }

        // Mover la cámara (offset incluido)
        Vector3 offset = xrOrigin.Camera.transform.position - xrOrigin.transform.position;

        xrOrigin.transform.position = puntoInicio.position - offset;
        xrOrigin.transform.rotation = puntoInicio.rotation;
    }
}