using UnityEngine;

public class EscanerLupa : MonoBehaviour
{
  
    public AudioClip sonidoEscaneo;

   
    public GameManagerCSI gameManager;

    private AudioSource audioSource;

   
    private bool pistolaEscaneada = false;
    private bool balaEscaneada = false;
    private bool sangreEscaneada = false;
    private bool idEscaneado = false;

    void Awake()
    {
      
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (gameManager == null) return;

      
        if (other.CompareTag("Pistola") && !pistolaEscaneada)
        {
            pistolaEscaneada = true;
            EfectuarEscaneo();
            gameManager.EncontrarPistola();
        }

        
        else if (other.CompareTag("Bala") && !balaEscaneada)
        {
            balaEscaneada = true;
            EfectuarEscaneo();
            gameManager.EncontrarBalas();
        }

        
        else if (other.CompareTag("Sangre") && !sangreEscaneada)
        {
            sangreEscaneada = true;
            EfectuarEscaneo();
            gameManager.EncontrarSangre();
        }

        
        else if (other.CompareTag("Identificador") && !idEscaneado)
        {
            idEscaneado = true;
            EfectuarEscaneo();
            gameManager.EncontrarCelular();
        }
    }

    private void EfectuarEscaneo()
    {
        Debug.Log("¡Evidencia registrada en el Bloc de Notas!");
        if (audioSource != null && sonidoEscaneo != null)
        {
            audioSource.PlayOneShot(sonidoEscaneo);
        }
    }
}