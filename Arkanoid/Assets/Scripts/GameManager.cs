using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalBlocks;
    public string nextSceneName = "NextScene"; // La primera escena que se carga después de MainScene

    void Start()
    {
        totalBlocks = FindObjectsOfType<Block>().Length;
        Debug.Log("Total de bloques en escena: " + totalBlocks);
    }

    public void BlockHidden()
    {
        totalBlocks--;
        Debug.Log("Bloques restantes: " + totalBlocks);

        if (totalBlocks <= 0)
        {
            string currentScene = SceneManager.GetActiveScene().name; // Obtener el nombre de la escena actual

            if (currentScene == "NextScene") // Si la escena actual es NextScene, ir a GameOverScene
            {
                Debug.Log("Todos los bloques eliminados en NextScene. Cargando GameOverScene...");
                SceneManager.LoadScene("GameOver");
            }
            else // Si es otra escena (MainScene), ir a NextScene
            {
                Debug.Log("Todos los bloques eliminados. Cargando la siguiente escena...");
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
