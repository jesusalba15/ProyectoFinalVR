using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ZonaEvidencia : MonoBehaviour
{
    
    public GameObject flechaIndicadora;

   
    public bool marcadorColocado = false;

    void Start()
    {
        
        if (flechaIndicadora != null) flechaIndicadora.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !marcadorColocado)
        {
            if (flechaIndicadora != null) flechaIndicadora.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (flechaIndicadora != null) flechaIndicadora.SetActive(false);
        }
    }

  

    public void AlColocarMarcador()
    {
        marcadorColocado = true;
        if (flechaIndicadora != null) flechaIndicadora.SetActive(false); 
    }

    public void AlQuitarMarcador()
    {
        marcadorColocado = false;
        
        if (flechaIndicadora != null) flechaIndicadora.SetActive(true);
    }
}