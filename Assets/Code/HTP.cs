using UnityEngine;
using UnityEngine.UI;

public class ToggleImageOnButtonPress : MonoBehaviour
{
    // Drag and assign your Button in the Inspector.
    public Button actionButton;
    
    // Drag and assign your UI Image (or panel) GameObject in the Inspector.
    public GameObject targetImage;

    void Start()
    {
        // Ensure the image is hidden by default.
        if (targetImage != null)
            targetImage.SetActive(false);

        // Attach the ToggleImage function to the button's onClick event.
        if (actionButton != null)
            actionButton.onClick.AddListener(ToggleImage);
    }

    // Toggle the image's visibility.
    void ToggleImage()
    {
        if (targetImage != null)
            targetImage.SetActive(!targetImage.activeSelf);
    }
}
