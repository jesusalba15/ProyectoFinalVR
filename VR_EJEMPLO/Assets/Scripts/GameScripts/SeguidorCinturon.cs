using UnityEngine;

public class SeguidorCinturon : MonoBehaviour
{
    
    public Transform cabezaJugador;

    
    public float distanciaHaciaAbajo = 0.6f;

    void Update()
    {
        if (cabezaJugador != null)
        {
           
            transform.position = new Vector3(cabezaJugador.position.x, cabezaJugador.position.y - distanciaHaciaAbajo, cabezaJugador.position.z);

           
            transform.eulerAngles = new Vector3(0, cabezaJugador.eulerAngles.y, 0);
        }
    }
}