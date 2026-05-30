using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CajaEvidencia : MonoBehaviour
{
    
    public string tagRequerido1;
    public string tagRequerido2;

   
    public GameObject modeloCajaAbierta;
    public GameObject modeloCajaSellada;

    
    public Transform puntoAnclaje1;
    public Transform puntoAnclaje2;

  
    public AudioSource audioSource;
    public AudioClip sonidoExitoEvidencia;
    public AudioClip sonidoError;

    private bool objeto1Dentro = false;
    private bool objeto2Dentro = false;

    void Start()
    {
        if (modeloCajaSellada != null) modeloCajaSellada.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag(tagRequerido1) && !objeto1Dentro)
        {
            objeto1Dentro = true;
            BloquearObjetoEnCaja(other.gameObject, puntoAnclaje1);
            VerificarCajaCompleta();
            return;
        }

       
        if (other.CompareTag(tagRequerido2) && !objeto2Dentro)
        {
            objeto2Dentro = true;
            BloquearObjetoEnCaja(other.gameObject, puntoAnclaje2);
            VerificarCajaCompleta();
            return;
        }

       
        if (other.CompareTag("Pistola") || other.CompareTag("Bala") || other.CompareTag("Sangre") || other.CompareTag("Identificador"))
        {
            
            if (audioSource != null && sonidoError != null)
            {
                audioSource.PlayOneShot(sonidoError);
                Debug.Log("¡Evidencia incorrecta para esta caja!");
            }
        }
    }

    void BloquearObjetoEnCaja(GameObject objeto, Transform puntoAnclaje)
    {
        
        XRGrabInteractable grab = objeto.GetComponent<XRGrabInteractable>();
        if (grab != null) grab.enabled = false;

        
        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        
        objeto.transform.position = puntoAnclaje.position;
        objeto.transform.rotation = puntoAnclaje.rotation;

       
        if (audioSource != null && sonidoExitoEvidencia != null)
        {
            audioSource.PlayOneShot(sonidoExitoEvidencia);
        }
    }

    void VerificarCajaCompleta()
    {
        if (objeto1Dentro && objeto2Dentro)
        {
            Debug.Log("¡Caja completada y sellada!");

           
            modeloCajaAbierta.SetActive(false);
            modeloCajaSellada.SetActive(true);

           
        }
    }
}