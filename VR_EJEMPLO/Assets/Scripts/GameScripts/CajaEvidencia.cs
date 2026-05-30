using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using TMPro; // Para controlar los textos de la hoja

public class CajaEvidencia : MonoBehaviour
{
    public string tagRequerido1;
    public string tagRequerido2;

    public GameObject modeloCajaAbierta;
    public GameObject modeloCajaSellada;

    [Header("Flujo de Juego (Opcional)")]
    public GameObject siguienteCajaActivar;

    public Transform puntoAnclaje1;
    public Transform puntoAnclaje2;

    public AudioSource audioSource;
    public AudioClip sonidoExitoEvidencia;
    public AudioClip sonidoError;

    [Header("Sistema de la Hoja / Contador General")]
    // Aquí arrastras el texto que dice "0 / 4"
    public TextMeshProUGUI textoContadorGeneral;
    private static int evidenciasTotalesRecolectadas = 0;

    [Header("Items Específicos de esta Caja")]
    // Aquí arrastras los textos de los nombres de los ítems que van en ESTA caja
    // Ejemplo para Caja 1: Texto de "Sangre" y Texto de "Identificador"
    public TextMeshProUGUI textoItem1;
    public TextMeshProUGUI textoItem2;

    private bool objeto1Dentro = false;
    private bool objeto2Dentro = false;

    void Start()
    {
        if (modeloCajaSellada != null) modeloCajaSellada.SetActive(false);
        ActualizarTextoGeneral();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagRequerido1) && !objeto1Dentro)
        {
            objeto1Dentro = true;
            BloquearObjetoEnCaja(other.gameObject, puntoAnclaje1);

            evidenciasTotalesRecolectadas++;
            ActualizarTextoGeneral();

            // Ponemos el texto del Ítem 1 en gris
            PonerTextoEnGris(textoItem1);

            VerificarCajaCompleta();
            return;
        }

        if (other.CompareTag(tagRequerido2) && !objeto2Dentro)
        {
            objeto2Dentro = true;
            BloquearObjetoEnCaja(other.gameObject, puntoAnclaje2);

            evidenciasTotalesRecolectadas++;
            ActualizarTextoGeneral();

            // Ponemos el texto del Ítem 2 en gris
            PonerTextoEnGris(textoItem2);

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

            other.transform.SetParent(this.transform);
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
        objeto.transform.SetParent(modeloCajaAbierta.transform);

        if (audioSource != null && sonidoExitoEvidencia != null)
        {
            audioSource.PlayOneShot(sonidoExitoEvidencia);
        }
    }

    void VerificarCajaCompleta()
    {
        if (objeto1Dentro && objeto2Dentro)
        {
            modeloCajaAbierta.SetActive(false);
            modeloCajaSellada.SetActive(true);

            if (siguienteCajaActivar != null)
            {
                siguienteCajaActivar.SetActive(true);
            }
        }
    }

    void ActualizarTextoGeneral()
    {
        if (textoContadorGeneral != null)
        {
            textoContadorGeneral.text = evidenciasTotalesRecolectadas + " / 4";
        }
    }

    // Función auxiliar para cambiar el color a gris opaco
    void PonerTextoEnGris(TextMeshProUGUI texto)
    {
        if (texto != null)
        {
            texto.color = new Color(0.5f, 0.5f, 0.5f, 0.6f); // Gris con un toque de transparencia (opaco)

            // Opcional: Si quieres que además se tache con una línea, descomenta la siguiente línea:
            // texto.fontStyle = FontStyles.Strikethrough;
        }
    }
}