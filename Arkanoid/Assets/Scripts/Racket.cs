using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 200f; // Ajusta este valor si sigue lento
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // Movimiento con teclas izquierda/derecha
        rb.linearVelocity = new Vector2(h * speed, 0); // Movimiento más rápido y responsivo
    }
}
