using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    public void SetMaxHealth(int health)
    {
        healthBarImage.fillAmount = 1f;
    }

    public void SetHealth(int health, int maxHealth)
    {
        healthBarImage.fillAmount = (float)health / maxHealth;
    }
}
