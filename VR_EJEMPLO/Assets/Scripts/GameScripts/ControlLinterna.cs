using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ControlLinterna : MonoBehaviour
{
    [Header("Configuracion de Luz")]
    [Tooltip("Arrastra aquí el Spot Light (Luz_Foco) de la linterna")]
    public GameObject objetoLuz;

    [Header("Configuracion de Audio")]
    [Tooltip("Arrastra aquí el archivo de sonido (.mp3 o .wav) para el clic")]
    public AudioClip sonidoClic;

    private XRGrabInteractable grabInteractable;
    private AudioSource audioSource;
    private bool encendida = false;

    void Awake()
    {
       
        grabInteractable = GetComponent<XRGrabInteractable>();

      
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f; 

        
        if (objetoLuz != null) objetoLuz.SetActive(false);
    }

    void OnEnable()
    {
        
        grabInteractable.activated.AddListener(AlPresionarGatillo);
    }

    void OnDisable()
    {
      
        grabInteractable.activated.RemoveListener(AlPresionarGatillo);
    }

    private void AlPresionarGatillo(ActivateEventArgs args)
    {
        if (objetoLuz != null)
        {
           
            encendida = !encendida;
            objetoLuz.SetActive(encendida);

            
            if (audioSource != null && sonidoClic != null)
            {
                audioSource.PlayOneShot(sonidoClic);
            }
        }
    }
}