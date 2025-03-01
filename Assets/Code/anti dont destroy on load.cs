using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPersistentCanvas : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the newly loaded scene is your Main Menu scene.
        if (scene.name == "Main menu")
        {
            // Destroy this Canvas when Main Menu loads.
            Destroy(gameObject);
        }
    }
}
