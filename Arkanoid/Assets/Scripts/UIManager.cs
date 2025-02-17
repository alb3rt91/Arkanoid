using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private Button botonQuit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener UIManager en todas las escenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
            return;
        }
    }

    private void Start()
    {
        AssignQuitButton(); // Buscar el botón al inicio
        SceneManager.sceneLoaded += OnSceneLoaded; // Detectar cambios de escena
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignQuitButton(); // Volver a asignar el botón al cargar una nueva escena
    }

    private void AssignQuitButton()
{
    botonQuit = GameObject.Find("QuitButton")?.GetComponent<Button>();

    if (botonQuit != null)
    {
        botonQuit.onClick.RemoveAllListeners(); // Limpiar eventos anteriores
        botonQuit.onClick.AddListener(() =>
        {
            Debug.Log("✔ Se hizo clic en QuitButton.");
            QuitGame();
        });

        Debug.Log("✔ QuitButton asignado en: " + SceneManager.GetActiveScene().name);
    }
    else
    {
        Debug.LogError("❌ ERROR: `QuitButton` NO encontrado en la escena: " + SceneManager.GetActiveScene().name);
    }
}



   private void QuitGame()
{
    Debug.Log("✔ QuitGame() ha sido ejecutado correctamente.");

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // Cierra el modo Play en Unity
#else
    Application.Quit();
#endif
}

}