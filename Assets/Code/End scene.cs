using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Drag and assign the scene name in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (!string.IsNullOrEmpty(sceneToLoad)) // Ensure scene name is assigned
            {
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(sceneToLoad); // Switch to assigned scene
            }
            else
            {
                Debug.LogWarning("No scene assigned! Please set a scene name in the Inspector.");
            }
        }
    }
}
