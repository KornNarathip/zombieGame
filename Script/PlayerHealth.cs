using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    float currentHealth;
    public bool playerDied = false;

    

    public Canvas playerCanvas;
    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            playerDied = true;
            playerCanvas.enabled = false;
             SceneManager.LoadScene(2);
        }
    }
}
