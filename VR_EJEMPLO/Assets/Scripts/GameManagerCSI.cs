using System.Collections; 
using UnityEngine;
using TMPro;

public class GameManagerCSI : MonoBehaviour
{
    [Header("Textos Principales")]
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoMision; 

    [Header("Textos de la Lista")]
    public TextMeshProUGUI textoBalas;
    public TextMeshProUGUI textoSangre;
    public TextMeshProUGUI textoPistola;
    public TextMeshProUGUI textoCelular;

    [Header("Configuración del Caso")]
    public float tiempoRestante = 300f; 

    private int evidenciasRecolectadas = 0;
    private bool casoActivo = false; 
    private bool juegoIniciado = false; 

    
    private bool balasEncontradas = false;
    private bool sangreEncontrada = false;
    private bool pistolaEncontrada = false;
    private bool celularEncontrado = false;

    void Start()
    {
      
        textoTiempo.gameObject.SetActive(false);
        textoContador.gameObject.SetActive(false);
        textoMision.gameObject.SetActive(false);

        textoBalas.gameObject.SetActive(false);
        textoSangre.gameObject.SetActive(false);
        textoPistola.gameObject.SetActive(false);
        textoCelular.gameObject.SetActive(false);
    }

    void Update()
    {
        if (casoActivo)
        {
            tiempoRestante -= Time.deltaTime;
            int minutos = Mathf.FloorToInt(tiempoRestante / 60);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60);
            textoTiempo.text = "Tiempo " + string.Format("{0:00}:{1:00}", minutos, segundos);

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                textoTiempo.text = "¡TIEMPO AGOTADO!";
                textoTiempo.color = Color.red;
                casoActivo = false;
            }
        }
    }

    
    public void IniciarMisionAlAgarrar()
    {
       
        if (juegoIniciado) return;

        juegoIniciado = true;
        StartCoroutine(SecuenciaIntroduccion());
    }

    
    IEnumerator SecuenciaIntroduccion()
    {
        textoMision.gameObject.SetActive(true);
        textoMision.text = "Hubo un asesinato en esta zona de la ciudad con 2 víctimas.\n\nDebes encontrar los siguientes objetos para enviárselos a los investigadores...";

        
        yield return new WaitForSeconds(6f);

        // Cuenta regresiva
        textoMision.text = "El tiempo iniciará en\n3...";
        yield return new WaitForSeconds(1f);
        textoMision.text = "El tiempo iniciará en\n2...";
        yield return new WaitForSeconds(1f);
        textoMision.text = "El tiempo iniciará en\n1...";
        yield return new WaitForSeconds(1f);

       
        textoMision.gameObject.SetActive(false);

        
        textoTiempo.gameObject.SetActive(true);
        textoContador.gameObject.SetActive(true);
        textoContador.text = "Evidencias 0/4";
        casoActivo = true; 

        
        textoBalas.gameObject.SetActive(true);
        textoBalas.text = "Balas";
        yield return new WaitForSeconds(0.5f);

        textoSangre.gameObject.SetActive(true);
        textoSangre.text = "Sangre";
        yield return new WaitForSeconds(0.5f);

        textoPistola.gameObject.SetActive(true);
        textoPistola.text = "Pistola";
        yield return new WaitForSeconds(0.5f);

        textoCelular.gameObject.SetActive(true);
        textoCelular.text = "Celular";
    }

    
    public void EncontrarBalas()
    {
        if (!balasEncontradas && casoActivo)
        {
            balasEncontradas = true;
            textoBalas.text = "<s>Balas</s>";
            textoBalas.color = Color.gray;
            RegistrarEvidencia();
        }
    }

    public void EncontrarSangre()
    {
        if (!sangreEncontrada && casoActivo)
        {
            sangreEncontrada = true;
            textoSangre.text = "<s>Sangre</s>";
            textoSangre.color = Color.gray;
            RegistrarEvidencia();
        }
    }

    public void EncontrarPistola()
    {
        if (!pistolaEncontrada && casoActivo)
        {
            pistolaEncontrada = true;
            textoPistola.text = "<s>Pistola</s>";
            textoPistola.color = Color.gray;
            RegistrarEvidencia();
        }
    }

    public void EncontrarCelular()
    {
        if (!celularEncontrado && casoActivo)
        {
            celularEncontrado = true;
            textoCelular.text = "<s>Celular</s>";
            textoCelular.color = Color.gray;
            RegistrarEvidencia();
        }
    }

    private void RegistrarEvidencia()
    {
        evidenciasRecolectadas++;
        textoContador.text = "Evidencias: " + evidenciasRecolectadas.ToString() + "/4";

        if (evidenciasRecolectadas >= 4)
        {
            casoActivo = false;
            textoTiempo.text = "¡CASO RESUELTO!";
            textoTiempo.color = Color.green;
        }
    }
}