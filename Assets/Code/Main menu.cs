using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button exitButton;
    public Button startButton;
    public Button aboutButton;

    [Header("UI Elements")]
    public GameObject aboutImage;  // This is your About page image

    [Header("Scene Settings")]
    public string sceneToLoad = "OtherScene"; // Replace with your scene name

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        // Automatically hide the About page on start
        if (aboutImage != null)
        {
            aboutImage.SetActive(false);
        }

        // Hook up button listeners
        exitButton.onClick.AddListener(OnExitButtonPressed);
        startButton.onClick.AddListener(OnStartButtonPressed);
        aboutButton.onClick.AddListener(OnAboutButtonPressed);
    }

    private void OnExitButtonPressed()
    {
        Application.Quit();
    }

    private void OnStartButtonPressed()
    {
        SceneManager.LoadScene(sceneToLoad);
         Time.timeScale = 1.0f;
    }

    private void OnAboutButtonPressed()
    {
        // Toggle the visibility of the About page
        if (aboutImage != null)
        {
            aboutImage.SetActive(!aboutImage.activeSelf);
        }
    }
}
