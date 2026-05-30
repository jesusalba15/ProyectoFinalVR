using UnityEngine;

public class RecolectorSangre : MonoBehaviour
{
    
    public GameObject sangreInterior;

    
    public GameManagerCSI gameManager;
    
    public ZonaEvidencia zonaRequerida; 

    private bool yaRecolectada = false;

    void Start()
    {
        if (sangreInterior != null) sangreInterior.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sangre") && !yaRecolectada)
        {
            
            if (zonaRequerida != null && zonaRequerida.marcadorColocado == false)
            {
                Debug.Log("¡Debes poner el marcador amarillo primero!");
                return; 
            }

            yaRecolectada = true;

            if (sangreInterior != null) sangreInterior.SetActive(true);
            if (gameManager != null) gameManager.EncontrarSangre();
        }
    }
}