using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DispensadorMarcadores : MonoBehaviour
{
    
    public GameObject prefabMarcador;

    
    public Transform puntoDeAparicion;

    private GameObject marcadorActual;
    private XRGrabInteractable componenteAgarre;

    void Start()
    {
        GenerarNuevoMarcador();
    }

    void GenerarNuevoMarcador()
    {
        if (prefabMarcador != null)
        {
           
            marcadorActual = Instantiate(prefabMarcador, puntoDeAparicion.position, puntoDeAparicion.rotation);

            
            marcadorActual.transform.SetParent(puntoDeAparicion);

            
            componenteAgarre = marcadorActual.GetComponent<XRGrabInteractable>();

            if (componenteAgarre != null)
            {
              
                componenteAgarre.selectEntered.AddListener(AlAgarrarMarcador);
            }
        }
    }

    private void AlAgarrarMarcador(SelectEnterEventArgs args)
    {
        
        componenteAgarre.selectEntered.RemoveListener(AlAgarrarMarcador);

      
        marcadorActual.transform.SetParent(null);

       
        GenerarNuevoMarcador();
    }
}