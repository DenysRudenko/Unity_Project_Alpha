using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int numOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
    }

    public void TakeDamage(int damageAmount)
    {   
        maxHealth -= damageAmount;

        // Ensure health doesn't go below 0
        maxHealth = Mathf.Max(0, maxHealth);

        UpdateHearts();
    }

    void UpdateHearts()
    {
        if (hearts != null)
        {
            ClampMaxHealth();

            UpdateHeartSprites();

            DisplayHearts();
        }
    }

    void ClampMaxHealth()
    {
        // Ensure maxHealth doesn't exceed numOfHearts
        maxHealth = Mathf.Min(maxHealth, numOfHearts);
    }

    void UpdateHeartSprites()
    {   
        // Replace fullHeart with emptyHeart
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    void DisplayHearts()
    {   
        // Display hearts and disable
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < numOfHearts;
        }
    }

}
