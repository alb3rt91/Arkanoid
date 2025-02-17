using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreManager scoreManager;
    public GameObject explosionEffect; // Prefab de partículas

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        if (gameManager == null)
            Debug.LogError("GameManager no encontrado en la escena.");

        if (scoreManager == null)
            Debug.LogError("ScoreManager no encontrado en la escena.");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameManager.BlockHidden();
            scoreManager.AddPoints(10); // Sumar puntos

            // Instanciar partículas
            if (explosionEffect != null)
            {
                GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosion, 1f); // Eliminar efecto tras 1 segundo
            }

            Destroy(gameObject); // Destruir el bloque
        }
    }
}
