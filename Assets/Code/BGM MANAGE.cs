using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    // Assign your AudioSource in the Inspector (make sure it's set to loop).
    public AudioSource bgmAudioSource;

    // The name of the main level scene where the BGM should play.
    public string mainLevelSceneName = "MainLevel";

    void Awake()
    {
        // Persist this object between scenes.
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method is called each time a scene is loaded.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the newly loaded scene is the Main Level.
        if (scene.name == mainLevelSceneName)
        {
            // If the AudioSource is assigned and not already playing, start it.
            if (bgmAudioSource != null && !bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Play();
                Debug.Log("BGM started in scene: " + scene.name);
            }
        }
    }
}
