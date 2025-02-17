using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;
    public float speedIncrement = 10.0f; // Cantidad de aumento de velocidad
    public float incrementInterval = 10.0f; // Cada cuántos segundos aumenta la velocidad

    private Rigidbody2D rb;
    private bool isLaunched = false;
    private float timeSinceLastIncrement = 0.0f;
    public TextMeshProUGUI startText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        if (startText != null)
            startText.gameObject.SetActive(true); // Mostrar el mensaje al inicio

        StartCoroutine(IncreaseSpeedOverTime()); // Comenzar la corutina de dificultad
    }

    void Update()
    {
        if (!isLaunched)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                LaunchBall();
            }
        }

        if (transform.position.y < -120)
        {
            SceneManager.LoadScene("GameOver");
        }

        // **Método con Update(): Aumentar velocidad cada cierto tiempo**
        timeSinceLastIncrement += Time.deltaTime;
        if (timeSinceLastIncrement >= incrementInterval)
        {
            speed += speedIncrement;
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
            timeSinceLastIncrement = 0.0f;
            Debug.Log("Velocidad incrementada (Update): " + speed);
        }
    }

    void LaunchBall()
    {
        isLaunched = true;
        rb.linearVelocity = Vector2.up * speed;

        if (startText != null)
            startText.gameObject.SetActive(false);
    }

    // **Método con Corutina: Aumentar velocidad cada cierto tiempo**
    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(incrementInterval);
            speed += speedIncrement;
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
            Debug.Log("Velocidad incrementada (Corutina): " + speed);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Racket"))
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            rb.linearVelocity = dir * speed;
        }
    }
}
