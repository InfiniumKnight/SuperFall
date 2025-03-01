using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    // Drag and assign your UI Image (or panel) in the Inspector.
    public GameObject pauseImage;

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause image is hidden at the start.
        if (pauseImage != null)
            pauseImage.SetActive(false);

        // Optionally, lock the cursor at game start.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game, show the image, and free the mouse.
            Time.timeScale = 0f;
            if (pauseImage != null)
                pauseImage.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Resume the game, hide the image, and lock the mouse.
            Time.timeScale = 1f;
            if (pauseImage != null)
                pauseImage.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
