using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ToggleRunSpeedCheat : MonoBehaviour
{
    [Header("UI Reference (Optional)")]
    public Button toggleButton; // Optionally assign your toggle button here

    [Header("Cheat Settings")]
    public float cheatSpeed = 70f;  // Speed when cheat is active
    public float normalSpeed = 8f;  // Normal speed when cheat is inactive

    [Header("Cheat Indicator UI")]
    public GameObject cheatIndicatorImage;  // Drag and assign an image that indicates the cheat state

    private bool cheatActive = false;
    private MovementController movementController;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleCheat);
        }
        else
        {
            Debug.Log("ToggleRunSpeedCheat: No toggle button assigned. You can toggle the cheat via code.");
        }

        // Try to apply cheat immediately in the current scene (if available)
        ApplyCheatToCurrentScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Start a coroutine to wait for the MovementController to be available in the new scene.
        StartCoroutine(WaitAndApplyCheat());
    }

    IEnumerator WaitAndApplyCheat()
    {
        float timer = 0f;
        while (timer < 5f) // Wait up to 5 seconds
        {
            movementController = FindObjectOfType<MovementController>();
            if (movementController != null)
            {
                ApplyCheat();
                Debug.Log("Cheat applied in scene: " + SceneManager.GetActiveScene().name);
                yield break;
            }
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.LogWarning("No MovementController found in scene after waiting 5 seconds.");
    }

    public void ToggleCheat()
    {
        cheatActive = !cheatActive;
        ApplyCheat();
    }

    void ApplyCheat()
    {
        if (movementController != null)
        {
            movementController.runSpeed = cheatActive ? cheatSpeed : normalSpeed;
            Debug.Log("Cheat " + (cheatActive ? "activated" : "deactivated") +
                      ": runSpeed set to " + movementController.runSpeed);
        }
        else
        {
            Debug.LogWarning("MovementController not found; cheat state (" + cheatActive + ") stored for next scene.");
        }

        // Toggle the cheat indicator image based on the cheat state.
        if (cheatIndicatorImage != null)
        {
            cheatIndicatorImage.SetActive(cheatActive);
        }
    }

    void ApplyCheatToCurrentScene()
    {
        movementController = FindObjectOfType<MovementController>();
        if (movementController != null)
        {
            ApplyCheat();
        }
        else
        {
            Debug.Log("No MovementController found in current scene: " + SceneManager.GetActiveScene().name);
        }
    }
}
