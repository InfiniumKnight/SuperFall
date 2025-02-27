using UnityEngine;

public class SimpleDamage : MonoBehaviour
{
    public HealthBar healthBar; // Assign your HealthBar component in the Inspector

    void Start()
    {
        InvokeRepeating("ApplyDamage", 1f, 1f);
    }

    void ApplyDamage()
    {
        if (healthBar != null)
            healthBar.TakeDamage();
    }
}
