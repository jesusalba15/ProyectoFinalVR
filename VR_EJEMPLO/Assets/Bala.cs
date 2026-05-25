using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 25;
    public float lifeTime = 5f;

    private Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Disparar(Vector3 direccion)
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direccion * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
