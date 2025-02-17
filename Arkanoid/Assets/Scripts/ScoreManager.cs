using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore;

    void Start()
    {
        // Cargar puntuación guardada
        currentScore = PlayerPrefs.GetInt("Puntuacion", 0);
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI();

        // Guardar puntuación en PlayerPrefs
        PlayerPrefs.SetInt("Puntuacion", currentScore);
        PlayerPrefs.Save();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "SCORE: " + currentScore.ToString("000");
    }
}
