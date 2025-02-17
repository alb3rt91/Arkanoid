using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        // Reiniciar la puntuación a 0
        PlayerPrefs.SetInt("Puntuacion", 0);
        PlayerPrefs.Save();

        // Volver a la escena principal
        SceneManager.LoadScene("MainScene");
    }
}
