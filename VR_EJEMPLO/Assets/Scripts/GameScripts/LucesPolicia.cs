using UnityEngine;

public class LucesPolicia : MonoBehaviour
{
    
    public Light luzAzul;
    public Light luzRoja;

    
    public float velocidadParpadeo = 0.25f;

    private float cronometro = 0f;
    private bool alternar = false;

    void Start()
    {
        
        if (luzAzul == null || luzRoja == null)
        {
            Debug.LogError("¡Por favor, arrastra las luces Azul y Roja al script en el Inspector!");
        }
    }

    void Update()
    {
        cronometro += Time.deltaTime;

        
        if (cronometro >= velocidadParpadeo)
        {
            alternar = !alternar;

            if (luzAzul != null && luzRoja != null)
            {
               
                luzAzul.enabled = alternar;
                luzRoja.enabled = !alternar;
            }

            cronometro = 0f; 
        }
    }
}