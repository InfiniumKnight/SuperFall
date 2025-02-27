using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;          
    public Image gameOverImage;       
    public float maxHealth = 100f;
    private float currentHealth;

    public MonoBehaviour cameraController; 
    public MonoBehaviour playerController; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        if (gameOverImage != null)
            gameOverImage.gameObject.SetActive(false);
    }

    // >>>>>>>>>>Call this method when damage is taken<<<<<<<<<
    public void TakeDamage()
    {
        // Each hit subtracts 10% hp
        currentHealth -= maxHealth / 10f;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            
            if (gameOverImage != null)
                gameOverImage.gameObject.SetActive(true);

            // Freeze the entire game
            Time.timeScale = 0f;

            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Disable camera and player controls to lock movement
            if (cameraController != null)
                cameraController.enabled = false;
            if (playerController != null)
                playerController.enabled = false;
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
