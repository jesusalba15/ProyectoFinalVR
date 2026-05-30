using UnityEngine;

public class AnimarFlechaIndicadora : MonoBehaviour
{
   
    public float velocidadRotacion = 50f; 

   
    
    public float alturaMovimiento = 0.05f; 
    
    public float velocidadMovimiento = 2f;  

    private Vector3 posicionInicial;

    void Start()
    {
       
        posicionInicial = transform.localPosition;
    }

    void Update()
    {
       
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime, Space.Self);

        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadMovimiento) * alturaMovimiento;

        
        transform.localPosition = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
    }
}