using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EtiquetaObjeto : MonoBehaviour
{
    public GameObject etiqueta;

    private bool primeraSeleccion = true;

    public void AlSeleccionar(SelectEnterEventArgs args)
    {
        // Ignora la selección inicial del socket
        if (primeraSeleccion)
        {
            primeraSeleccion = false;
            return;
        }

        etiqueta.SetActive(false);
    }
}